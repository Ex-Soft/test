#include <iostream>

#include "a.h"

int main(int argc, char **argv)
{
    A
        a1(1, 1),
        a2(a1),
        a3 = a2,
        a4,
        aMax(5,5),
		a5,
		a6;

    a4 = a3;

	std::cout << std::endl;
    a5 = ++a4;

	std::cout << std::endl;
    a6 = a4++;

	std::cout << std::endl;
    for(A a = A(0,0); a != aMax; ++a)
		std::cout << a.x << std::endl;

	std::cout << std::endl;
    for(A a = A(0,0); a != aMax; a++)
		std::cout << a.x << std::endl;

    return 0;
}
