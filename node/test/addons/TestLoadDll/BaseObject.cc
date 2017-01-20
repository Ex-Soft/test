#include "BaseObject.h"

BaseObject::BaseObject()
{
  _log = new Log();
  _log->Write("BaseObject::BaseObject()");

  TCHAR buffer[MAX_PATH];
	GetModuleFileName(NULL, buffer, MAX_PATH);
	std::string moduleFileName;

	#ifndef UNICODE
	  moduleFileName = buffer;
	#else
		std::wstring wStr = buffer;
		moduleFileName = std::string(wStr.begin(), wStr.end());
	#endif

	_log->Write(moduleFileName);

  if (dllInstance = LoadLibrary(TEXT("SimpleDLL.dll")))
  {
      _log->Write("dll has been loaded");

      ptrSayHelloFunc = (tSayHelloFunc *)GetProcAddress(dllInstance, "SayHello");
  }
  else
  {
    HLOCAL hLocal = NULL;
    DWORD dwError = GetLastError();
    char b[10];
    itoa(dwError, b, 10);
    _log->Write(b);

    BOOL fOk = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ALLOCATE_BUFFER, NULL, dwError, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPTSTR)&hLocal, 0, NULL);

 		if (fOk)
		{
      if(hLocal)
      {
			PCTSTR message = (PCTSTR)LocalLock(hLocal);
      _log->Write(message);
			LocalFree(hLocal);
      }
		}
    else
    {
      dwError = GetLastError();
      itoa(dwError, b, 10);
      std::string m = "!fOk ";
      m += b;
      _log->Write(m);
    }
  }
}

BaseObject::BaseObject(const BaseObject &obj)
{
  _log = new Log();
  _log->Write("BaseObject::BaseObject(const BaseObject &obj)");

  if (dllInstance = LoadLibrary(TEXT("SimpleDLL.dll")))
  {
    _log->Write("dll has been loaded");
    ptrSayHelloFunc = (tSayHelloFunc *)GetProcAddress(dllInstance, "SayHello");
  }
  else
    _log->Write("dll has not been loaded");
}

BaseObject::~BaseObject(void)
{
  if (dllInstance)
		FreeLibrary(dllInstance);

  if(_log)
  {
    _log->Write("BaseObject::~BaseObject()");
    delete _log;
  }
}

void BaseObject::SayHello(void)
{
  if (ptrSayHelloFunc)
    ptrSayHelloFunc();
}
