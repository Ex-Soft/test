// TestAlgorithm.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

int _tmain(int argc, _TCHAR* argv[])
{
    TemplateClass<int, Algorithm1> tc1 = TemplateClass<int, Algorithm1>();
    TemplateClass<int, Algorithm2> tc2 = TemplateClass<int, Algorithm2>();

    tc1.DoSmth();
    tc2.DoSmth();

    return 0;
}

