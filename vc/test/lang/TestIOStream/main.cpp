#include <iostream>
#include <iomanip>
#include <string>

int main(int argc, char **argv)
{
	const int BuffSize = 0xffff;

	char *buff = 0;

	try
	{
		buff = new char[BuffSize];
	}
	catch (std::bad_alloc &e)
	{
		std::cout << "Insufficient memory (" << e.what() << ")" << std::endl;
	}

	std::cout << "std::cin.get(char* buf, int limit) => ";
	std::cin.get(buff, BuffSize);
	std::cin.ignore(BuffSize, '\n');
	std::cout << "\"" << buff << "\"" << std::endl;

	std::cout << "std::cin.getline(char* buf, int limit) => ";
	std::cin.getline(buff, BuffSize);
	std::cout << "\"" << buff << "\"" << std::endl;

	std::cout << "std::cin.read(char* buf, int limit) => ";
	std::cin.read(buff, BuffSize);

	std::ios_base::iostate state = std::cin.rdstate();

	std::cout << "cin.rdstate() " << state << std::endl;

	if (state & std::ios_base::eofbit)
		std::cout << "ios_base::eofbit" << std::endl;
	if (state & std::ios_base::failbit)
		std::cout << "ios_base::failbit" << std::endl;
	if (state & std::ios_base::badbit)
		std::cout << "ios_base::badbit" << std::endl;
	if (state & std::ios_base::goodbit)
		std::cout << "ios_base::goodbit" << std::endl;

	std::cout << "cin.eof() " << std::cin.eof() << std::endl;
	std::cout << "cin.fail() " << std::cin.fail() << std::endl;
	std::cout << "cin.bad() " << std::cin.bad() << std::endl;
	std::cout << "cin.good() " << std::cin.good() << std::endl;

	std::cout << "cin.eofbit " << std::cin.eofbit << std::endl;
	std::cout << "cin.failbit " << std::cin.failbit << std::endl;
	std::cout << "cin.badbit " << std::cin.badbit << std::endl;

	if (state & (std::ios_base::eofbit | std::ios_base::failbit))
	{
		std::streamsize count = std::cin.gcount();
		*(buff + count) = '\x0';
		std::cin.clear();
		state = std::cin.rdstate();
	}

	std::cout << "\"" << buff << "\"" << std::endl;

	if (buff)
		delete []buff;

    int
        a = 10,
        b,
        c,
		result;

	std::string str;
	std::streampos pos;
		
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

		if (state & std::ios_base::eofbit)
			std::cout << "ios_base::eofbit" << std::endl;
		if (state & std::ios_base::failbit)
			std::cout << "ios_base::failbit" << std::endl;
		if (state & std::ios_base::badbit)
			std::cout << "ios_base::badbit" << std::endl;
		if (state & std::ios_base::goodbit)
			std::cout << "ios_base::goodbit" << std::endl;

		std::cout << "cin.eof() " << std::cin.eof() << std::endl;
		std::cout << "cin.fail() " << std::cin.fail() << std::endl;
		std::cout << "cin.bad() " << std::cin.bad() << std::endl;
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