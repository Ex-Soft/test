#include <iostream>

#include "d.h"

D::D() : D(0, 0, 0)
{
	std::cout << "D::D()" << std::endl;
}

D::D(int aX) : D(aX, 0, 0)
{
	std::cout << "D::D(int)" << std::endl;
}

D::D(int aX, int aY) : D(aX, aY, 0)
{
	std::cout << "D::D(int, int)" << std::endl;
}

D::D(int aX, int aY, int aZ)
{
	std::cout << "D::D(int, int, int)" << std::endl;
}

D::D(const D& d) : x(d.x), y(d.y), z(d.z)
{
	std::cout << "D::D(const D&)" << std::endl;
}

D::~D(void)
{
	std::cout << "D::~D(void)" << std::endl;
}

D & D::operator = (const D& d)
{
	std::cout << "D::operator = (const D&)" << std::endl;

	if (this != &d)
	{
		x = d.x;
		y = d.y;
		z = d.z;
	}

	return *this;
}
