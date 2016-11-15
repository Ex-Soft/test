#define TEST_VARBINARY
//#define TEST_QUERY
//#define TEST_COMPARER
#define TEST_TABLE_4_TYPES
//#define TEST_ON_PROPERTY_CHANGED
//#define TEST_SESSION

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo.Metadata.Helpers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace TestDataTable
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            string
                tmpString;

            /*
            string
                sqlConn = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");
                sqlConn = MSSqlConnectionProvider.GetConnectionString("NOZHENKO-I-XP\\SQLEXPRESS", "testdb");

            XpoDefault.DataLayer = XpoDefault.GetDataLayer(sqlConn, AutoCreateOption.DatabaseAndSchema);
            */

            /*
            Staff
                staff = new Staff(XpoDefault.Session) { Name = "Test", Salary = 10, Dep = 1, BirthDate = DateTime.Now, NullField = 123 };

            staff.Save();
            */

            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");
            //XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("NOZHENKO-I-XP\\SQLEXPRESS", "testdb");

            Session
                session = new Session();

            #if TEST_QUERY
                // https://documentation.devexpress.com/#CoreLibraries/CustomDocument4060
                // https://www.devexpress.com/Support/Center/Example/Details/E1883
                var res = (from master in new XPQuery<TestMaster>(session)
                           join detail in new XPQuery<TestDetail>(session) on master/*.Id*/ equals detail.Master/*.Id*/
                           where master.Id == 1
                           select new
                           {
                               Id = master.Id,
                               Name = detail.Name
                           }).ToList();

            #endif
            #if TEST_COMPARER
                List<Staff>
                    listStaff1 = session.GetObjects(session.GetClassInfo(typeof(Staff)), CriteriaOperator.Parse("Id=?", 1), null, 0, 0, true, true).OfType<Staff>().ToList(),
                    listStaff2 = session.GetObjects(session.GetClassInfo(typeof(Staff)), CriteriaOperator.Parse("Id=?", 1), null, 0, 0, true, true).OfType<Staff>().ToList();

                var intersect = listStaff1.Intersect(listStaff2).ToList();
                var except = listStaff1.Except(listStaff2).ToList();
                var sequenceEqual = listStaff1.SequenceEqual(listStaff2);

                Session
                    session1 = new Session(),
                    session2 = new Session();

                listStaff1 = session1.GetObjects(session1.GetClassInfo(typeof(Staff)), CriteriaOperator.Parse("Id=?", 1), null, 0, 0, true, true).OfType<Staff>().ToList();
                listStaff2 = session2.GetObjects(session2.GetClassInfo(typeof(Staff)), CriteriaOperator.Parse("Id=?", 1), null, 0, 0, true, true).OfType<Staff>().ToList();

                intersect = listStaff1.Intersect(listStaff2).ToList();
                intersect = listStaff1.Intersect(listStaff2, new StaffEqualityComparerById()).ToList();
                except = listStaff1.Except(listStaff2).ToList();
                except = listStaff1.Except(listStaff2, new StaffEqualityComparerById()).ToList();
                sequenceEqual = listStaff1.SequenceEqual(listStaff2, new StaffEqualityComparerById());
            #endif

            session.IdentityMapBehavior = IdentityMapBehavior.Weak;

            XPClassInfo
                classInfoMasterDetail = session.GetClassInfo(typeof(TestMaster));

            #if TEST_SESSION
                XPClassInfo
                    classInfoTestDetail = session.GetClassInfo(typeof (TestDetail));

                session.ObjectLoaded += session_ObjectLoaded;

                session.GetObjectsByKey(classInfoTestDetail, new List<object> { 4L, 5L, 6L }, true);

                TestMaster
                    testMaster = session.GetObjectByKey<TestMaster>(2L, false);

                if (testMaster != null)
                {
                    session.PreFetch(new[] { testMaster }, "Details");

                    foreach (TestDetail testDetail in testMaster.Details)
                        tmpString = testDetail.Name;
                }
            #endif

            #if TEST_TABLE_4_TYPES
                TestTable4Types
                    testTable4Types;

                #if TEST_VARBINARY
                    byte[]
                        dataI = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7 },
                        dataII = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

                    if ((testTable4Types = session.GetObjectByKey<TestTable4Types>(1L, true)) != null)
                    {
                        if (testTable4Types.VarBinary28 == null || testTable4Types.VarBinary28.Length == 0)
                        {
                            testTable4Types.VarBinary28 = dataI;
                            testTable4Types.Save();
                        }
                    }

                    if ((testTable4Types = session.GetObjectByKey<TestTable4Types>(2L, true)) != null)
                    {
                        if (testTable4Types.VarBinary28 == null || testTable4Types.VarBinary28.Length == 0)
                        {
                            testTable4Types.VarBinary28 = dataI;
                            testTable4Types.Save();
                        }
                    }

                    if ((testTable4Types = session.GetObjectByKey<TestTable4Types>(3L, true)) != null)
                    {
                        if (testTable4Types.VarBinary28 == null || testTable4Types.VarBinary28.Length == 0)
                        {
                            testTable4Types.VarBinary28 = dataII;
                            testTable4Types.Save();
                        }
                    }

                    var arrDataI = session.GetObjects(session.GetClassInfo(typeof(TestTable4Types)), new BinaryOperator(new OperandProperty("VarBinary28"), new OperandValue(dataI), BinaryOperatorType.Equal), null, 0, 0, false, true).OfType<TestTable4Types>().ToArray();
                    var arrDataII = session.GetObjects(session.GetClassInfo(typeof(TestTable4Types)), new BinaryOperator(new OperandProperty("VarBinary28"), new OperandValue(dataII), BinaryOperatorType.Equal), null, 0, 0, false, true).OfType<TestTable4Types>().ToArray();
                #endif

                if ((testTable4Types = session.GetObjectByKey<TestTable4Types>(1L, true)) != null)
                {
                    tmpString = testTable4Types.Doc.InnerXml;

                    XmlNodeList roots = testTable4Types.Doc.GetElementsByTagName("root");
                    XmlNode root = roots != null && roots.Count > 0 ? roots[0] : null;

                    if (root != null)
                    {
                        XmlElement newItem = testTable4Types.Doc.CreateElement("item");
                        XmlAttribute newItemAttribute = testTable4Types.Doc.CreateAttribute("id");
                        XmlText newItemText = testTable4Types.Doc.CreateTextNode((11 * (root.ChildNodes.Count + 1)).ToString());

                        newItemAttribute.Value = (root.ChildNodes.Count + 1).ToString();
                        newItem.Attributes.Append(newItemAttribute);
                        newItem.AppendChild(newItemText);

                        root.AppendChild(newItem);
                    }

                    testTable4Types.Save();

                    var _root_ = testTable4Types.Doc.SelectNodes("/root");
                    var __root__ = testTable4Types.Doc.SelectSingleNode("/root");
                }
            #endif

            Staff
                staff;

            XPClassInfo
                classInfoStaff = session.GetClassInfo(typeof(Staff)),
                classInfoTestTable4Types = session.GetClassInfo(typeof(TestTable4Types));

            XPMemberInfo
                memberInfoSalary = classInfoStaff.GetPersistentMember("Salary");

            if (memberInfoSalary.MemberType.ReflectedType == typeof (XPObjectType))
                tmpString = memberInfoSalary.MemberType.FullName;

            ICollection
                collection;

            try
            {
                collection = session.GetObjectsByKey(classInfoStaff, null, true);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            collection = session.GetObjectsByKey(classInfoStaff, new List<object>(), true);
            collection = session.GetObjectsByKey(classInfoStaff, new List<object> { 1L }, true);

            if ((staff = session.FindObject(typeof(Staff), CriteriaOperator.Parse("Id=?", 1)) as Staff) != null)
            {
                tmpString = staff.Name;

                var pName = staff.ClassInfo.FindMember("Name");

                if(pName!=null)
                {
                    var name = staff.GetMemberValue("Name");
                }

                var m = staff.ClassInfo.Members.Where(mi => mi.MemberType.FullName=="System.String").Select(mi => mi).ToList();
                var cp = staff.ClassInfo.CollectionProperties.Cast<XPMemberInfo>()/*.Where(mi => mi.MemberType.FullName == "System.String")*/.Select(mi => mi).ToList();
                var op = staff.ClassInfo.ObjectProperties.Cast<XPMemberInfo>().Where(mi => mi.MemberType.FullName == "System.String").Select(mi => mi).ToList();
                var pp = staff.ClassInfo.PersistentProperties.Cast<XPMemberInfo>().Where(mi => mi.MemberType.FullName == "System.String").Select(mi => mi).ToList();
                var up = staff.ClassInfo.PersistentProperties.Cast<XPMemberInfo>().FirstOrDefault(mi => mi.Attributes.Any(a => a is UniqueAttribute));

                #if TEST_ON_PROPERTY_CHANGED
                    staff.Name = tmpString;
                #endif
            }

            if ((staff = session.FindObject(typeof(Staff), CriteriaOperator.Parse("Id=?", 111)) as Staff) != null)
                tmpString = staff.Name;

            var _cp_ = classInfoMasterDetail.CollectionProperties;

            XPServerCollectionSource
                xpServerCollectionSourceStaff = new XPServerCollectionSource(session, classInfoStaff),
                xpServerCollectionSourceMasterDetail = new XPServerCollectionSource(session, classInfoMasterDetail);

            CriteriaOperator
                joinCriteria = new OperandProperty("^.Master")==new OperandProperty("Id");

            JoinOperand
                joinOperand = new JoinOperand("TestMaster", joinCriteria);

            XPCollection<TestDetail>
                s = new XPCollection<TestDetail>(session, joinOperand);

            /*
            select
                *
            from
                "dbo"."TestDetail" N0
            where
            (
                N0."GCRecord" is null
                and exists
                (
                    select * from "dbo"."TestMaster" N1 where (N1."GCRecord" is null and (N0."IdMaster" = N1."Id"))
                )
            )
            */

            foreach (TestDetail d in s)
            {
                
            }

            gridControlStaff.DataSource = xpServerCollectionSourceStaff;
            
            gridViewStaff.OptionsSelection.MultiSelect = true;

            gridViewStaff.Appearance.SelectedRow.BackColor = Color.FromArgb(192, 192, 255);
            gridViewStaff.Appearance.SelectedRow.BackColor2 = Color.Transparent;
            gridViewStaff.Appearance.SelectedRow.Options.UseBackColor = true;

            //gridControlStaff.MainView.ExportToXls("test.xls");
            //gridControlStaff.MainView.ExportToXlsx("test.xlsx");
            gridControlMasterDetail.DataSource = xpServerCollectionSourceMasterDetail;
            gridControlADOdotNETDataTable.DataSource = GetDataTable();

            gridControlTestTable4Types.DataSource = new XPCollection(session, typeof (TestTable4Types));
        }

        private void GridViewTestTable4TypesCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CellValueChanged");
        }

        private void GridViewTestTable4TypesCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("CustomRowCellEdit");
        }

        private void GridViewTestTable4TypesCustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CustomRowCellEditForEditing");
        }

        private void GridViewTestTable4TypesHiddenEditor(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("HiddenEditor");
        }

        private void GridViewTestTable4TypesShownEditor(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ShownEditor");
        }

        void session_ObjectLoaded(object sender, ObjectManipulationEventArgs e)
        {
            if (e == null)
                return;
        }

        DataTable GetDataTable()
        {
            DataTable
                tmpDataTable = new DataTable("TableName", "TableNamespace");

            DataColumn
                tmpDataColumn;

            string
                idPropertyName = "id";

            tmpDataColumn = tmpDataTable.Columns.Add(idPropertyName, typeof(long));
            tmpDataColumn.AllowDBNull = false;
            tmpDataColumn.Unique = true;
            tmpDataColumn.AutoIncrement = true;
            tmpDataColumn.AutoIncrementSeed = -1;
            tmpDataColumn.AutoIncrementStep = -1;
            tmpDataColumn.Caption = "Идентификатор";
            tmpDataTable.Columns.Add("Name", typeof(string)).Caption="Ф.И.О.";
            tmpDataTable.Columns.Add("Salary", typeof(decimal)).Caption="Зряплата";
            tmpDataTable.Columns.Add("Dep", typeof(int)).Caption="Отдел";
            tmpDataTable.Columns.Add("BirthDate", typeof(DateTime)).Caption="ДР";
            tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns[idPropertyName] };

            DataRow
                tmpDataRow;

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Иванов Иван Иванович";
            tmpDataRow["Salary"] = 100;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1870, 4, 22);
            tmpDataTable.Rows.Add(tmpDataRow);

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Петров Петр Петрович";
            tmpDataRow["Salary"] = 1000;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1878, 12, 18);
            tmpDataTable.Rows.Add(tmpDataRow);

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Сидоров Сидор Сидорович";
            tmpDataRow["Salary"] = 100;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1894, 4, 17);
            tmpDataTable.Rows.Add(tmpDataRow);

            return tmpDataTable;
        }

        private void gridViewADOdotNETDataTable_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null || e.RowHandle<0)
                return;

            DataRowView dataRowView = view.GetRow(e.RowHandle) as DataRowView;

            if (dataRowView == null)
                return;

            string idPropertyName = "id";
            DataRow row = dataRowView.Row;

            if (row == null || !row.Table.Columns.Contains(idPropertyName))
                return;

            if (Math.Abs(Convert.ToInt64(row[idPropertyName]))%2 == 0)
            {
                AppearanceObject appearanceObject = new AppearanceObject();
                appearanceObject.BackColor = Color.Red;
                appearanceObject.ForeColor = Color.White;
                if ((e.State & GridRowCellState.Focused) == GridRowCellState.Focused)
                    appearanceObject.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.CombineAppearance(appearanceObject);
            }
        }
    }

    public class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _compareFunc;
        private readonly Func<T, int> _hashFunc;

        public GenericEqualityComparer(Func<T, T, bool> compareFunc)
        {
            _compareFunc = compareFunc;
        }

        public GenericEqualityComparer(Func<T, T, bool> compareFunc, Func<T, int> hashFunc)
            : this(compareFunc)
        {
            _compareFunc = compareFunc;
            _hashFunc = hashFunc;
        }

        public bool Equals(T x, T y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return _compareFunc(x, y);
        }

        public int GetHashCode(T obj)
        {
            return _hashFunc != null ? _hashFunc(obj) : obj.GetHashCode();
        }
    }

    public class StaffEqualityComparerById : GenericEqualityComparer<Staff>
    {
        public StaffEqualityComparerById() : base((x, y) => x.Id == y.Id, x => x.Id.GetHashCode())
        {}
    }
}