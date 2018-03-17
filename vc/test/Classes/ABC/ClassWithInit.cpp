#include <iostream>

#include "ClassWithInit.h"

ClassWithInit::ClassWithInit()
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	Init();
}

ClassWithInit::ClassWithInit(int int1)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	Init(int1);
}

ClassWithInit::ClassWithInit(int int1, int int2)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	Init(int1, int2);
}

ClassWithInit::ClassWithInit(int int1, int int2, int int3)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	Init(int1, int2, int3);
}

ClassWithInit::ClassWithInit(const ClassWithInit &obj)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	Init(obj.mInt1, obj.mInt2, obj.mInt3);
}

void ClassWithInit::Init(int int1, int int2, int int3)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	mInt1 = int1;
	mInt2 = int2;
	mInt3 = int3;
}

ClassWithInit::~ClassWithInit()
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}
