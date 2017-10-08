#include <iostream>
#include <iomanip>
#include <string>

int main(int argc, char **argv)
{
    int
        a = 10,
        b,
        c,
		result;

	std::string
		str;

	std::ios_base::iostate
		state;

	std::streampos
		pos;

	
	// http://www.cplusplus.com/forum/beginner/45543/
	std::cout << "Enter Text: ";
	std::cin >> str;
	//result = std::cin.sync();
	std::cin.ignore(10000, '\n');
	//result = std::cin.sync();
	std::cout << "Enter Number: ";
	std::cin >> b;
	std::cout << "Enter Another Number: ";
	std::cin >> c;
	//result = std::cin.sync();
	///std::cin.ignore(10000, '\n');
	///result = std::cin.sync();
	std::cout << "You Entered: " << str << ", " << b << ", " << c << std::endl;
	//std::cin.clear();
	//result = std::cin.sync();
	//std::cin.ignore(10000, '\n');
	//result = std::cin.sync();

	if (!(std::cin >> b))
	{
		std::cout << "wrong value" << std::endl;

		state = std::cin.rdstate();
		std::cout << "cin.rdstate() " << state << std::endl;

		if (state & std::ios_base::failbit)
			std::cout << "ios_base::failbit" << std::endl;
		if (state & std::ios_base::badbit)
			std::cout << "ios_base::badbit" << std::endl;
		if (state & std::ios_base::goodbit)
			std::cout << "ios_base::goodbit" << std::endl;
		if (state & std::ios_base::eofbit)
			std::cout << "ios_base::eofbit" << std::endl;

		std::cout << "cin.fail() " << std::cin.fail() << std::endl;
		std::cout << "cin.bad() " << std::cin.bad() << std::endl;
		std::cout << "cin.eof() " << std::cin.eof() << std::endl;
		std::cout << "cin.good() " << std::cin.good() << std::endl;

		std::cout << "cin.gcount() " << std::cin.gcount() << std::endl;

		pos = std::cin.tellg();
		result = std::cin.peek();
		//result = std::cin.sync();
		std::cin.clear();
		std::cin >> str;
	}
	
    std::cout << "a=" << std::setw(10) << std::setfill('0') << std::hex << std::setiosflags(std::ios::showbase) << a << std::endl;

    std::cout << "> ";
    std::cin >> b >> c;

    std::cout << "b=" << b << " " << "c=" << c << std::endl;

    return 0;
}