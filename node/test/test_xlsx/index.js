const fs = require("fs");
const XLSX = require("xlsx");

const mode = 1;
const filename = mode === 0 ? "test_xlsx_in.xlsx" : "test_xlsx_out.xlsx";
const sheetName = "Sheet1";

const logDate = (date) => {
    console.log("%i-%i-%i %i:%i:%i.%i", date.getFullYear(), date.getMonth() + 1, date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds(), date.getMilliseconds());
}

let wb, ws, data;

if (mode === 0) {
    try {
        if (!fs.existsSync(filename, fs.constants.F_OK))
            return;
    }
    catch (error) {
        console.log(error);
    }

    wb = XLSX.readFile(filename, { sheetStubs: true, cellDates: true/*, dateNF: 'yyyy-mm-dd'*/ });
    ws = wb.Sheets[sheetName];
    data = XLSX.utils.sheet_to_json(ws);
    if (Array.isArray(data) && data.length) {
        logDate(data[0].activationDate);
    }
}

if (mode === 1) {
    try {
        if (fs.existsSync(filename, fs.constants.F_OK))
            fs.unlinkSync(filename);
    }
    catch (error) {
        console.log(error);
    }

    let data, merge;

    //data = getDateData();
    ({ data, merge } = getTreeDataToExport(getTreeData()));

    wb = XLSX.utils.book_new();
    ws = XLSX.utils.json_to_sheet(data);

    if (merge)
        ws["!merges"] = merge;

    XLSX.utils.book_append_sheet(wb, ws, sheetName);
    XLSX.writeFile(wb, filename, { bookType: "xlsx", type: "array" });
}

function getDateData() {
    return [
        { activationDate: new Date(2023, 4, 24, 0, 0, 0, 0) }
    ];
}

function getTreeDataToExport(data) {
    const result = [];
    const merge = [];
    
    const tmpData = data.id === "root" ? data.children : [ data ];

    let rowStart = 1;

    for (let i = 0, l = tmpData.length; i < l; ++i) {
        const { data: nodeData, merge: nodeMerge, newRowStart} = getTreeDataToExportNode(tmpData[i], rowStart);

        if (Array.isArray(nodeData) && nodeData.length)
            result.push(...nodeData);

        if (Array.isArray(nodeMerge) && nodeMerge.length)
            merge.push(...nodeMerge);

        if (newRowStart - rowStart > 1)
            merge.push({ s: { r: rowStart, c: 0}, e: { r: newRowStart - 1, c: 0 } });

        rowStart = newRowStart;
    }

    return { data: result, merge };
}

function getTreeDataToExportNode(data, rowStart) {
    const { data: nodeData, lengths } = getTreeNodeDataToExport(data);
    const { merge, newRowStart } = getTreeDataToExportMerge(lengths, rowStart);
    return { data: nodeData, merge, newRowStart }
}

function getTreeDataToExportMerge(lengths, rowStart) {
    const merge = [];

    let sr = rowStart;

    for (let i = 0, l = lengths.length; i < l; ++i) {
        if (lengths[i][0] > 1 || lengths[i][1] > 1)
            merge.push({ s: { r: sr, c: 1}, e: { r: sr + lengths[i][0] + lengths[i][1] - 1, c: 1 } });

        for (let k = 0; k < 2; ++k) {
            const er = sr + lengths[i][k];

            if (lengths[i][k] > 1)
                merge.push({ s: { r: sr, c: 2}, e: { r: er - 1, c: 2 } });

            sr = er;
        }

        if (!lengths[i][0] && !lengths[i][1])
            ++sr;
    }

    return { merge: merge.length ? merge : undefined, newRowStart: sr };
}

function getTreeNodeDataToExport(data) {
    const result = [];
    const lengths = [];

    for (let i = 0, l = data.children.length; i < l; ++i) {
        const { data: nodePrincipalData, lengths: nodePrincipalLengths } = getTreeNodePrincipalDataToExport(data.children[i], data.name)

        if (!nodePrincipalLengths[0] && !nodePrincipalLengths[1]) {
            result.push({ "Master dealer": data.name, "Principal": data.children[i].name, "Role": undefined, "User": undefined });
        } else {
            result.push(...nodePrincipalData);
        }
        
        lengths.push(nodePrincipalLengths);
    }

    return { data: result, lengths };
};

