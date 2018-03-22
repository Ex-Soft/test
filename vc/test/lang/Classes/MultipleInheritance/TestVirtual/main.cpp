#include <iostream>

class IBaseA
{
public:
	virtual void DoA() = 0;
};

class IBaseB
{
public:
	virtual void DoB() = 0;
};

class IBig : virtual public IBaseA, virtual public IBaseB
{
};

class CBaseA : virtual public IBaseA
{
public:
	virtual void DoA()
	{
		std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
	}
};

class CBaseB : virtual public IBaseB
{
public:
	virtual void DoB()
	{
		std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
	}
};

class CBig : public CBaseA, public CBaseB, public IBig
{
};

int main(int argc, char **argv, char **envp)
{
	CBig cb;

	cb.DoA();
	cb.DoB();

	return 0;
}