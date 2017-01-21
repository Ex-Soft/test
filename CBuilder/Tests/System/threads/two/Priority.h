//---------------------------------------------------------------------------

#ifndef PriorityH
#define PriorityH
//---------------------------------------------------------------------------
#include <Classes.hpp>
//---------------------------------------------------------------------------
class TPriorityThread : public TThread
{
private:
protected:
        void __fastcall Execute();
public:
        bool First;
        __fastcall TPriorityThread(bool IsFirst);
        void __fastcall DisplayProgress(void);
};
//---------------------------------------------------------------------------
#endif
