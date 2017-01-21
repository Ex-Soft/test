//---------------------------------------------------------------------------

#ifndef bodyH
#define bodyH
//---------------------------------------------------------------------------
#include <Classes.hpp>
//---------------------------------------------------------------------------
class MyThread : public TThread
{
private:
protected:
        void __fastcall Execute();
public:
        __fastcall MyThread(bool CreateSuspended);
        void __fastcall DisplayList(void);
        AnsiString Text;
};
//---------------------------------------------------------------------------
#endif
