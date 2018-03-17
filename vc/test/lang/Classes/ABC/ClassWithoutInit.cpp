#include <iostream>

#include "ClassWithoutInit.h"

ClassWithoutInit::ClassWithoutInit() : ClassWithoutInit(0, 0, 0)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

ClassWithoutInit::ClassWithoutInit(int int1) : ClassWithoutInit(int1, 0, 0)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

ClassWithoutInit::ClassWithoutInit(int int1, int int2) : ClassWithoutInit(int1, int2, 0)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

ClassWithoutInit::ClassWithoutInit(int int1, int int2, int int3) : mInt1(int1), mInt2(int2), mInt3(int3)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

ClassWithoutInit::ClassWithoutInit(const ClassWithoutInit &obj) : ClassWithoutInit(obj.mInt1, obj.mInt2, obj.mInt3)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

ClassWithoutInit::~ClassWithoutInit()
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}
