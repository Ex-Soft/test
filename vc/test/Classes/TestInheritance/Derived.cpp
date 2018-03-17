#include "Derived.h"

using namespace std;

DerivedClass::DerivedClass(int aX, int aY, int aZ) : BaseClass(aX, aY), z(aZ)
{
    cout<<"DerivedClass::DerivedClass(int, int, int)"<<endl;
}

DerivedClass::DerivedClass(const DerivedClass &a) : BaseClass(a.x, a.y), z(a.z)
{
    cout<<"DerivedClass::DerivedClass(const DerivedClass&)"<<endl;
}

DerivedClass::~DerivedClass(void)
{
    cout<<"DerivedClass::~DerivedClass(void)"<<endl;
}

void DerivedClass::ToString(void)
{
    cout<<"{ x: "<<x<<", y: "<<y<<", z: "<<z<<" }"<<endl;
}

DerivedClass & DerivedClass::operator = (const DerivedClass &aA)
{
    cout<<"DerivedClass::operator = (const DerivedClass&)"<<endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
        z=aA.z;
    }

    return(*this);
}

bool operator == (const DerivedClass &aAL, const DerivedClass &aAR)
{
   cout<<"bool operator == (const DerivedClass&, const DerivedClass&)"<<endl;
   return(aAL.x==aAR.x && aAL.y==aAR.y && aAL.z==aAR.z);
}

bool operator != (const DerivedClass &aAL, const DerivedClass &aAR)
{
   cout<<"bool operator != (const DerivedClass&, const DerivedClass&)"<<endl;
   return(!(aAL==aAR));
}

ostream& operator << (ostream& os, const DerivedClass &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<", z: "<<aA.z<<" }";

    return os;
}
