#include <new>
#include <iostream>
#include <iomanip>

int main(int argc, char **argv)
{
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
			std::cout << &array[i] << " array[" << i << "] = " << std::hex << array[i] << std::endl;
	}

	return 0;
}