#include <windows.h>
#include <sql.h>
#include <sqlext.h> 

#define USE_SQL_EXECUTE
//#define TEST_SP_MTSBU

void main(int argc, char** argv)
{
   SQLHENV
     henv=NULL;

   SQLRETURN
     sret,
     rc;

   SQLHDBC
     hdbc=NULL;

   SQLTCHAR
     dsn[1024],
     szSQLBuf[1024],
     SqlState[6],
     Msg[SQL_MAX_MESSAGE_LENGTH];

   SQLSMALLINT
     siSize,
     MsgLen,
	 DataType,
	 DecimalDigits,
	 Nullable;

   SQLINTEGER
     NativeError,
     lName;

   SQLUINTEGER
	 ColumnSize;

   SQLHSTMT
     hstmt=NULL;

   int
     NameLength=1024;

   unsigned char
     Name[1024],
	 ColumnName[1024];

   bool
     eof,
	 CursorOpen=false;

   char
	 #if defined(TEST_SP_MTSBU)
       *SQLCmd="{call sp_MTSBU_InsAgr}";
       //*SQLCmd="sp_MTSBU_InsAgr";
     #else
       // Valid
       //*SQLCmd="{call sp_SalaryMaxListNULL}";
       *SQLCmd="{call sp_SalaryMaxList3}";
	   //*SQLCmd="{call sp_ReturnOnly}";
	   //*SQLCmd="sp_SalaryMaxList3";
       //
       //Invalid
       //*SQLCmd="{exec sp_SalaryMaxList3}";
       //*SQLCmd="{execute sp_SalaryMaxList3}";
	   //*SQLCmd="call sp_SalaryMaxList3";
     #endif

   sret=SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &henv);
   if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
     goto exit;

   sret=SQLSetEnvAttr(henv, SQL_ATTR_ODBC_VERSION, (void*)SQL_OV_ODBC3, SQL_IS_INTEGER);
   if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
     goto exit;

   sret=SQLAllocHandle(SQL_HANDLE_DBC,henv,&hdbc);
   if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
   {
       rc=SQLGetDiagRec(SQL_HANDLE_ENV,henv,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
	   strcpy((char *)Name,"SQL ERROR: ");
	   strcat((char *)Name,(const char *)Msg);
       MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
	   goto exit;
   }

   #if defined(TEST_SP_MTSBU)
     strcpy((char *)dsn,"bill");
   #else
     strcpy((char *)dsn,"SybaseODBCTest" /* "SybaseODBCNewTest" */);
   #endif
   sret=SQLConnect(hdbc,(unsigned char *)dsn,SQL_NTS,(SQLCHAR*)"sa",SQL_NTS,(SQLCHAR*)"",SQL_NTS);
   if(sret==SQL_SUCCESS || sret==SQL_SUCCESS_WITH_INFO)
   {
      //MessageBox(NULL,(char*)szSQLBuf,"Connection with database - successfully",MB_OK);
   }
   else if(sret==SQL_NEED_DATA || sret==SQL_ERROR || sret==SQL_INVALID_HANDLE)
   {
      switch(sret)
      {
         case SQL_NEED_DATA:
                        rc=SQLGetDiagRec(SQL_HANDLE_STMT,hdbc,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
						strcpy((char *)Name,"SQL ERROR: ");
						strcat((char *)Name,(const char *)Msg);
                        MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
                        break;
         case SQL_ERROR:
                        rc=SQLGetDiagRec(SQL_HANDLE_DBC,hdbc,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
						strcpy((char *)Name,"SQL ERROR: ");
						strcat((char *)Name,(const char *)Msg);
                        MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
                        break;
         case SQL_INVALID_HANDLE:
                        MessageBox(NULL,"error","SQL INVALID HANDLE",MB_OK);
                        break;
      }
      goto exit;
   }
   else
     goto exit;

   sret=SQLAllocHandle(SQL_HANDLE_STMT,hdbc,&hstmt);
   if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
     goto exit;

   #if defined(USE_SQL_EXECUTE)
     sret=SQLPrepare(hstmt,(SQLCHAR *)SQLCmd,SQL_NTS);
     if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
       goto exit;
	 sret=SQLNumResultCols(hstmt,&siSize);
     if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
       goto exit;
     sret=SQLExecute(hstmt);
   #else
     sret=SQLExecDirect(hstmt,(SQLCHAR *)SQLCmd,SQL_NTS);
   #endif
   if(sret==SQL_SUCCESS)
   {
      sret=SQLNumResultCols(hstmt,&siSize);
      if(sret!=SQL_SUCCESS)
        goto exit;

	  for(int i=1; i<=siSize; ++i)
	  {
         sret=SQLDescribeCol(hstmt,i,ColumnName,NameLength,&MsgLen,&DataType,&ColumnSize,&DecimalDigits,&Nullable);
		 if(sret==SQL_SUCCESS)
		 {
			 strcpy((char *)Name,"Column Name: '");
             strcat((char *)Name,(const char *)ColumnName);
			 strcat((char *)Name,"'");

			 *Msg='\x0';
			 switch(DataType)
			 {
				case SQL_DECIMAL :
				{
					strcpy((char *)Msg,"SQL_DECIMAL");
					break;
				}
				case SQL_VARCHAR :
				{
					strcpy((char *)Msg,"SQL_VARCHAR");
					break;
				}
			 }
			 strcat((char *)Name," DataType: '");
			 strcat((char *)Name,(const char *)Msg);
			 strcat((char *)Name,"'");

			 itoa(ColumnSize,(char *)Msg,10);
			 strcat((char *)Name," Column Size: '");
             strcat((char *)Name,(const char *)Msg);
			 strcat((char *)Name,"'");

 			 itoa(DecimalDigits,(char *)Msg,10);
			 strcat((char *)Name," Decimal Digits: '");
             strcat((char *)Name,(const char *)Msg);
			 strcat((char *)Name,"'");

			 switch(Nullable)
			 {
				case SQL_NO_NULLS :
				{
					strcat((char *)Name," SQL_NO_NULLS");
					break;
				}
				case SQL_NULLABLE :
				{
					strcat((char *)Name," SQL_NULLABLE");
					break;
				}
				case SQL_NULLABLE_UNKNOWN :
				{
					strcat((char *)Name," SQL_NULLABLE_UNKNOWN");
					break;
				}
				default :
				{
					strcat((char *)Name," Unknown");
					break;
				}
			 }
		 }
		 else
		 {
            rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
            strcpy((char *)Name,"SQL ERROR: ");
            strcat((char *)Name,(const char *)Msg);
            MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
			goto exit;
		 }
	  }

      eof=false;
      while(sret==SQL_SUCCESS && !eof)
      {
         sret=SQLFetch(hstmt);
         switch(sret)
         {
            case SQL_SUCCESS :
            {
			   if(!CursorOpen)
				   CursorOpen=true;

               memset(Name,0,NameLength);
               sret=SQLGetData(hstmt, 1, SQL_C_CHAR, Name, NameLength, &lName);
               break;
            }
            case SQL_ERROR :
            case SQL_SUCCESS_WITH_INFO :
            {
               rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
               strcpy((char *)Name,"SQL ERROR: ");
               strcat((char *)Name,(const char *)Msg);
               MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
               break;
            }
            case SQL_NO_DATA :
            {
			   if(!CursorOpen)
				 CursorOpen=true;
			   eof=true;
               break;
            }
         }
      }
   }
   else
   {
      rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
      strcpy((char *)Name,"SQL ERROR: ");
      strcat((char *)Name,(const char *)Msg);
      MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
   }

   #if !defined(TEST_SP_MTSBU)
      if(CursorOpen)
	  {
         sret=SQLCloseCursor(hstmt);
	     if(sret!=SQL_SUCCESS)
	     {
            rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
            strcpy((char *)Name,"SQL ERROR: ");
            strcat((char *)Name,(const char *)Msg);
            MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
			goto exit;
	     }
		 else
		   CursorOpen=false;
	  }

      SQLCmd="{? = call sp_TestTypes_Decimal_10_6(? ,?)}";
	  sret=SQLPrepare(hstmt,(SQLCHAR *)SQLCmd,SQL_NTS);
      if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
	  {
         rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
         strcpy((char *)Name,"SQL ERROR: ");
         strcat((char *)Name,(const char *)Msg);
         MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
         goto exit;
	  }

      /*
	  SQLUINTEGER
		  ParameterSize;

	  sret=SQLDescribeParam(hstmt,1,&DataType,&ParameterSize,&DecimalDigits,&Nullable);
      if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
	  {
         rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
         strcpy((char *)Name,"SQL ERROR: ");
         strcat((char *)Name,(const char *)Msg);
         MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
         goto exit;
	  }
	  else
	  {
		  switch(DataType)
		  {
				case SQL_DECIMAL :
				{
					strcpy((char *)Name,"DECIMAL");
					break;
				}
				case SQL_INTEGER :
				{
					strcpy((char *)Name,"INTEGER");
					break;
				}
		  }
	  }
	  sret=SQLDescribeParam(hstmt,2,&DataType,&ParameterSize,&DecimalDigits,&Nullable);
      if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
	  {
         rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
         strcpy((char *)Name,"SQL ERROR: ");
         strcat((char *)Name,(const char *)Msg);
         MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
         goto exit;
	  }
	  else
	  {
		  switch(DataType)
		  {
				case SQL_DECIMAL :
				{
					strcpy((char *)Name,"DECIMAL");
					break;
				}
				case SQL_INTEGER :
				{
					strcpy((char *)Name,"INTEGER");
					break;
				}
		  }
	  }
	  sret=SQLDescribeParam(hstmt,3,&DataType,&ParameterSize,&DecimalDigits,&Nullable);
      if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
	  {
         rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
         strcpy((char *)Name,"SQL ERROR: ");
         strcat((char *)Name,(const char *)Msg);
         MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
         goto exit;
	  }
	  else
	  {
		  switch(DataType)
		  {
				case SQL_DECIMAL :
				{
					strcpy((char *)Name,"DECIMAL");
					break;
				}
				case SQL_INTEGER :
				{
					strcpy((char *)Name,"INTEGER");
					break;
				}
		  }
	  }
      */

	  SQLINTEGER
	    ReturnValue, // sizeof(ReturnValue) == 4
		cbReturnValue=0,
		cbFDecimal_10_6=0,
		cbFDecimal_10_6_out=0;

	  SQLDOUBLE
	    FDecimal_10_6=123.45,
		FDecimal_10_6_out;

	  sret=SQLBindParameter(hstmt,1,SQL_PARAM_OUTPUT,SQL_C_SLONG,SQL_INTEGER,0,0,&ReturnValue,0,&cbReturnValue);
	  sret=SQLBindParameter(hstmt,2,SQL_PARAM_INPUT,SQL_C_DOUBLE,SQL_DECIMAL,10,6,&FDecimal_10_6,0,&cbFDecimal_10_6);
	  sret=SQLBindParameter(hstmt,3,SQL_PARAM_OUTPUT,SQL_C_DOUBLE,SQL_DECIMAL,10,6,&FDecimal_10_6_out,0,&cbFDecimal_10_6_out);
	  // FDecimal_10_6=123.45;
	  sret=SQLExecute(hstmt);
      if(sret!=SQL_SUCCESS && sret!=SQL_SUCCESS_WITH_INFO)
	  {
         rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
         strcpy((char *)Name,"SQL ERROR: ");
         strcat((char *)Name,(const char *)Msg);
         MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
         goto exit;
	  }
	  else
	  {
         rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
         strcpy((char *)Name,"SQL ERROR: ");
         strcat((char *)Name,(const char *)Msg);
         MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
	  }
   #endif

   exit:

   if(hstmt)
   {
      if(CursorOpen)
	  {
         sret=SQLCloseCursor(hstmt);
	     if(sret!=SQL_SUCCESS)
	     {
            rc=SQLGetDiagRec(SQL_HANDLE_STMT,hstmt,1,(SQLCHAR*) &SqlState,&NativeError,(unsigned char*)Msg,SQL_MAX_MESSAGE_LENGTH,&MsgLen);
            strcpy((char *)Name,"SQL ERROR: ");
            strcat((char *)Name,(const char *)Msg);
            MessageBox(NULL,(LPCSTR)Name,(char*)SqlState,MB_OK);
	     }
	  }
      sret=SQLFreeHandle(SQL_HANDLE_STMT,hstmt);
   }

   if(hdbc)
   {
      sret=SQLDisconnect(hdbc);
      sret=SQLFreeHandle(SQL_HANDLE_DBC,hdbc);
   }

   if(henv)
     sret=SQLFreeHandle(SQL_HANDLE_ENV,henv);
}