#ifndef _SmthFunc_H_
#define _SmthFunc_H_

#ifdef USE_TYPEDEF
	typedef int (*IntPtrToFuncIntInt)(int, int);
#endif

int Add(int, int);
int Subtract(int, int);

#ifdef USE_TYPEDEF
	IntPtrToFuncIntInt GetFunc(char);
#else
	int(*GetFunc(char))(int, int);
#endif

#endif