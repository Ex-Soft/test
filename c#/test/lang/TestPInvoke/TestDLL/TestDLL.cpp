#include "Log.h"
#include "TestDLL.h"

extern Log *_log;

void DLL_EI cdecl TestData(Data *data)
{
	char buffer[0xff];
	std::string message = std::string("TestData(Data *)");

	#pragma warning(disable:4996)
		message += std::string(" ") + std::string("{fInt1:") + std::string(itoa(data->fInt1, buffer, 10)) + std::string(", fInt2:") + std::string(itoa(data->fInt2, buffer, 10))  + std::string("}");
	#pragma warning(default:4996)

	_log->Write(message);
}

void DLL_EI cdecl TestArrayOfData(Data *data, int size)
{
	char buffer[0xff];
	std::string message = std::string("TestArrayOfData(Data *, int){");

	for (int i = 0; i < size; ++i)
	{
		#pragma warning(disable:4996)
			message += std::string("{fInt1:") + std::string(itoa((data + i)->fInt1, buffer, 10)) + std::string(", fInt2:") + std::string(itoa((data + i)->fInt2, buffer, 10)) + std::string("},");
		#pragma warning(default:4996)
	}
	message += std::string("}");

	_log->Write(message);
}
