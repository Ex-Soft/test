#ifndef _F_H_
#pragma message ("_F_H_ isn\'t defined")
#else
#pragma message ("_F_H_ is defined")
#endif

#include "f.h"
#include "f.h"

#ifndef _F_H_
#pragma message ("_F_H_ isn\'t defined")
#else
#pragma message ("_F_H_ is defined")
#endif

#define SQUARE(x) x*x

#include "SmthFunc.h"

int main(int argc, char** argv)
{
        f();
        int r = SQUARE(4+1);

		r = Add(2, 3);
		r = Subtract(5, 2);

		#ifdef USE_TYPEDEF
			IntPtrToFuncIntInt fPtr;
		#else
			int (*fPtr)(int, int);
		#endif

		fPtr = Add;
		fPtr(7, 8);

		fPtr = GetFunc('-');
		fPtr(11, 8);

		r = GetFunc('+')(8, 2);
}
