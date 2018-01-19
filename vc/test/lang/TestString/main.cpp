#include <iostream>

int main(int argc, char **argv)
{
	char input[] = "   1st     2nd    3rd   ";
	char *token = strtok(input, " ");
	while (token)
	{
		std::cout << token << std::endl;
		token = strtok(NULL, " ");
	}

	const int BuffSize = 0x0ffff;

	char *str1 = 0, *str2 = 0, *subString = 0;

	try
	{
		str1 = new char[BuffSize];
		str2 = new char[BuffSize];
		subString = new char[BuffSize];
	}
	catch (std::bad_alloc &e)
	{
		std::cout << "Insufficient memory (" << e.what() << ")" << std::endl;

		if (str1)
			delete []str1;
		if (str2)
			delete []str2;
		if (subString)
			delete []subString;

		return 1;
	}

	std::cout << "=> ";
	std::cin.getline(str1, BuffSize);
	if (!std::cin.good())
	{
		std::cout << "Invalid input" << std::endl;
		delete []str1;
		delete []str2;
		delete []subString;

		return 2;
	}
	std::cout << "\"" << str1 << "\"" << std::endl;

	std::cout << "=> ";
	std::cin.getline(str2, BuffSize);
	if (!std::cin.good())
	{
		std::cout << "Invalid input" << std::endl;
		delete []str1;
		delete []str2;
		delete []subString;

		return 2;
	}
	std::cout << "\"" << str2 << "\"" << std::endl;

	int len = strlen(str1);
	char *begin = 0, *end = 0;

	for (int i = 0; i < len; ++i)
	{
		
		if (!begin && !isspace(*(str1 + i)) && (!i || isspace(*(str1 + i - 1))))
			begin = str1 + i;
		if (begin && ((!end && i == len - 1) || (!isspace(*(str1 + i)) && i + 1 < len && isspace(*(str1 + i + 1)))))
			end = str1 + i;
		if (begin && end)
		{
			int num;

			strncpy(subString, begin, num = end - begin + 1);
			*(subString + num) = '\x0';

			std::cout << "\"" << subString << "\"" << std::endl;

			char *position;
			while (position = strstr(str2, subString))
				memmove(position, position + num, strlen(position + num) + 1);

			begin = 0;
			end = 0;
		}
	}

	std::cout << "\"" << str2 << "\"" << std::endl;

	delete []str1;
	delete []str2;
	delete []subString;

	return 0;
}
