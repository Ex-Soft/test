// AnyTest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    A
        a=TemplateCreate<A>();

    a.ToString();
    a.x=10;
    a.y=20;
    a.ToString();

    int
        tmpInt=TemplateCreate<int>();

    cout<<tmpInt<<endl;

    a.x=100;
    a.y=200;
    a.ToString();
    
    tmpInt=100;

    cout<<tmpInt<<endl;

	return 0;
}