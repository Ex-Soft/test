#include "Base.h"

using namespace std;

BaseClass::BaseClass(int aX, int aY) : x(aX), y(aY)
{
    cout<<"BaseClass::BaseClass(int, int)"<<endl;
}

BaseClass::BaseClass(const BaseClass &a) : x(a.x), y(a.y)
{
    cout<<"BaseClass::BaseClass(const BaseClass&)"<<endl;
}

BaseClass::~BaseClass(void)
{
    cout<<"BaseClass::~BaseClass(void)"<<endl;
}

void BaseClass::ToString(void)
{
    cout<<"{ x: "<<x<<", y: "<<y<<" }"<<endl;
}

void BaseClass::ShowTypeId(void)
{
    cout<<typeid(*this).name()<<endl;
}

BaseClass & BaseClass::operator = (const BaseClass &aA)
{
    cout<<"BaseClass::operator = (const BaseClass&)"<<endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
    }

    return(*this);
}

bool operator == (const BaseClass &aAL, const BaseClass &aAR)
{
   cout<<"bool operator == (const BaseClass&, const BaseClass&)"<<endl;
   return(aAL.x==aAR.x && aAL.y==aAR.y);
}

bool operator != (const BaseClass &aAL, const BaseClass &aAR)
{
   cout<<"bool operator != (const BaseClass&, const BaseClass&)"<<endl;
   return(!(aAL==aAR));
}

ostream& operator << (ostream& os, const BaseClass &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<" }";

    return os;
}
