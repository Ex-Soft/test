#include <iostream>
#include "a.h"

A::A(int aX, int aY) : x(aX), y(aY)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

A::A(const A &a) : x(a.x), y(a.y)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

A::~A(void)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

A & A::operator = (const A &aA)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	if (this != &aA)
	{
		x = aA.x;
		y = aA.y;
	}

    return(*this);
}

bool operator == (const A &aAL, const A &aAR)
{
	return(aAL.x == aAR.x && aAL.y == aAR.y);
}

bool operator != (const A &aAL, const A &aAR)
{
	return(!(aAL == aAR));
}

A& A::operator ++ ()
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

    ++this->x;
    ++this->y;

    return *this;
}

A A::operator ++ (int ignored_dummy_value)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;

	A tmp = *this;

    this->x++;
    this->y++;

    return tmp;
}
