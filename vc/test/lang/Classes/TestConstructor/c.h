#ifndef C_H
#define C_H

#include "a.h"

class C
{
public:
	A
		a;

	C(int = 0, int = 0);
	C(const C&);
	C(const A&);
	virtual ~C(void);

	C& operator = (const C&);
};

#endif
