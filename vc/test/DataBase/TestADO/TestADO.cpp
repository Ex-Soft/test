#include "stdafx.h"
#import "C:\Program Files\Common Files\System\ado\msado15.dll" rename("EOF", "EndOfFile")

#include "..\Common\GetConnectionString.h"

int _tmain(int argc, _TCHAR* argv[])
{
	DWORD
		a;

	HRESULT
		hr; 

	if((hr=CoInitialize(0))!=S_OK)
		return(-1);

	ADODB::_ConnectionPtr
		_m_pConnection;

	if((hr=_m_pConnection.CreateInstance(__uuidof(ADODB::Connection)))!=S_OK)
	{
		CoUninitialize();
		return(-1);
	}

	//_m_pConnection->ConnectionTimeout=60; 

	char
		strConnectionString[0xffff];

	GetConnectionString("TestADO.ini",strConnectionString,sizeof(strConnectionString));

	if((hr=_m_pConnection->Open((LPSTR)(LPCSTR)strConnectionString,"","",NULL))!=S_OK)
	{
		CoUninitialize();
		return(-1);
	}

	ADODB::_RecordsetPtr
		pRecordset;
 
	if((hr=pRecordset.CreateInstance(__uuidof(ADODB::Recordset)))!=S_OK)
	{
		_m_pConnection->Close();
		CoUninitialize();
		return(-1);
	}
	
	char
		*command="select * from TestTypes";

	if((hr=pRecordset->Open((_bstr_t)command, _variant_t((IDispatch *)_m_pConnection, true), ADODB::adOpenStatic, ADODB::adLockReadOnly,ADODB::adCmdText))!=S_OK)
	{
		_m_pConnection->Close();
		CoUninitialize();
		return(-1);
	}

	ADODB::FieldsPtr
		_m_pFields; 

	//Поля и все про них если надо))
	_m_pFields=pRecordset->GetFields();

	//На всяк случай )))
	pRecordset->MoveFirst();

	while(!pRecordset->EndOfFile) 
	{ 
		//hr=m_pstSelectInfo->pRecordset->MoveNext();
		hr=pRecordset->MoveNext();
	} 

	CoUninitialize();

	return 0;
}
