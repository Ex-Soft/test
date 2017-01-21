#include <iostream>

int main(int argc, char **argv)
{
	int arr[5] = { 1, 2, 3, 4, 5 };

	for (auto &x : arr)
		std::cout << x << std::endl;

	return 0;
}