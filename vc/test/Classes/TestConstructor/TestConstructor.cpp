// TestConstructor.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

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

int _tmain(int argc, _TCHAR* argv[])
{
    A    a1;            // ����������� ���� A()
    A    a2(a1);    // ����������� ����������� A(a1)
    A    a3 = a2;    // ����������� ����������� A(a2)

    B    b;
    A    a4(b);    // ������������� ����������� A(b)
    A    a5 = b;    // ������������� ����������� A(b)

    a1 = a5;    // operator=(const A&) �� ���� operator=(a5)
    a2 = b; // ���1: ��������� ��������� ������ ������ � A
               // � ������� ������������ ���� A(b),
               // ���2: -> operator=(const A&) �� ���� operator=(A(b)) 

    return 0;
}

