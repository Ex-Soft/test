//---------------------------------------------------------------------------
#include <memory>
#pragma hdrstop

#include "ClassVictim.h"
//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
        const int Max = 3;

        std::auto_ptr<ClassVictim> ptr(new ClassVictim());
        ptr->Test();

        std::auto_ptr<ClassVictim> ptrs[3];

        for(int i = 0; i < Max; ++i)
                ptrs[i] = std::auto_ptr<ClassVictim>(new ClassVictim());

        for(int i = 0; i < Max; ++i)
                ptrs[i]->Test();

        return 0;
}
//---------------------------------------------------------------------------
 