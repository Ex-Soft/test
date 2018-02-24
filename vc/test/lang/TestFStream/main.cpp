#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <fstream>

const int
	MaxCharSize = 20,
	MaxSize = 5;

struct TestStruct
{
	int fInt;
	long fLong;
	char fChar[MaxCharSize];
};

void FillStruct(TestStruct *, int);
void WriteBinary(TestStruct *, int);
void ReadBinary(TestStruct *, int);
void ReadBinary(TestStruct *, int, int);

void WriteText(int maxSize);
void ReadText(void);

int main(int argc, char **argv)
{
	TestStruct
		outTestStruct[MaxSize],
		inTestStruct[MaxSize],
		inTestStructPos;

	FillStruct(outTestStruct, MaxSize);

	WriteBinary(outTestStruct, MaxSize);

	ReadBinary(inTestStruct, MaxSize);
	ReadBinary(&inTestStructPos, MaxSize, MaxSize - 1);

	WriteText(MaxSize);
	ReadText();

	return 0;
}

void FillStruct(TestStruct *testStructs, int maxSize)
{
	char buff[10];

	for (int i = 0; i < maxSize; ++i)
	{
		(testStructs + i)->fInt = i;
		(testStructs + i)->fLong = i;

#pragma warning(disable:4996)
		itoa(i, buff, 10);
#pragma warning(default:4996)

		strcpy((testStructs + i)->fChar, buff);
	}
}

void WriteBinary(TestStruct *testStructs, int maxSize)
{
	std::ofstream file("data.dat", std::ios_base::out | std::ios_base::binary);
	if (!file.is_open() || !file.good())
		return;

	for (int i = 0; i < maxSize; ++i)
		file.write((char *)(testStructs + i), sizeof(TestStruct));
	file.close();
}

void ReadBinary(TestStruct *testStructs, int maxSize)
{
	std::ifstream file("data.dat", std::ios_base::in | std::ios_base::binary);
	if (!file.is_open() || !file.good())
		return;

	for (int i = 0; i < maxSize; ++ i)
		file.read((char *)(testStructs + i), sizeof(TestStruct));
	file.close();
}

void ReadBinary(TestStruct *testStruct, int maxSize, int position)
{
	if (position >= maxSize)
		return;

	std::ifstream file("data.dat", std::ios_base::in | std::ios_base::binary);
	if (!file.is_open() || !file.good())
		return;

	file.seekg(position * sizeof(TestStruct), std::ios_base::beg);
	file.read((char *)testStruct, sizeof(TestStruct));
	file.close();
}

void WriteText(int maxSize)
{
	std::ofstream file("data.txt", std::ios_base::out);
	if (!file.is_open() || !file.good())
		return;

	char buff[10];

	for (int i = 0; i < maxSize; ++i)
	{
#pragma warning(disable:4996)
		itoa(i, buff, 10);
#pragma warning(default:4996)

		file << buff;

		if (i < maxSize - 1)
			file << std::endl;
	}

	file.close();
}

void ReadText(void)
{
	std::ifstream file("data.txt", std::ios_base::in);
	if (!file.is_open() || !file.good())
		return;

	char *buff = 0;
	unsigned int buffSize = 0xffff;

	while (!buff && buffSize)
	{
		buff = new char[buffSize];
		if (!buff)
			buffSize >>= 1;
	}
	
	if (!buff && !buffSize)
	{
		std::cout << "Insufficient memory" << std::endl;
		file.close();
		return;
	}

	while (!file.eof())
	{
		file.getline(buff, buffSize);

		std::cout << "file.good()=" << file.good() << " " << "file.eof()=" << file.eof() << std::endl;

		if (!file.good() && !file.eof())
		{
			std::cout << "Data read error" << std::endl;
			break;
		}

		std::cout << "\"" << buff << "\"" << std::endl;
	}

	delete []buff;
	file.close();
}
