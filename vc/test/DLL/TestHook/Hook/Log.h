#ifndef __LOG_H__
#define __LOG_H__

#include <fstream>

class Log
{
	std::fstream _log;
	std::string _fileName;

public:
	Log(char *fileName = 0);
	~Log();

	void Write(std::string message);
};

#endif
