#include <iostream>

#include "ClassWithConstructors.h"

ClassWithConstructors::ClassWithConstructors(int pInt)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	mDouble = pInt;
}

ClassWithConstructors::ClassWithConstructors(long pLong)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	mDouble = pLong;
}

ClassWithConstructors::ClassWithConstructors(double pDouble)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	mDouble = pDouble;
}
