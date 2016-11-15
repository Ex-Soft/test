#define TEST_OLE_DB
//#define TEST_ODBC
//#define WITHOUT_CONNECTION_POOL

using System;
using System.Data;

namespace TestDbProviderII
{
	public partial class TestDbProviderIIMainForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				DbProviderII.DbProviderII
					db = null;

				DbProviderII.ParameterII
					tmpParam;

				int
					tmpInt;

				decimal
					tmpDecimal;

				try
				{
					#if TEST_OLE_DB
						string
							ConnectionString =
							"Provider=Sybase.ASEOLEDBProvider;Server Name=localhost;Server Port Address=5000;User ID=sa;Password=;Initial Catalog=testdb";
							//"Provider=ASEOLEDB;Server=localhost;Port=5000;Language=russian;Initial Catalog=testdb;User ID=sa;Password=";

						#if WITHOUT_CONNECTION_POOL
							ConnectionString += ";OLE DB Services=-4";
						#endif
					#endif

					#if TEST_ODBC
						string
							ConnectionString =
							"Driver={SYBASE ASE ODBC Driver};NA=localhost,5000;Uid=sa;Pwd=;DB=testdb";
							//"DSN=SybaseODBCTest";
							//"Driver={Adaptive Server Enterprise};Server=localhost;Port=5000;Language=russian;Uid=sa;Pwd=;Database=testdb";
							//"DSN=SybaseODBCNewTest";
					#endif

					DbProviderII.DbProviderII
						dbSelf = new DbProviderII.DbProviderII(ConnectionString);

					dbSelf.ExecuteNonQuery("select @@spid", false);

					dbSelf.ExecuteStoredProcedure("sp_ReturnOnly", false);

					dbSelf.ParametersClear();
					dbSelf.ParametersAdd("RETURN_VALUE", DbType.Int32, ParameterDirection.ReturnValue);
					dbSelf.ParametersAdd("OutParam", DbType.Int32);
					dbSelf.ExecuteStoredProcedure("sp_ReturnAndOutput", true);
					if ((tmpParam = dbSelf.ParametersGet("OutParam")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);

					db = new DbProviderII.DbProviderII(ConnectionString);

					db.ConnectionOpen();

					db.ParametersClear();
					db.ParametersAdd("ParameterName_DbType", DbType.Byte);
					db.ParametersAdd("ParameterName_DbType_Value", DbType.Byte, (object)0);
					db.ParametersAdd("ParameterName_DbType_Direction", DbType.Byte, ParameterDirection.Output);
					db.ParametersAdd("ParameterName_DbType_Value_Direction", DbType.Byte, 0, ParameterDirection.Input);

					db.ParametersClear();
					db.ParametersAdd("RETURN_VALUE", DbType.Int32, ParameterDirection.ReturnValue);
					db.ParametersAdd("mult1", DbType.Int32, 5);
					db.ParametersAdd("mult2", DbType.Int32, 6);
					db.ParametersAdd("result", DbType.Int32);
					db.ExecuteNonQuery("{? = call mathtutor(?, ?, ?)}", true);

					if ((tmpParam = db.ParametersGet("RETURN_VALUE")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("result")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);

					db.ParametersClear();
					db.ParametersAdd("RETURN_VALUE", DbType.Int32, ParameterDirection.ReturnValue);
					db.ParametersAdd("FDecimal_10_6", DbType.Double, 123.45);
					db.ParametersAdd("FDecimal_10_6_out", DbType.Double);
					db.ExecuteNonQuery("{? = call sp_TestTypes_Decimal_10_6(? ,?)}", true);
					if ((tmpParam = db.ParametersGet("RETURN_VALUE")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_10_6_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);

					db.ParametersClear();
					db.ParametersAdd("RETURN_VALUE", DbType.Int32, ParameterDirection.ReturnValue);
					db.ParametersAdd("mult1", DbType.Int32, 6);
					db.ParametersAdd("mult2", DbType.Int32, 7);
					db.ParametersAdd("result", DbType.Int32);
					db.ExecuteStoredProcedure("mathtutor", true);
					if ((tmpParam = db.ParametersGet("RETURN_VALUE")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("result")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);

					db.ParametersClear();
					db.ParametersAdd("RETURN_VALUE", DbType.Int32, ParameterDirection.ReturnValue);
					db.ParametersAdd("FDecimal_10_6", DbType.Decimal, 123.45);
					db.ParametersAdd("FDecimal_10_6_out", DbType.Decimal);
					db.ExecuteStoredProcedure("sp_TestTypes_Decimal_10_6", true);
					if ((tmpParam = db.ParametersGet("RETURN_VALUE")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_10_6_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);

					db.ParametersClear();
					db.ParametersAdd("RETURN_VALUE", DbType.Int32, ParameterDirection.ReturnValue);
					db.ParametersAdd("FDecimal_4_0", DbType.Decimal, 9999m);
					db.ParametersAdd("FDecimal_4_2", DbType.Decimal, 99.99m);
					db.ParametersAdd("FDecimal_5_0", DbType.Decimal, 99999m);
					db.ParametersAdd("FDecimal_5_2", DbType.Decimal, 999.99m);
					db.ParametersAdd("FDecimal_8_0", DbType.Decimal, 99999999m);
					db.ParametersAdd("FDecimal_8_2", DbType.Decimal, 999999.99m);
					db.ParametersAdd("FDecimal_9_0", DbType.Decimal, 999999999m);
					db.ParametersAdd("FDecimal_9_2", DbType.Decimal, 9999999.99m);
					db.ParametersAdd("FDecimal_10_0", DbType.Decimal, 9999999999m);
					db.ParametersAdd("FDecimal_10_2", DbType.Decimal, 99999999.99m);
					db.ParametersAdd("FDecimal_18_0", DbType.Decimal, 999999999999999999m);
					db.ParametersAdd("FDecimal_18_2", DbType.Decimal, 9999999999999999.99m);
					db.ParametersAdd("FNumeric_4_0", DbType.Decimal, 9999m);
					db.ParametersAdd("FNumeric_4_2", DbType.Decimal, 99.99m);
					db.ParametersAdd("FNumeric_5_0", DbType.Decimal, 99999m);
					db.ParametersAdd("FNumeric_5_2", DbType.Decimal, 999.99m);
					db.ParametersAdd("FNumeric_8_0", DbType.Decimal, 99999999m);
					db.ParametersAdd("FNumeric_8_2", DbType.Decimal, 999999.99m);
					db.ParametersAdd("FNumeric_9_0", DbType.Decimal, 999999999m);
					db.ParametersAdd("FNumeric_9_2", DbType.Decimal, 9999999.99m);
					db.ParametersAdd("FNumeric_10_0", DbType.Decimal, 9999999999m);
					db.ParametersAdd("FNumeric_10_2", DbType.Decimal, 99999999.99m);
					db.ParametersAdd("FNumeric_18_0", DbType.Decimal, 999999999999999999m);
					db.ParametersAdd("FNumeric_18_2", DbType.Decimal, 9999999999999999.99m);
					db.ParametersAdd("FMoney", DbType.Currency, 922337203685477.5807m);
					db.ParametersAdd("FDecimal_4_0_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_4_2_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_5_0_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_5_2_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_8_0_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_8_2_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_9_0_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_9_2_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_10_0_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_10_2_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_18_0_out", DbType.Decimal);
					db.ParametersAdd("FDecimal_18_2_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_4_0_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_4_2_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_5_0_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_5_2_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_8_0_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_8_2_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_9_0_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_9_2_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_10_0_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_10_2_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_18_0_out", DbType.Decimal);
					db.ParametersAdd("FNumeric_18_2_out", DbType.Decimal);
					db.ParametersAdd("FMoney_out", DbType.Currency);
					db.ExecuteStoredProcedure("sp_TestTypes", true);
					if ((tmpParam = db.ParametersGet("RETURN_VALUE")) != null)
						tmpInt = Convert.ToInt32(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_4_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_4_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_5_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_5_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_8_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_8_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_9_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_9_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_10_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_10_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_18_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FDecimal_18_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_4_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_4_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_5_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_5_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_8_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_8_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_9_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_9_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_10_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_10_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_18_0_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FNumeric_18_2_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);
					if ((tmpParam = db.ParametersGet("FMoney_out")) != null)
						tmpDecimal = Convert.ToDecimal(tmpParam.Value);

					db.TransactionBegin(IsolationLevel.ReadCommitted);
					db.TransactionRollback();
					db.ConnectionClose();
				}
				catch (Exception eException)
				{
					if (db != null)
					{
						db.TransactionRollback();
						db.ConnectionClose();
					}
					Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
				}
			}
		}
	}
}
