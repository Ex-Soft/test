var
    smthEnum = [0, 1, 2, 3, 4, 5],
    smthEnumStr = ["Zero", "First", "Second", "Third", "Fourth", "Fifth"];

$(document).ready(function () {
    $.getJSON("anytest/getsmthenum")
        .done(function (data) {
            if (data && Array.isArray(data.SmthEnum))
                smthEnum = data.SmthEnum;
        });

    $.getJSON("anytest/getsmthenumstr")
        .done(function (data) {
            if (data && Array.isArray(data.SmthEnumStr))
                smthEnumStr = data.SmthEnumStr;
        });
});

function testArrayByGet(useStr) {
    var values = (useStr ? smthEnumStr : smthEnum).reduce((accumulator, currentValue, currentIndex, array) => {
        if ((useStr && currentIndex % 2 === 0) || (!useStr && currentIndex % 2 !== 0))
            return accumulator;

        if (accumulator.length)
            accumulator += "&";

        return accumulator + `Values=${currentValue}`;
    }, "");

    $.getJSON(`anytest/testarraybyget?${values}`)
        .done(function (data) {
            if (window.console && console.log)
                console.log(data);
        });
}

function testArrayByGetIActionResult(useStr) {
    var values = (useStr ? smthEnumStr : smthEnum).reduce((accumulator, currentValue, currentIndex, array) => {
        if ((useStr && currentIndex % 2 === 0) || (!useStr && currentIndex % 2 !== 0))
            return accumulator;

        if (accumulator.length)
            accumulator += "&";

        return accumulator + `Values=${currentValue}`;
    }, "");

    $.getJSON(`anytest/testarraybygetiactionresult?${values}`)
        .done(function (data) {
            if (window.console && console.log)
                console.log(data);
        });
}
