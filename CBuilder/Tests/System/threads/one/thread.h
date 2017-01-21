//---------------------------------------------------------------------------

#ifndef threadH
#define threadH
//---------------------------------------------------------------------------
#include <Classes.hpp>
//---------------------------------------------------------------------------
class MyTestThread : public TThread
{
private:
        int Answer;
protected:
        void __fastcall GiveAnswer(void);
        void __fastcall Execute();
public:
        __fastcall MyTestThread(bool CreateSuspended);
};
//---------------------------------------------------------------------------
#endif
