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
    public class CLRProcedureWithOutputParametersUnitTest : SqlDatabaseTestClass
    {

        public CLRProcedureWithOutputParametersUnitTest()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_CLRProcedureWithOutputParametersTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLRProcedureWithOutputParametersUnitTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition ReturnValue;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition OutParam;
            this.dbo_CLRProcedureWithOutputParametersTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_CLRProcedureWithOutputParametersTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ReturnValue = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            OutParam = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_CLRProcedureWithOutputParametersTestData
            // 
            this.dbo_CLRProcedureWithOutputParametersTestData.PosttestAction = null;
            this.dbo_CLRProcedureWithOutputParametersTestData.PretestAction = null;
            this.dbo_CLRProcedureWithOutputParametersTestData.TestAction = dbo_CLRProcedureWithOutputParametersTest_TestAction;
            // 
            // dbo_CLRProcedureWithOutputParametersTest_TestAction
            // 
            dbo_CLRProcedureWithOutputParametersTest_TestAction.Conditions.Add(ReturnValue);
            dbo_CLRProcedureWithOutputParametersTest_TestAction.Conditions.Add(OutParam);
            resources.ApplyResources(dbo_CLRProcedureWithOutputParametersTest_TestAction, "dbo_CLRProcedureWithOutputParametersTest_TestAction");
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
            // OutParam
            // 
            OutParam.ColumnNumber = 2;
            OutParam.Enabled = true;
            OutParam.ExpectedValue = "1 1";
            OutParam.Name = "OutParam";
            OutParam.NullExpected = false;
            OutParam.ResultSet = 1;
            OutParam.RowNumber = 1;
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
        public void dbo_CLRProcedureWithOutputParametersTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_CLRProcedureWithOutputParametersTestData;
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
        private SqlDatabaseTestActions dbo_CLRProcedureWithOutputParametersTestData;
    }
}
