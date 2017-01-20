#include <Windows.h>
#include <iostream>
#include "..\TestDLL\Data.h"

int main()
{
	TCHAR szPath[MAX_PATH];
	DWORD length;

	if (!(length = GetModuleFileName(NULL, szPath, MAX_PATH)))
	{
		std::cout << "!GetModuleFileName" << std::endl;
		return 0;
	}
	else
		std::cout << szPath << std::endl;

	HINSTANCE
		dllInstance = 0;

	void (*TestData)(Data *);
	void (*TestArrayOfData)(Data *, int);

	if (!(dllInstance = LoadLibrary(TEXT("TestDLL.dll"))))
		return 0;

	if (TestData = (void(*)(Data *))GetProcAddress(dllInstance, "TestData"))
	{
		Data data = { 1, 2 };
		TestData(&data);
	}

	if (TestArrayOfData = (void(*)(Data *, int))GetProcAddress(dllInstance, "TestArrayOfData"))
	{
		Data arrayOfData[] = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
		TestArrayOfData(arrayOfData, 3);
	}

	if (dllInstance)
		FreeLibrary(dllInstance);

    return 0;
}

