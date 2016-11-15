using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseTest
{
    [TestClass()]
    public class TestProcedureWParametersUnitTest : SqlDatabaseTestClass
    {

        public TestProcedureWParametersUnitTest()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_TestProcedureWParametersTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestProcedureWParametersUnitTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition ReturnValue;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition OutputParam;
            this.dbo_TestProcedureWParametersTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_TestProcedureWParametersTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ReturnValue = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OutputParam = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_TestProcedureWParametersTest_TestAction
            // 
            dbo_TestProcedureWParametersTest_TestAction.Conditions.Add(ReturnValue);
            dbo_TestProcedureWParametersTest_TestAction.Conditions.Add(OutputParam);
            resources.ApplyResources(dbo_TestProcedureWParametersTest_TestAction, "dbo_TestProcedureWParametersTest_TestAction");
            // 
            // ReturnValue
            // 
            ReturnValue.ColumnNumber = 1;
            ReturnValue.Enabled = true;
            ReturnValue.ExpectedValue = "0";
            ReturnValue.Name = "ReturnValue";
            ReturnValue.NullExpected = false;
            ReturnValue.ResultSet = 1;
            ReturnValue.RowNumber = 1;
            // 
            // OutputParam
            // 
            OutputParam.ColumnNumber = 2;
            OutputParam.Enabled = true;
            OutputParam.ExpectedValue = "26";
            OutputParam.Name = "OutputParam";
            OutputParam.NullExpected = false;
            OutputParam.ResultSet = 1;
            OutputParam.RowNumber = 1;
            // 
            // dbo_TestProcedureWParametersTestData
            // 
            this.dbo_TestProcedureWParametersTestData.PosttestAction = null;
            this.dbo_TestProcedureWParametersTestData.PretestAction = null;
            this.dbo_TestProcedureWParametersTestData.TestAction = dbo_TestProcedureWParametersTest_TestAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void dbo_TestProcedureWParametersTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_TestProcedureWParametersTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions dbo_TestProcedureWParametersTestData;
    }
}
