// TestPrivate.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

class CBase
{
private:
 virtual void func()=0;
};

class CDerived : public CBase
{
public:
 virtual void func()
 {
 }
};

class CBaseII
{
private:
 virtual void func()
 {}
};

class CDerivedII : public CBaseII
{
public:
 virtual void func()
 {
 }
};

int _tmain(int argc, _TCHAR* argv[])
{
    CDerived
        d = CDerived();

    d.func();

    CDerivedII
        dII = CDerivedII();

    dII.func();

	return 0;
}

