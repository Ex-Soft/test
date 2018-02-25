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

void Fill(TestStruct *, int);
void WriteBinary(TestStruct *, int);
void ReadBinary(TestStruct *, int);
void ReadBinary(TestStruct *, int, int);

void WriteText(int maxSize);
void ReadText(void);

struct Item
{
	int fInt;
	long fLong;
	char fChar[MaxCharSize];
	Item *prev, *next;
};

Item * Fill(int);
void WriteBinary(Item *);
Item * ReadBinary(void);
Item * ReadBinary(int);
void Free(Item *);

int main(int argc, char **argv)
{
	TestStruct
		outTestStruct[MaxSize],
		inTestStruct[MaxSize],
		inTestStructPos;

	Fill(outTestStruct, MaxSize);

	WriteBinary(outTestStruct, MaxSize);

	ReadBinary(inTestStruct, MaxSize);
	ReadBinary(&inTestStructPos, MaxSize, MaxSize - 1);

	WriteText(MaxSize);
	ReadText();

	Item
		*outItems = Fill(MaxSize),
		*inItems,
		*inItemPos;

	WriteBinary(outItems);
	inItems = ReadBinary();
	inItemPos = ReadBinary(MaxSize - 1);

	Free(outItems);
	Free(inItems);

	if (inItemPos)
		delete inItemPos;

	return 0;
}

void Fill(TestStruct *testStructs, int maxSize)
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

Item * Fill(int maxSize)
{
	Item
		*item = 0,
		*head = 0,
		*prev = 0;

	char buff[10];

	for (int i = 0; i < maxSize; ++i)
	{
		item = new Item;

		if (!head)
			head = item;

		item->fInt = i;
		item->fLong = i;

#pragma warning(disable:4996)
		itoa(i, buff, 10);
#pragma warning(default:4996)

		strcpy(item->fChar, buff);

		item->next = 0;
		item->prev = prev;
		if (item->prev)
			item->prev->next = item;

		prev = item;
	}

	return head;
}

void WriteBinary(Item *items)
{
	std::ofstream file("data2.dat", std::ios_base::out | std::ios_base::binary);
	if (!file.is_open() || !file.good())
		return;

	Item *item = items;
	while(item)
	{
		file.write((char *)item, sizeof(Item) - sizeof(Item *) * 2);
		item = item->next;
	}
	file.close();
}

Item * ReadBinary(void)
{
	Item
		*item = 0,
		*head = 0,
		*prev = 0;

	std::ifstream file("data2.dat", std::ios_base::in | std::ios_base::binary);
	if (!file.is_open() || !file.good())
		return head;

	while (!file.eof())
	{
		item = new Item;

		file.read((char *)item, sizeof(Item) - sizeof(Item *) * 2);

		std::cout << "file.good()=" << file.good() << " " << "file.eof()=" << file.eof() << std::endl;
		
		if (!file.good() && !file.eof())
		{
			std::cout << "Data read error" << std::endl;
			delete item;
			break;
		}

		if (file.eof())
		{
			delete item;
			break;
		}

		if (!head)
			head = item;

		item->next = 0;
		item->prev = prev;
		if (item->prev)
			item->prev->next = item;

		prev = item;
	}

	file.close();

	return head;
}

Item * ReadBinary(int position)
{
	std::ifstream file("data2.dat", std::ios_base::in | std::ios_base::binary);
	if (!file.is_open() || !file.good())
		return 0;

	unsigned int sizeOfItem = sizeof(Item) - sizeof(Item *) * 2;
	std::streampos begin = file.tellg();
	long fileSize;

	file.seekg(0, std::ios_base::end);
	fileSize = file.tellg() - begin;

	if ((position + 1) * sizeOfItem > fileSize)
	{
		file.close();
		return 0;
	}

	file.seekg(position * sizeOfItem, std::ios_base::beg);

	Item *item = new Item;

	file.read((char *)item, sizeOfItem);

	std::cout << "file.good()=" << file.good() << " " << "file.eof()=" << file.eof() << std::endl;

	if (!file.good() && !file.eof())
	{
		std::cout << "Data read error" << std::endl;
		file.close();
		delete item;
		return 0;
	}

	if (file.eof())
	{
		file.close();
		delete item;
		return 0;
	}

	file.close();

	item->next = 0;
	item->prev = 0;

	return item;
}

void Free(Item *items)
{
	Item
		*item = items,
		*next = 0;

	while (item)
	{
		next = item->next;
		delete item;
		item = next;
	}
}
