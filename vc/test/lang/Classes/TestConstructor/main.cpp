#include <iostream>
#include <vector>

#include "a.h"
#include "c.h"
#include "container.h"

int main(int argc, char **argv)
{
	C c1(1, 2);	// A::A(int = 0, int = 0) C::C(int = 0, int = 0)
	C c2(c1);	// A::A(int = 0, int = 0) C::C(const C&)
				// A::A(int = 0, int = 0) C::C(const C&) A::operator = (const A&)
	C c3(A(3, 4));

	A a1;		// A::A(int = 0, int = 0)
	A a2(a1);	// A::A(const A&)
	A a3 = a2;	// A::A(const A&)

	B b;
	A a4(b);	// A::A(const B&)
	A a5 = b;	// A::A(const B&)

	a1 = a5;	// A::operator = (const A&)
	a2 = b;		// 1st step A::A(const B&)
				// 2nd step A::operator = (const A&)

	size_t size = 5;
	Container container1(size);

	for (size_t i = 0; i < size; ++i)
		container1[i] = i;

	Container container2;

	container2 = container1;

	std::vector<Container> v;

	v.push_back(container1);
	v.push_back(container2);
	v.push_back(Container(size));
	v.push_back(Container(size));

	return 0;
}
