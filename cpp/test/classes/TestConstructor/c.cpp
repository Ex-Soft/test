#include <iostream>

#include "c.h"

C::C(int aX, int aY) : a(aX, aY)
{
	std::cout << "C::C(int = 0, int = 0)" << std::endl;
}

C::C(const C& c) : a(c.a.x, c.a.y) // A::A(int = 0, int = 0) C::C(const C&)
{
	std::cout << "C::C(const C&)" << std::endl;

	// a = c.a; // A::A(int = 0, int = 0) C::C(const C&) A::operator = (const A&)
}

C::C(const A& aA) : a(aA) // A::A(int = 0, int = 0) C::C(const C&)
{
	std::cout << "C::C(const A&)" << std::endl;

	// a = c.a; // A::A(int = 0, int = 0) C::C(const C&) A::operator = (const A&)
}

C::~C(void)
{
	std::cout << "C::~C(void)" << std::endl;
}

C & C::operator = (const C& c)
{
	std::cout << "C::operator = (const C&)" << std::endl;

	if (this != &c)
	{
		a = c.a;
	}

	return *this;
}
