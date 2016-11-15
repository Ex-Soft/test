// TestInitialization.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    A
        *p1(new A()),
        *p2=new A(),
        a1,
        a2;

    cout<<endl;
    a1=a2=A(5,5);
    cout<<endl;

    cout<<"*p1 "<<(*p1!=*p2 ? '!' : '=')<<"= *p2"<<endl;

    if(p1)
        delete p1;

    if(p2)
        delete p2;

	return 0;
}
