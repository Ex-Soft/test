// TestODBC.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "afxdb.h"
#include "TestODBC.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// The one and only application object

CWinApp theApp;

using namespace std;

#include "..\Common\GetConnectionString.h"

int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	int nRetCode = 0;

	// initialize MFC and print and error on failure
	if (!AfxWinInit(::GetModuleHandle(NULL), NULL, ::GetCommandLine(), 0))
	{
		// TODO: change error code to suit your needs
		_tprintf(_T("Fatal Error: MFC initialization failed\n"));
		nRetCode = 1;
	}
	else
	{
		CDatabase
			DB;

		char
			strConnectionString[0xffff];

		GetConnectionString("TestODBC.ini",strConnectionString,sizeof(strConnectionString));

		if(DB.Open(NULL,false,false,strConnectionString,true))
		{
			//AfxMessageBox(DB.GetConnect());
			//if(DB.CanTransact())
			//	AfxMessageBox("Transact Yes");

			//AfxMessageBox(DB.GetDatabaseName());

			CRecordset
				cr(&DB);

			try
			{
				if(cr.Open(CRecordset::forwardOnly,_T("{call sp_SalaryMaxListNULL}" /* "{call sp_SalaryMaxList3}" */),CRecordset::readOnly))
				{
					short
						nFields=cr.GetODBCFieldCount();

					CODBCFieldInfo
						fieldinfo;

					for(short x=0; x < nFields; ++x)
					{
						cr.GetODBCFieldInfo(x,fieldinfo );
						//AfxMessageBox(fieldinfo.m_strName);
					}

					CDBVariant
						var;

					short
						index=0;

					if(!cr.IsEOF())
					{
						//cr.Move(0);
						while(!cr.IsEOF())
						{
							cr.GetFieldValue(index,var);
							AfxMessageBox(*var.m_pstring);
							cr.MoveNext();
						}
					}

					cr.Close(); 
				}
			}
			catch(CDBException *e)
			{
				AfxMessageBox(e->m_strError);
			}

			DB.Close();
		}
		else
			nRetCode=-1;
	}

	return nRetCode;
}
