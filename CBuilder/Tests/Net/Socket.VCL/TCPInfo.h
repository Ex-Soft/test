#ifndef TCPInfoH
#define TCPInfoH

#include <vcl.h>
#include "TCPDef.h"

class TConnectionInfo{

  void __fastcall Initialize(void);

protected:

  void __fastcall CopyData(const TConnectionInfo &aConnectionInfo);

public:

  eConnectState State;
  unsigned int BuffSize;
  unsigned int Count;
  char *Buff;

  __fastcall TConnectionInfo(void);
  __fastcall TConnectionInfo(const TConnectionInfo &aConnectionInfo);
  __fastcall ~TConnectionInfo(void);

  virtual AnsiString __fastcall ClassName(void) { return "TConnectionInfo"; };
};
//---------------------------------------------------------------------------

#endif
