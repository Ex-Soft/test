//---------------------------------------------------------------------------
#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TTestService *TestService;
//---------------------------------------------------------------------------
__fastcall TTestService::TTestService(TComponent* Owner):TService(Owner)
{
}
//---------------------------------------------------------------------------

TServiceController __fastcall TTestService::GetServiceController(void)
{
	return (TServiceController) ServiceController;
}
//---------------------------------------------------------------------------

void __stdcall ServiceController(unsigned CtrlCode)
{
	TestService->Controller(CtrlCode);
}
//---------------------------------------------------------------------------


