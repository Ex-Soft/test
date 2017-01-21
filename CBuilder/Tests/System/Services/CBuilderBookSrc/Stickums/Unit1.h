//---------------------------------------------------------------------------
#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <SysUtils.hpp>
#include <Classes.hpp>
#include <SvcMgr.hpp>
#include <vcl.h>
#include <ScktComp.hpp>
//---------------------------------------------------------------------------
class TStickum : public TService
{
__published:    // IDE-managed Components
  TServerSocket *ServerSocket1;
  void __fastcall ServerSocket1ClientRead(TObject *Sender,
          TCustomWinSocket *Socket);
  void __fastcall ServiceExecute(TService *Sender);
  void __fastcall ServiceStart(TService *Sender, bool &Started);
  void __fastcall ServiceStop(TService *Sender, bool &Stopped);
private:        // User declarations
public:         // User declarations
	__fastcall TStickum(TComponent* Owner);
	TServiceController __fastcall GetServiceController(void);

	friend void __stdcall ServiceController(unsigned CtrlCode);
};
//---------------------------------------------------------------------------
extern PACKAGE TStickum *Stickum;
//---------------------------------------------------------------------------
#endif
