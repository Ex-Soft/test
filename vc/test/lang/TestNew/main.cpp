#define _CRT_SECURE_NO_WARNINGS

#define TEST_PLACEMENT_NEW
//#define TEST_NEW_IN_FUNCTION

#include <new>
#include <iostream>
#include <iomanip>

#ifdef TEST_PLACEMENT_NEW
	#include "a.h"
#endif

#ifdef TEST_NEW_IN_FUNCTION

	char *getBuffOfChar();

#endif

int main(int argc, char **argv)
{
	#ifdef TEST_PLACEMENT_NEW

		const int size = 5, index = 3;
		static int array[size];
		void *destination = reinterpret_cast<void *>(array + index);
		int *ptr = 0;

		try
		{
			ptr = new(destination) int;
		}
		catch (std::bad_alloc &ba)
		{
			std::cout << "Insufficient memory (" << ba.what() << ")" << std::endl;
		}

		if (ptr)
		{
			*ptr = 0x0ffff;
			std::cout << ptr << " " << std::hex << *ptr << std::endl;

			for (int i = 0; i < size; ++i)
				std::cout << &array[i] << " array[" << i << "] = " << std::hex << array[i] << std::dec << std::endl;
		}

		char *buff = 0;

		try
		{
			buff = new char[sizeof(A)];

			A *a = new(buff) A(13, 26);
			a->~A();
		}
		catch (std::bad_alloc &ba)
		{
			std::cout << "Insufficient memory (" << ba.what() << ")" << std::endl;
		}

		if (buff)
			delete []buff;

	#endif

	#ifdef TEST_NEW_IN_FUNCTION

		char *buff = 0;
		if (buff = getBuffOfChar())
		{
			delete[]buff;
			buff = 0;
		}

	#endif

	return 0;
}

#ifdef TEST_NEW_IN_FUNCTION

	char *getBuffOfChar()
	{
		char *result = new char[255];
		strcpy(result, "1st 2nd 3rd");
		return result;
	}

#endif
