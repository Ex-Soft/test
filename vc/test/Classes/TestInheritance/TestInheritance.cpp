// TestInheritance.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

int _tmain(int argc, _TCHAR* argv[])
{
    BaseClass
        b1=BaseClass(),
        b2(b1),
        b3=b2,
        b4,
        *bPtr;

    b1.ToString();
    cout<<b1<<endl;

    b3.x=b3.y=3;
    b4=b3;

    if(b1==b4)
        cout<<"b1==b4"<<endl;

    if(b1!=b4)
        cout<<"b1!=b4"<<endl;

    DerivedClass
        d1=DerivedClass(),
        d2(d1),
        d3=d2,
        d4,
        *dPtr;

    d1.ToString();
    cout<<d1<<endl;

    d3.x=d3.y=d3.z=3;
    d4=d3;

    if(d1==d4)
        cout<<"d1==d4"<<endl;

    if(d1!=d4)
        cout<<"d1!=d4"<<endl;

    cout<<endl;
    bPtr=&b1;
    b1.ShowTypeId();
    bPtr->ShowTypeId();
    b1.ToString();
    bPtr->ToString();

    cout<<endl;
    bPtr=&d1;
    d1.ShowTypeId();
    bPtr->ShowTypeId();
    d1.ToString();
    bPtr->ToString();

    cout<<endl;
    if(dPtr=dynamic_cast<DerivedClass *>(bPtr))
        cout<<"dPtr=dynamic_cast<DerivedClass *>(bPtr)"<<endl;

    cout<<endl;
    d4.x=d4.y=d4.z=4;
    b4.ToString();
    b4=d4;
    b4.ToString();

	return 0;
}