function getTreeNodePrincipalDataToExport(data, masterDealerName) {
    const result = [];
    const lengths = [];

    for (let i = 0; i < 2; ++i) {
        const length = data.children[i].children.length;
        lengths.push(length);

        if (!length)
            continue;
        
        for (let k = 0; k < length; ++k)
            result.push({ "Master dealer": masterDealerName, "Principal": data.name, "Role": data.children[i].name, "User": data.children[i].children[k].name });
    }

    return { data: result, lengths };
};

function getTreeData() {
    return {
        id: "root",
        children: [
            {
                id: "999",
                name: "Master dealer #999",
                children: [
                    { id: "principal-999-1", name: "Principal #1", children: [ { id: "admins", name: "Admins", children: [ { id: "admin-999-1-1", name: "999 1 Admin #1" }, { id: "admin-999-1-2", name: "999 1 Admin #2" }, { id: "admin-999-1-3", name: "999 1 Admin #3" } ] }, { id: "members", name: "Members", children: [ { id: "member-999-1-1", name: "999 1 Member #1" }, { id: "member-999-1-2", name: "999 1 Member #2" } ] } ] },
                    { id: "principal-999-2", name: "Principal #2", children: [ { id: "admins", name: "Admins", children: [ { id: "admin-999-2-1", name: "999 2 Admin #1" }, { id: "admin-999-2-2", name: "999 2 Admin #2" }, { id: "admin-999-2-3", name: "999 2 Admin #3" } ] }, { id: "members", name: "Members", children: [ { id: "member-999-2-1", name: "999 2 Member #1" } ] } ] },
                    { id: "principal-999-3", name: "Principal #3", children: [ { id: "admins", name: "Admins", children: [] }, { id: "members", name: "Members", children: [] } ] },
                    { id: "principal-999-4", name: "Principal #4", children: [ { id: "admins", name: "Admins", children: [ { id: "admin-999-4-1", name: "999 4 Admin #1" }, { id: "admin-999-4-2", name: "999 4 Admin #2" } ] }, { id: "members", name: "Members", children: [] } ] },
                    { id: "principal-999-5", name: "Principal #5", children: [ { id: "admins", name: "Admins", children: [ { id: "admin-999-5-1", name: "999 5 Admin #1" } ] }, { id: "members", name: "Members", children: [] } ] },
                    { id: "principal-999-6", name: "Principal #6", children: [ { id: "admins", name: "Admins", children: [] }, { id: "members", name: "Members", children: [] } ] },
                ]
            },
            {
                id: "998",
                name: "Master dealer #998",
                children: [
                    { id: "principal-998-1", name: "Principal #1", children: [ { id: "admins", name: "Admins", children: [ { id: "admin-998-1-1", name: "998 1 Admin #1" }, { id: "admin-998-1-2", name: "998 1 Admin #2" }, { id: "admin-998-1-3", name: "998 1 Admin #3" } ] }, { id: "members", name: "Members", children: [ { id: "member-998-1-1", name: "998 1 Member #1" }, { id: "member-998-1-2", name: "998 1 Member #2" } ] } ] },
                ]
            },
            {
                id: "997",
                name: "Master dealer #997",
                children: [
                    { id: "principal-997-1", name: "Principal #1", children: [ { id: "admins", name: "Admins", children: [ { id: "admin-997-1-1", name: "997 1 Admin #1" }, { id: "admin-997-1-2", name: "997 1 Admin #2" }, { id: "admin-997-1-3", name: "997 1 Admin #3" } ] },  { id: "members", name: "Members", children: [ { id: "member-997-1-1", name: "997 1 Member #1" }, { id: "member-997-1-2", name: "997 1 Member #2" } ] } ] },
                ]
            },
            {
                id: "996",
                name: "Master dealer #996",
                children: []
            },
            {
                id: "995",
                name: "Master dealer #995",
                children: [
                    { id: "principal-995-1", name: "Principal #1", children: [ { id: "admins", name: "Admins", children: [] }, { id: "members", name: "Members", children: [] } ] },
                ]
            }
        ]
    };
};
