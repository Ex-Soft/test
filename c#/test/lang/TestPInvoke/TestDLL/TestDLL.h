#ifndef TestDllH
#define TestDllH

	#include "Data.h"

	#ifdef TESTDLL_EXPORTS
		#define DLL_EI __declspec(dllexport)
	#else
		#define DLL_EI __declspec(dllimport)
	#endif

	extern "C" void DLL_EI cdecl TestData(Data *);
	extern "C" void DLL_EI cdecl TestArrayOfData(Data *, int size);

#endif