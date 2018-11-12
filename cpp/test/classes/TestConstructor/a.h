#ifndef A_H
#define A_H

#include "b.h"

class A
{
public:
	int
		x,
		y;

	A(int = 0, int = 0);
	A(const A&);
	A(const B&);
	virtual ~A(void);

	A& operator = (const A&);
};

#endif
