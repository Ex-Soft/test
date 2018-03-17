#ifndef __CLASS_WITHOUT_INIT__
#define __CLASS_WITHOUT_INIT__

class ClassWithoutInit
{
	int
		mInt1,
		mInt2,
		mInt3;

public:
	ClassWithoutInit();
	ClassWithoutInit(int);
	ClassWithoutInit(int, int);
	ClassWithoutInit(int, int, int);
	ClassWithoutInit(const ClassWithoutInit &);
	virtual ~ClassWithoutInit();
};

#endif
