#include <list>
#include <iostream>

int main()
{
	std::list<int> listOfInt = { 0, 1, 2 };
	
	std::list<int>::iterator end = listOfInt.end();
	for (std::list<int>::iterator i = listOfInt.begin(); i != end; ++i)
		std::cout << *i << std::endl;

	for (int i : listOfInt)
		std::cout << i << std::endl;
}