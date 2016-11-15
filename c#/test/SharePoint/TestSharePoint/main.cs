//#define TEST_LOAD_ITEM
//#define TEST_FILE
//#define GET_INFO
//#define TEST_DETAIL_VIEW
//#define TEST_CUSTOM_FIELD
//#define TEST_CONTENT_TYPE
//#define TEST_EVENTS
//#define TEST_VIEW_FIELDS
//#define TEST_FIELD
//#define TEST_USERS
//#define TEST_LOOKUP_FIELDS
#define TEST_SPQUERY
//#define SHOW_INFO
//#define TEST_UPDATE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace TestSharePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            const string
                //requestUrl = "http://nozhenko-s8k/",
                requestUrl = "http://tba/",
                //SPWeb = "DocNet",
                SPWeb = "TBADocNet",
                SPListName = "Чернетки внутрішніх документів", //"Внутрішні документи", //"Задачі", //"TaskReports",
                FieldName = "dn_ct_ProjectDocument";

            using(SPSite spSite = new SPSite(requestUrl))
            {
                #if TEST_UPDATE
                    TestUpdate(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_LOAD_ITEM
                    TestLoadItem(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_FILE
                    TestFile(spSite.AllWebs[SPWeb]);
                #endif

                #if GET_INFO
                    GetInfo(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_DETAIL_VIEW
                    TestDetailView(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_CUSTOM_FIELD
                    TestCustomField(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_CONTENT_TYPE
                    TestContentType(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_EVENTS
                    TestEvents(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_VIEW_FIELDS
                    TestViewFields(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_FIELD
                    TestField(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_USERS
                    SPList spListUsers = spSite.RootWeb.Lists["User Information List" /*"Список відомостей про користувачів"*/ /*"_catalogs/users"*/];
                    ShowFields(spListUsers);
                    SPListItem spListItemUser = spListUsers.GetItemById(1);

                    foreach (SPUser spUser in spSite.AllWebs[SPWeb].AllUsers)
                        Console.WriteLine("{{ID: {0}, Name: {1}, LoginName: {2}}}", spUser.ID, spUser.Name, spUser.LoginName);
                #endif

                #if TEST_LOOKUP_FIELDS
                    TestLookupFields(spSite.AllWebs[SPWeb]);
                #endif

                #if TEST_SPQUERY
                    TestSPQuery(spSite.AllWebs[SPWeb]);
                #endif

                #if SHOW_INFO
                    SPWebCollection
                        spWebCollection = spSite.AllWebs;

                    foreach (SPWeb spWeb in spWebCollection)
                    {
                        Console.WriteLine("Name: \"{0}\"", spWeb.Name);

                        SPListCollection
                            spListCollection = spWeb.Lists;

                        foreach (SPList _spList in spListCollection)
                            Console.WriteLine("\tTitle: \"{0}\"", _spList.Title);
                    }
                #endif

                SPPropertyBag
                    props = spSite.AllWebs[SPWeb].Properties;

                foreach (DictionaryEntry de in props)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
                }

                SPList
                    spList = spSite.AllWebs[SPWeb].Lists[SPListName];

                #if SHOW_INFO
                    foreach (SPField f in spList.Fields)
                        Console.WriteLine("Title: {0}", f.Title);
                #endif

                SPListItemCollection
                    spListItemCollection = spList.Items;

                bool
                    ShowAll = false;

                foreach (SPListItem item in spListItemCollection)
                {
                    if (item[FieldName] != null)
                    {
                        SPFieldLookupValue
                            spFieldLookupValue = (SPFieldLookupValue) item[FieldName];

                        string
                            tmpString = item[FieldName].ToString();

                        Console.WriteLine("{0}\t{1}", tmpString, spFieldLookupValue.LookupId);
                    }

                    if(ShowAll)
                    {
                        Console.WriteLine();
                        foreach (SPField f in item.Fields)
                            Console.WriteLine("\"{0}\" = \"{1}\"", f.Title, item[f.Title]);
                        Console.WriteLine();

                        ShowAll = false;
                    }
                }
            }

            Console.ReadLine();
        }

        static void ShowEventReceivers(SPList spList)
        {
            StreamWriter
                sw = new StreamWriter(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + spList.Title, false, Encoding.GetEncoding(1251));

            sw.AutoFlush = true;

            sw.WriteLine(spList.Title);
            sw.WriteLine();

            foreach (SPEventReceiverDefinition eventReceiverDefinition in spList.EventReceivers)
                sw.WriteLine(string.Format(CultureInfo.InvariantCulture, "Type: [{0}], Assembly: [{1}], Class: [{2}]", eventReceiverDefinition.Type, eventReceiverDefinition.Assembly, eventReceiverDefinition.Class));

            sw.Close();
        }

        static void ShowFields(SPList spList)
        {
            StreamWriter
                sw = new StreamWriter(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + spList.Title, false, Encoding.GetEncoding(1251));

            sw.AutoFlush = true;

            sw.WriteLine(spList.Title);
            sw.WriteLine();

            foreach (SPField field in spList.Fields)
                sw.WriteLine("{{InternalName: {0}, Title: {1}, Description: {2}, Type: {3}}}", field.InternalName, field.Title, field.Description, field.GetType());

            sw.Close();
        }

        static void ShowFields(SPListItem spListItem)
        {
            StreamWriter
                sw = new StreamWriter(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + spListItem.ParentList.Title, false, Encoding.GetEncoding(1251));

            sw.AutoFlush = true;

            sw.WriteLine(spListItem.ParentList.RootFolder);
            sw.WriteLine();

            foreach (SPField field in spListItem.Fields)
                sw.WriteLine("{{InternalName: {0}, Title: {1}, Description: {2}}}", field.InternalName, field.Title, field.Description);

            sw.Close();
        }

        #if TEST_LOOKUP_FIELDS
            static void TestLookupFields(SPWeb spWeb)
            {
                SPList
                    //list = spWeb.Lists["Внутрішні документи"];
                    //list = spWeb.Lists["Підрозділ організації"];
                    list = spWeb.Lists["Рух вхідних документів"];

                SPListItem
                    item = list.Items[0];

                string
                    fieldName = "dn_ct_Recipient";

                SPField
                    //field = item.Fields.GetFieldByInternalName("dn_ct_AuthorExecutor");
                    //field = item.Fields["Автор-виконавець"];
                    field = item.Fields.GetFieldByInternalName(fieldName);

                object tmpObject = item[fieldName];

                SPField spField = item[fieldName] as SPField;
                SPFieldLookup spFieldLookup = item[fieldName] as SPFieldLookup;
                SPFieldLookupValue spFieldLookupValue = item[fieldName] as SPFieldLookupValue;
                SPFieldUser spFieldUser = item[fieldName] as SPFieldUser;
                SPFieldUserValue spFieldUserValue = item[fieldName] as SPFieldUserValue;
                
                if ((spFieldUserValue = field.GetFieldValue(tmpObject.ToString()) as SPFieldUserValue) != null)
                    Console.WriteLine("LookupId: {0}", spFieldUserValue.LookupId);

                SPFieldUserValueCollection spFieldUserValueCollection = item[fieldName] as SPFieldUserValueCollection;
                if((spFieldUserValueCollection=field.GetFieldValue(tmpObject.ToString()) as SPFieldUserValueCollection)!=null)
                    foreach (SPFieldUserValue _spFieldUserValue_ in spFieldUserValueCollection)
                        Console.WriteLine("LookupId: {0}, LookupValue: {1}, User.ID: {2}, User.Name: {3}", _spFieldUserValue_.LookupId, _spFieldUserValue_.LookupValue, _spFieldUserValue_.User.ID, _spFieldUserValue_.User.Name);
            }
        #endif

        #if TEST_SPQUERY
            static void TestSPQuery(SPWeb spWeb)
            {
                string
                    listName,
                    fieldName,
                    fieldNameII,
                    fieldNameIII,
                    fieldNameIV;

                SPList
                    list;

                SPQuery
                    query;

                SPListItemCollection
                    result;

                listName = "Подразделение организации";
                list = spWeb.Lists[listName];
                fieldName = "dn_ct_OrganizationDivisionsDivisionEmployees";
                query = new SPQuery();
                query.Query = string.Format(@"
<Where>
    <Contains>
        <FieldRef Name='{0}' LookupId='True' />
        <Value Type='Integer'>{1}</Value>
    </Contains>
</Where>
"
                , fieldName,
                12);
                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    object
                        tmpObject = item["dn_ct_OrganizationDivisionsDivisionCode"];
                }

                listName = "Шаблоны печатных форм";
                list = spWeb.Lists[listName];
                fieldName = "dn_ct_PrintedFormTemplateCode";
                query = new SPQuery();
                query.Query = string.Format(@"
<Where>
    <Contains>
        <FieldRef Name='{0}'/>
        <Value Type='Text'>{1}</Value>
    </Contains>
</Where>
"
                , fieldName,
                "Incoming_RCC");
                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    SPFile
                        spFile = item.File;

                    byte[]
                        file = spFile.OpenBinary();
                }

                listName = "Чернетки вхідних документів";
                list = spWeb.Lists[listName];
                fieldName = "ContentTypeId"; // FieldMetadata.ContentTypeIdInternalName
                fieldNameII = "ContentType"; // FieldMetadata.ContentTypeInternalName
                query = new SPQuery();
                query.Query = string.Format(@"
<Where>
    <BeginsWith>
        <FieldRef Name='{0}'/>
        <Value Type='Choice'>{1}</Value>
    </BeginsWith>
</Where>
"
                , fieldName,
                "0x0100D2C12FDA49D846B7BBD35F661088B3EA007D4CED701F8B4D7483806C2393C6CDEB" /*ContentTypeMetadata.CitizenAppealProjectContentTypeId*/);
                 
                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldNameII);

                    object
                        tmpObject = field.GetFieldValue((string) item[fieldNameII]);

                    if (tmpObject != null)
                        ;
                        
                    Console.WriteLine("{{ID: {0}, {1}: {2}, {3}: {4}}}",
                        item.ID,
                        fieldNameII,
                        item[fieldNameII],
                        fieldName,
                        item[fieldName]);
                }

                listName = "Чернетки вхідних документів";
                list = spWeb.Lists[listName];
                fieldName = "ContentTypeId"; // FieldMetadata.ContentTypeIdInternalName
                fieldNameII = "ContentType"; // FieldMetadata.ContentTypeInternalName
                query = new SPQuery();
                query.Query = string.Format(@"
<Where>
    <Or>
        <BeginsWith>
            <FieldRef Name='{0}'/>
            <Value Type='Choice'>{1}</Value>
        </BeginsWith>
        <BeginsWith>
            <FieldRef Name='{0}'/>
            <Value Type='Choice'>{2}</Value>
        </BeginsWith>
    </Or>
</Where>
"
                , fieldName,
                "0x0100D2C12FDA49D846B7BBD35F661088B3EA00AEDA8C185B5E48FCA1D32347189F100E" /*ContentTypeMetadata.IncomingDocumentProjectContentTypeId*/,
                "0x0100D2C12FDA49D846B7BBD35F661088B3EA00ED44EBCA97D449E3B8D3FDF9E7318BA7" /*ContentTypeMetadata.CitizenProjectContentTypeId*/);

                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldNameII);

                    object
                        tmpObject = field.GetFieldValue((string)item[fieldNameII]);

                    if (tmpObject != null)
                        ;

                    Console.WriteLine("{{ID: {0}, {1}: {2}, {3}: {4}}}",
                        item.ID,
                        fieldNameII,
                        item[fieldNameII],
                        fieldName,
                        item[fieldName]);
                }

                listName = "Чернетки вхідних документів";
                list = spWeb.Lists[listName];
                fieldName = "ContentTypeId"; // FieldMetadata.ContentTypeIdInternalName
                fieldNameII = "ContentType"; // FieldMetadata.ContentTypeInternalName
                query = new SPQuery();
                query.Query = string.Format(@"
<Where>
    <Or>
        <Or>
            <BeginsWith>
                <FieldRef Name='{0}'/>
                <Value Type='Choice'>{1}</Value>
            </BeginsWith>
            <BeginsWith>
                <FieldRef Name='{0}'/>
                <Value Type='Choice'>{2}</Value>
            </BeginsWith>
        </Or>
        <BeginsWith>
            <FieldRef Name='{0}'/>
            <Value Type='Choice'>{3}</Value>
        </BeginsWith>
    </Or>
</Where>
"
                , fieldName,
                "0x0100D2C12FDA49D846B7BBD35F661088B3EA00AEDA8C185B5E48FCA1D32347189F100E" /*ContentTypeMetadata.IncomingDocumentProjectContentTypeId*/,
                "0x0100D2C12FDA49D846B7BBD35F661088B3EA00ED44EBCA97D449E3B8D3FDF9E7318BA7" /*ContentTypeMetadata.CitizenProjectContentTypeId*/,
                "0x0100D2C12FDA49D846B7BBD35F661088B3EA007D4CED701F8B4D7483806C2393C6CDEB" /*ContentTypeMetadata.CitizenAppealProjectContentTypeId*/);

                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldNameII);

                    object
                        tmpObject = field.GetFieldValue((string)item[fieldNameII]);

                    if (tmpObject != null)
                        ;

                    Console.WriteLine("{{ID: {0}, {1}: {2}, {3}: {4}}}",
                        item.ID,
                        fieldNameII,
                        item[fieldNameII],
                        fieldName,
                        item[fieldName]);
                }

                listName = "Чернетки внутрішніх документів";
                list = spWeb.Lists[listName];
                fieldName = "dn_ct_ProjectDocument";
                query = new SPQuery();
                query.ViewFields = string.Format("<FieldRef Name='{0}' />", fieldName);
                result = list.GetItems(query);
                foreach (SPListItem item in result)
                    Console.WriteLine("{{ID: {0}, {1}: {2}}}", item.ID, fieldName, item[fieldName]);

                listName = "Задачі";
                list = spWeb.Lists[listName];
                fieldName = "ContentTypeId"; // FieldMetadata.ContentTypeIdInternalName
                fieldNameII = "ContentType"; // FieldMetadata.ContentTypeInternalName
                query = new SPQuery();
                query.Query = string.Format(@"
<Where>
    <And>
        <BeginsWith>
            <FieldRef Name='{0}'/>
            <Value Type='Choice'>{1}</Value>
        </BeginsWith>
        <Eq>
            <FieldRef Name='dn_MainExecutor'/>
            <Value Type='Integer'>1</Value>
        </Eq>
    </And>
</Where>
"
                , fieldName,
                "0x010800C5FAF5E5260347459C440170C534AABC00CF82612503964813A9D048DD228352F8" /*ContentTypeMetadata.ExecutionResolutionTaskContentTypeId*/);
                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldNameII);

                    object
                        tmpObject = field.GetFieldValue((string) item[fieldNameII]);

                    if (tmpObject != null)
                        ;
                        
                    Console.WriteLine("{{ID: {0}, {1}: {2}, {3}: {4}}}",
                        item.ID,
                        fieldNameII,
                        item[fieldNameII],
                        fieldName,
                        item[fieldName]);
                }

                listName = "Вхідні документи [v2]";
                list = spWeb.Lists[listName];
                fieldName = "dn_ct_RegNumber";
                query=new SPQuery();
                query.Query = String.Format(CultureInfo.InvariantCulture, @"
<Where>
    <IsNotNull>
        <FieldRef Name='{0}'/>
    </IsNotNull>
</Where>
"
                    , fieldName);

                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    Console.WriteLine("{{ID: {0}, {1}: {2}}}",
                        item.ID,
                        fieldName,
                        item[fieldName]);
                }

                listName = "Вхідні документи [v2]";
                list = spWeb.Lists[listName];
                fieldName = "dn_ct_RegNumber";
                query = new SPQuery();
                query.Query = String.Format(CultureInfo.InvariantCulture, @"
<Where>
    <IsNull>
        <FieldRef Name='{0}'/>
    </IsNull>
</Where>
"
                    , fieldName);

                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    Console.WriteLine("{{ID: {0}, {1}: {2}}}",
                        item.ID,
                        fieldName,
                        item[fieldName]);
                }

                listName = "Задачі";
                list = spWeb.Lists[listName];
                fieldName = "ContentTypeId"; // FieldMetadata.ContentTypeIdInternalName
                fieldNameII = "WorkflowListId";
                fieldNameIII = "WorkflowItemId";
                fieldNameIV = "ContentTypeId"; // Need for item.ContentType
                query = new SPQuery();

                query.ViewFields = string.Format(CultureInfo.InvariantCulture, @"

<FieldRef Name='{0}' />
<FieldRef Name='{1}' />
<FieldRef Name='{2}' />
"
                    , fieldNameII,
                    fieldNameIII,
                    fieldNameIV);

                query.Query = string.Format(@"
<Where>
    <BeginsWith>
        <FieldRef Name='{0}'/>
        <Value Type='Choice'>{1}</Value>
    </BeginsWith>
</Where>
"
                , fieldName,
                "0x010800C5FAF5E5260347459C440170C534AABC00CF82612503964813A9D048DD228352F8" /*ContentTypeMetadata.ExecutionResolutionTaskContentTypeId*/);

                result = list.GetItems(query);
                foreach (SPListItem item in result)
                {
                    Console.WriteLine("{{ID: {0}, {1}: {2}, {3}: {4}}}",
                        item.ID,
                        fieldNameII,
                        item[fieldNameII],
                        fieldNameIII,
                        item[fieldNameIII]);
                }
            }
        #endif

        #if TEST_FIELD
            static void TestField(SPWeb spWeb)
            {
                Console.WriteLine("TestField() started...");

                string
                    listName = "Индексы корреспондентов",
                    fieldName = "dn_CorrespondentIndexCode";

                SPListItem
                    item = spWeb.Lists[listName].Items[0];

                SPField
                    field = item.Fields.GetFieldByInternalName(fieldName);

                return;

                string
                    listNameFrom = "Чернетки вхідних документів",
                    listNameTo = "Вхідні документи [v2]";

                fieldName = "dn_ct_CitizenExecutedActions";

                SPListItem
                    itemFrom = spWeb.Lists[listNameFrom].Items[0];

                int?
                    docId;

                if ((docId = GetFieldLookupValue(itemFrom, "dn_ct_IncomingDocProjectDocument")).HasValue)
                {
                    SPListItem
                        itemTo;

                    try
                    {
                        itemTo = spWeb.Lists[listNameTo].GetItemById(docId.Value);

                        foreach (SPField fromField in itemFrom.Fields)
                        {
                            Guid fieldId = fromField.Id;
                            if (SPBuiltInFieldId.Contains(fieldId))
                                continue;

                            SPField toField;
                            if(!GetFieldByID(itemTo.Fields, fieldId, out toField))
                                continue;

                            try
                            {
                                object
                                    tmpObject = itemFrom[fieldId];
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("{0}", fromField.InternalName);
                            }
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Doc: {0} - doesn't exist", docId.Value);
                    }
                }

                Console.WriteLine("TestField() finished");
                Console.WriteLine();
            }
        #endif

        #if TEST_VIEW_FIELDS
            static void TestViewFields(SPWeb spWeb)
            {
                string
                    methodName = "TestViewFields";

                Console.WriteLine(string.Format("{0}() started...", methodName));

                string
                    listName = "Задачі",
                    fieldName = "dn_ContentTypeDoc";

                SPList
                    list = spWeb.Lists[listName];

                SPQuery
                    query=new SPQuery();

                query.Query = string.Format(CultureInfo.InvariantCulture, @"
<Where>
    <BeginsWith>
        <FieldRef Name='{0}'/>
        <Value Type='Choice'>{1}</Value>
    </BeginsWith>
</Where>
"
                , "ContentTypeId",
                "0x010800C5FAF5E5260347459C440170C534AABC00CF82612503964813A9D048DD228352F8");

                query.ViewFields = string.Format(@"
<FieldRef Name='{0}' />
<FieldRef Name='{1}' />
<FieldRef Name='{2}' />
"
                    , "WorkflowListId",
                    "WorkflowItemId",
                    fieldName);

                SPListItemCollection
                    result = list.GetItems(query);

                foreach (SPListItem item in result)
                {
                    item[fieldName] = "blah-blah-blah";
                    item.SystemUpdate(false);
                }

                Console.WriteLine(string.Format("{0}() finished", methodName));
                Console.WriteLine();
            }
        #endif

        #if TEST_EVENTS
            static void TestEvents(SPWeb spWeb)
            {
                string
                    methodName = "TestEvents";

                Console.WriteLine(string.Format("{0}() started...", methodName));

                #if SHOW_INFO
                    foreach (SPList list in spWeb.Lists)
                        ShowEventReceivers(list);
                #endif

                string
                    listName = "Задачі";

                SPList
                    list = spWeb.Lists[listName];

                List<SPEventReceiverDefinition>
                    storeEventRecievers = new List<SPEventReceiverDefinition>(),
                    eventReceivers = list.EventReceivers.Cast<SPEventReceiverDefinition>().ToList();

                foreach (SPEventReceiverDefinition spEventReceiverDefinition in eventReceivers)
                {
                    if(string.IsNullOrEmpty(spEventReceiverDefinition.Class))
                        continue;
                    
                    storeEventRecievers.Add(spEventReceiverDefinition);
                    spEventReceiverDefinition.Delete();
                }

                foreach (SPEventReceiverDefinition spEventReceiverDefinition in storeEventRecievers)
                    list.EventReceivers.Add(spEventReceiverDefinition.Type, spEventReceiverDefinition.Assembly, spEventReceiverDefinition.Class);

                Console.WriteLine(string.Format("{0}() finished", methodName));
                Console.WriteLine();
            }
        #endif

        #if TEST_CONTENT_TYPE
            static void TestContentType(SPWeb spWeb)
            {
                foreach(SPContentType contentType in spWeb.AvailableContentTypes)
                {
                    SPContentTypeId
                        ItemContentTypeId = new SPContentTypeId("0x01"),
                        MovingContentTypeId = new SPContentTypeId("0x010036C09CCB6A04462589FAF08349A3FB96"),
                        IncomingDocProjectMovingContentTypeId = new SPContentTypeId("0x010036C09CCB6A04462589FAF08349A3FB96002479A5F6DE3147b38F01AD5857AC159B"),
                        IncomingDocMovingContentTypeId = new SPContentTypeId("0x010036C09CCB6A04462589FAF08349A3FB9600F982305F9274494b83ECC7EFD1AA07E8");

                    if (contentType.Id != ItemContentTypeId
                        && contentType.Id != MovingContentTypeId
                        && contentType.Id != IncomingDocProjectMovingContentTypeId
                        && contentType.Id != IncomingDocMovingContentTypeId)
                        continue;

                    Console.WriteLine("{0} {1}", contentType.Id, contentType.Name);
                    Console.WriteLine("Fields:");
                    foreach (SPField field in contentType.Fields)
                        Console.WriteLine("{0} {1}", field.Title, field.Id);
                    Console.WriteLine();
                }

                ShowFields(spWeb.Lists["Рух чернеток вхідних документів"]);
                ShowFields(spWeb.Lists["Рух вхідних документів"]);

                string
                    listName = "TaskReports", //"Чернетки вхідних документів",
                    fieldName = "ContentType";

                SPList
                    list = spWeb.Lists[listName];

                foreach (SPListItem item in list.Items)
                {
                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldName);

                    object
                        tmpObject = item[fieldName],
                        tmpObjectII = field.GetFieldValue((string) item[fieldName]);

                    SPFieldChoice
                        spFieldChoice = tmpObjectII as SPFieldChoice;

                    SPContentType
                        spContentType = item.ContentType;
                }
            }
        #endif

        #if TEST_CUSTOM_FIELD
            static void TestCustomField(SPWeb spWeb)
            {
                string
                    listName = "Чернетки внутрішніх документів",
                    fieldName = "dn_ct_OrderItems";

                SPList
                    list = spWeb.Lists[listName];

                SPQuery
                    query = new SPQuery();

                query.Query = String.Format(CultureInfo.InvariantCulture, @"
<Where>
    <BeginsWith>
        <FieldRef Name='{0}'/>
        <Value Type='Choice'>{1}</Value>
    </BeginsWith>
</Where>
"
                    , "ContentTypeId",
                    "0x0100D2C12FDA49D846B7BBD35F661088B3EA003ED2EE2E00D040C08D6963B979B0DCDC006B798FA3EBA64BC089AF9C6D9AEF757E00233CFF7F13094FF2915ED5E8F627747A");

                SPListItemCollection
                    result = list.GetItems(query);

                foreach (SPListItem item in result)
                {
                    SPContentType
                        spContentType = item.ContentType;

                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldName);

                    object
                        tmpObject = item[fieldName],
                        tmpObjectII = field.GetFieldValue((string)item[fieldName]);
                }
            }
        #endif

        #if TEST_DETAIL_VIEW
            static void TestDetailView(SPWeb spWeb)
            {
                SPList
                    listMaster = spWeb.Lists["Чернетки вхідних документів"],
                    listDetail = spWeb.Lists["Рух чернеток вхідних документів"];

                string
                    fieldNameInMaster = "dn_ct_Movings",
                    fieldNameInDetail = "dn_ct_Parent",
                    fieldNameExecutionResult = "dn_ct_ExecutionResult";

                foreach (SPListItem item in listMaster.Items)
                {

                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldNameInMaster);
                }

                foreach (SPListItem item in listDetail.Items)
                {
                    SPField
                        field = item.Fields.GetFieldByInternalName(fieldNameInDetail);

                    SPFieldLookupValue
                        spFieldLookupValue = (SPFieldLookupValue) item[fieldNameInDetail];

                    field = item.Fields.GetFieldByInternalName(fieldNameExecutionResult);

                    object
                        tmpObject = field.GetFieldValue((string) item[fieldNameExecutionResult]);

                    spFieldLookupValue = (SPFieldLookupValue) tmpObject;
                }
            }
        #endif

        #if GET_INFO
            static void GetInfo(SPWeb spWeb)
            {
                SPList
                    list = spWeb.Lists["Вхідні документи [v2]"];

                ShowFields(list);
            }
        #endif

        #if TEST_FILE
            static void TestFile(SPWeb spWeb)
            {
                try
                {
                    string
                        listName = "Внутрішні документи";

                    SPList
                        list = spWeb.Lists[listName];

                    int
                        id = 1;

                    SPListItem
                        item = list.GetItemById(id);

                    Console.WriteLine("{0}/{1}", spWeb.Url, item.Url);

                    foreach (SPListItemVersion spListItemVersion in item.Versions)
                        Console.WriteLine("{0} {1}", spListItemVersion.VersionId, spListItemVersion.Level);

                    SPFile
                        spFile = item.File;

                    Console.WriteLine("UIVersion: {1}{0}UIVersionLabel: {2}{0}Url: \"{3}\"{0}ServerRelativeUrl: \"{4}\"", Environment.NewLine, spFile.UIVersion, spFile.UIVersionLabel, spFile.Url, spFile.ServerRelativeUrl);

                    byte[]
                        pdf = spFile.OpenBinary();
                }
                catch(Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        #endif

        #if TEST_LOAD_ITEM
            static void TestLoadItem(SPWeb spWeb)
            {
                try
                {
                    SPList
                        spList = spWeb.Lists.GetList(new Guid("776ec18f-ba56-4e38-aea9-125262c6afe0"), false);

                    SPListItem
                        spListItem;

                    Console.WriteLine(string.Format("{0} {1} \"{2}\"", (spListItem = spList.GetItemById(1)) != null ? "oB!" : "tampax!", spListItem != null ? spListItem.ID.ToString() : "null", spListItem != null ? spListItem.Title : "null"));
                }
                catch(Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        #endif

        #if TEST_UPDATE
            static void TestUpdate(SPWeb spWeb)
            {
                try
                {
                    Console.WriteLine(spWeb.AllowUnsafeUpdates);

                    string
                        listName = "Чернетки внутрішніх документів";

                    SPList
                        list = spWeb.Lists[listName];

                    int
                        id = 1;

                    SPListItem
                        item = list.GetItemById(id);

                    string
                        value = string.Format("{0} ({1})",(string)item["dn_ct_Text"],DateTime.Now.ToString());

                    item["dn_ct_Text"] = value;
                    item.Update();
                    //spListItem.SystemUpdate();
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        #endif

        static bool GetFieldByID(SPFieldCollection fields, Guid id, out SPField field)
        {
            field = null;

            foreach (SPField f in fields)
            {
                if(f.Id==id)
                {
                    field = f;
                    return true;
                }
            }

            return false;
        }

        static int? GetFieldUserValue(SPListItem item, string fieldName)
        {
            int?
                value = null;

            SPField
                field = item.Fields.GetFieldByInternalName(fieldName);

            SPFieldUserValue
                spFieldUserValue;

            if((spFieldUserValue = field.GetFieldValue((string)item[fieldName]) as SPFieldUserValue)!=null)
                value = spFieldUserValue.LookupId;

            return value;
        }

        static int? GetFieldLookupValue(SPListItem item, string fieldName)
        {
            int?
                value = null;

            SPFieldLookupValue
                spFieldLookupValue;

            if ((spFieldLookupValue = item[fieldName] as SPFieldLookupValue) != null)
                value = spFieldLookupValue.LookupId;

            return value;
        }
    }
}
