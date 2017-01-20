#include <Windows.h>
#include "Log.h"

Log::Log(char *fileName)
{
	DWORD tickCount = GetTickCount();
	char buffer[MAX_PATH];

	_fileName = fileName ? fileName : std::string(itoa(tickCount, buffer, 10)) + ".log";
}

Log::~Log()
{
	if (_log.is_open())
		_log.close();
}

void Log::Write(std::string message)
{
	if (!_log.is_open())
		_log.open(_fileName.c_str(), std::ios_base::out | std::ios_base::trunc);

	DWORD tickCount = GetTickCount();

	if (_log.good())
		_log << tickCount << " " << message.c_str() << std::endl;
}
