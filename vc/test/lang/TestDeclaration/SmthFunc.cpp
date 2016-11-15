#include "SmthFunc.h"

int Add(int left, int right)
{
	return left + right;
}

int Subtract(int left, int right)
{
	return left - right;
}

#ifdef USE_TYPEDEF
	IntPtrToFuncIntInt GetFunc(char operation)
#else
	int(*GetFunc(char operation))(int, int)
#endif
{
	switch (operation)
	{
		case '+':
			{
				return Add;
			}
		case '-':
			{
				return Subtract;
			}
	}
}
