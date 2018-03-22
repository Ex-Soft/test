#include <iostream>

class V
{
	int i;
public:
	V(int aI = 0) : i(aI) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
	V(const V &v) : V(v.i) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
	virtual ~V(void) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };

	void f(void) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
};

class A : virtual public V
{
	int i;
public:
	A(int aI = 0) : V(aI) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
	A(const A &a) : V(a.i) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
	virtual ~A(void) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };

	void f(void) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
};

class B : virtual public V
{
	int i;
public:
	B(int aI = 0) : V(aI) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
	B(const B &b) : V(b.i) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
	virtual ~B(void) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };

	void f(void) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
};

class C : public A, public B
{
public:
	C(int aI = 0) : V(aI), A(aI), B(aI) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
	virtual ~C(void) { std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl; };
};

int main(int argc, char **argv, char **envp)
{
	C c(1);

	c.V::f();
	c.A::f();
	c.B::f();

	return 0;
}
