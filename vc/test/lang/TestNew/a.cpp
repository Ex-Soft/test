#include <iostream>

#include "a.h"

A::A(int aX, int aY) : x(aX), y(aY)
{
	std::cout << "A::A(int = " << aX << ", int = " << aY << ")" << std::endl;
}

A::A(const A& a) : x(a.x), y(a.y)
{
	std::cout << "A::A(const A&)" << std::endl;
}

A::~A(void)
{
	std::cout << "A::~A(void)" << std::endl;
}

A & A::operator = (const A& aA)
{
	std::cout << "A::operator = (const A&)" << std::endl;

	if (this != &aA)
	{
		x = aA.x;
		y = aA.y;
	}

	return(*this);
}
