#include <iostream>

#pragma pack(push, 1)
struct Struct1
{
	char fChar1;
	int fInt1;
	char fChar2[3];
	long fLong1;
	char fChar3[5];
};
#pragma pack(pop)

#pragma pack(push, 2)
struct Struct2
{
	char fChar1;
	int fInt1;
	char fChar2[3];
	long fLong1;
	char fChar3[5];
};
#pragma pack(pop)

#pragma pack(push, 4)
struct Struct4
{
	char fChar1;
	int fInt1;
	char fChar2[3];
	long fLong1;
	char fChar3[5];
};
#pragma pack(pop)

#pragma pack(push, 8)
struct Struct8
{
	char fChar1;
	int fInt1;
	char fChar2[3];
	long fLong1;
	char fChar3[5];
};
#pragma pack(pop)

#pragma pack(push, 16)
struct Struct16
{
	char fChar1;
	int fInt1;
	char fChar2[3];
	long fLong1;
	char fChar3[5];
};
#pragma pack(pop)

int main(int argc, char **argv)
{
	unsigned int size = sizeof(Struct1);
	std::cout << 1 << " sizeof() " << size << std::endl;
	Struct1 struct1;
	std::cout << "offset fChar1 " << (int)(&struct1.fChar1) - (int)(&struct1) << std::endl;
	std::cout << "offset fInt1 " << (int)(&struct1.fInt1) - (int)(&struct1) << std::endl;
	std::cout << "offset fChar2 " << (int)(&struct1.fChar2) - (int)(&struct1) << std::endl;
	std::cout << "offset fLong1 " << (int)(&struct1.fLong1) - (int)(&struct1) << std::endl;
	std::cout << "offset fChar3 " << (int)(&struct1.fChar3) - (int)(&struct1) << std::endl;
	std::cout << std::endl;

	size = sizeof(Struct2);
	std::cout << 2 << " sizeof() " << size << std::endl;
	Struct2 struct2;
	std::cout << "offset fChar1 " << (int)(&struct2.fChar1) - (int)(&struct2) << std::endl;
	std::cout << "offset fInt1 " << (int)(&struct2.fInt1) - (int)(&struct2) << std::endl;
	std::cout << "offset fChar2 " << (int)(&struct2.fChar2) - (int)(&struct2) << std::endl;
	std::cout << "offset fLong1 " << (int)(&struct2.fLong1) - (int)(&struct2) << std::endl;
	std::cout << "offset fChar3 " << (int)(&struct2.fChar3) - (int)(&struct2) << std::endl;
	std::cout << std::endl;

	size = sizeof(Struct4);
	std::cout << 4 << " sizeof() " << size << std::endl;
	Struct4 struct4;
	std::cout << "offset fChar1 " << (int)(&struct4.fChar1) - (int)(&struct4) << std::endl;
	std::cout << "offset fInt1 " << (int)(&struct4.fInt1) - (int)(&struct4) << std::endl;
	std::cout << "offset fChar2 " << (int)(&struct4.fChar2) - (int)(&struct4) << std::endl;
	std::cout << "offset fLong1 " << (int)(&struct4.fLong1) - (int)(&struct4) << std::endl;
	std::cout << "offset fChar3 " << (int)(&struct4.fChar3) - (int)(&struct4) << std::endl;
	std::cout << std::endl;

	size = sizeof(Struct8);
	std::cout << 8 << " sizeof() " << size << std::endl;
	Struct8 struct8;
	std::cout << "offset fChar1 " << (int)(&struct8.fChar1) - (int)(&struct8) << std::endl;
	std::cout << "offset fInt1 " << (int)(&struct8.fInt1) - (int)(&struct8) << std::endl;
	std::cout << "offset fChar2 " << (int)(&struct8.fChar2) - (int)(&struct8) << std::endl;
	std::cout << "offset fLong1 " << (int)(&struct8.fLong1) - (int)(&struct8) << std::endl;
	std::cout << "offset fChar3 " << (int)(&struct8.fChar3) - (int)(&struct8) << std::endl;
	std::cout << std::endl;

	size = sizeof(Struct16);
	std::cout << 16 << " sizeof() " << size << std::endl;
	Struct16 struct16;
	std::cout << "offset fChar1 " << (int)(&struct16.fChar1) - (int)(&struct16) << std::endl;
	std::cout << "offset fInt1 " << (int)(&struct16.fInt1) - (int)(&struct16) << std::endl;
	std::cout << "offset fChar2 " << (int)(&struct16.fChar2) - (int)(&struct16) << std::endl;
	std::cout << "offset fLong1 " << (int)(&struct16.fLong1) - (int)(&struct16) << std::endl;
	std::cout << "offset fChar3 " << (int)(&struct16.fChar3) - (int)(&struct16) << std::endl;
	std::cout << std::endl;

	return 0;
}