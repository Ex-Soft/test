#ifndef D_H
#define D_H

class D
{
public:
	int
		x,
		y,
		z;

	D();
	D(int);
	D(int, int);
	D(int, int, int);
	D(const D&);
	virtual ~D(void);

	D& operator = (const D&);
};

#endif
