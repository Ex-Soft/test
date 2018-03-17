#include <iostream>
#include <iomanip>

int main(int argc, char **argv, char **envp)
{
	char *programName = *argv;
	char *firstParam = argc > 1 ? *(argv + 1) : 0;

	std::cout << "argv " << std::hex << std::setiosflags(std::ios::showbase) << (int)argv << std::endl;
	std::cout << "*argv " << std::hex << std::setiosflags(std::ios::showbase) << (int)*argv << std::endl;

	for (int i = 0; i < argc; ++i)
		std::cout << "\"" << *(argv + i) << "\"" << std::endl;
}