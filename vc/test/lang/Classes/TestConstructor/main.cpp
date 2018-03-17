#include <iostream>

class B
{
public:
    int
        b;
};

class A
{
    int
        a;

    public:
        A(int _a=0) : a(_a)
        {
            std::cout<<"A::A(int=0)"<<std::endl;
        }

        A(const A& a_obj) : a(a_obj.a)
        {
            std::cout<<"A::A(const A&)"<<std::endl;
        }

        A(const B& b_obj) :  a(b_obj.b)
        {
            std::cout<<"A::A(const B&)"<<std::endl;
        }

        A& operator = (const A& aA)
        {
            std::cout<<"A::operator = (const A&)"<<std::endl;

            if(this!=&aA)
                a=aA.a;

            return(*this);
        }
};

int main(int argc, char **argv)
{
	A    a1;            // конструктор вида A()
	A    a2(a1);    // конструктор копирования A(a1)
	A    a3 = a2;    // конструктор копирования A(a2)

	B    b;
	A    a4(b);    // перегруженный конструктор A(b)
	A    a5 = b;    // перегруженный конструктор A(b)

	a1 = a5;    // operator=(const A&) то есть operator=(a5)
	a2 = b; // Шаг1: создается временный объект класса а A
			// с помощью конструктора вида A(b),
			// Шаг2: -> operator=(const A&) то есть operator=(A(b))

	return 0;
}
