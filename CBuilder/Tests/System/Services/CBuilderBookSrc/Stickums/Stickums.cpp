#include <SysUtils.hpp>
#include <SvcMgr.hpp>
#pragma hdrstop
#define Application Svcmgr::Application
USERES("Stickums.res");
USEFORM("Unit1.cpp", Stickum); /* TService: File Type */
//---------------------------------------------------------------------------
WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
	try
	{
		Application->Initialize();
		Application->CreateForm(__classid(TStickum), &Stickum);
                Application->Run();
	}
	catch (Exception &exception)
	{
		Sysutils::ShowException(&exception, ExceptAddr());
	}
	return 0;
}
