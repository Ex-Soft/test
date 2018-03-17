class ClassWExplicitConstructor
{
	int
		a;

public:
	explicit ClassWExplicitConstructor(int _a) : a(_a)
	{}
};

class ClassWOExplicitConstructor
{
	int
		a;

public:
	ClassWOExplicitConstructor(int _a) : a(_a)
	{}
};

int main(int argc, char **argv)
{
	ClassWExplicitConstructor
		//cwec = 5; // error C2440: 'initializing' : cannot convert from 'int' to 'ClassWExplicitConstructor'
		cwec = ClassWExplicitConstructor(5);

	ClassWOExplicitConstructor
		cwoec = 5;

	return 0;
}
