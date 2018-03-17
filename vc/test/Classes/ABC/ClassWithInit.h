#ifndef __CLASS_WITH_INIT__
#define __CLASS_WITH_INIT__

class ClassWithInit
{
	int
		mInt1,
		mInt2,
		mInt3;

	void Init(int = 0, int = 0, int = 0);
public:
	ClassWithInit();
	ClassWithInit(int);
	ClassWithInit(int, int);
	ClassWithInit(int, int, int);
	ClassWithInit(const ClassWithInit &);
	virtual ~ClassWithInit();
};

#endif
