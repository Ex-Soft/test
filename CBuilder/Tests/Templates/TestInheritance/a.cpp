#include "a.h"

using namespace std;

A::A(int aX, int aY) : x(aX), y(aY)
{
    cout<<"A::A(int, int)"<<endl;
}

A::A(const A &a) : x(a.x), y(a.y)
{
    cout<<"A::A(const A&)"<<endl;
}

A::~A(void)
{
    cout<<"A::~A(void)"<<endl;
}

A & A::operator = (const A &aA)
{
    cout<<"A::operator = (const A&)"<<endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
    }

    return(*this);
}

bool operator == (const A &aAL, const A &aAR)
{
   cout<<"bool operator == (const A&, const A&)"<<endl;
   return(aAL.x==aAR.x && aAL.y==aAR.y);
}

bool operator != (const A &aAL, const A &aAR)
{
   cout<<"bool operator != (const A&, const A&)"<<endl;
   return(!(aAL==aAR));
}

ostream& operator << (ostream& os, const A &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<" }";

    return os;
}