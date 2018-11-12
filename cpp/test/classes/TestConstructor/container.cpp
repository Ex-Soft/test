#include <iostream>

#include "container.h"

Container::Container(size_t aSize) : size(aSize)
{
    std::cout << "Container::Container(size_t = 0)" << std::endl;

    intArr = size ? new int[size] : nullptr;
}

Container::Container(const Container &c) : size(c.size)
{
    std::cout << "Container::Container(const Container&)" << std::endl;

    intArr = size ? new int[size] : nullptr;

    for(size_t i = 0; i < size; ++i)
        intArr[i] = c.intArr[i];
        //arr[i]=c[i]; // wo operator [] () const : error C2678: binary '[' : no operator found which takes a left-hand operand of type 'const Container' (or there is no acceptable conversion)
}

Container::Container(Container&& other) : size(0), intArr(nullptr)
{
	std::cout << "Container::Container(Container&&)" << std::endl;

	size = other.size;
	intArr = other.intArr;

	other.size = 0;
	other.intArr = nullptr;
}

Container::~Container(void)
{
    std::cout << "Container::~Container(void)" << std::endl;

	if (intArr)
		delete []intArr;
}

Container& Container::operator = (const Container &other)
{
	std::cout << "Container::operator = (const Container&)" << std::endl;

	if (this != &other)
	{
		if (intArr)
			delete[]intArr;

		size = other.size;
		intArr = size ? new int[size] : nullptr;

		for (size_t i = 0; i < size; ++i)
			intArr[i] = other.intArr[i];
	}

	return *this;
}

Container& Container::operator = (Container&& other)
{
	std::cout << "Container::operator = (Container&&)" << std::endl;

	if (this != &other)
	{
		if (intArr)
			delete []intArr;

		size = other.size;
		intArr = other.intArr;

		other.size = 0;
		other.intArr = nullptr;
	}

	return *this;
}

int& Container::operator [] (int idx) // const
{
    std::cout << "Container::operator [] (int)" << std::endl;

    return intArr[idx];
}
