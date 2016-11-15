// TestVirtualDestructor.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

class A
{
public:
    A() { cout<<"A()"<<endl; }
    ~A() { cout<<"~A()"<<endl; }
};

class B : public A
{
public:
    B() { cout<<"B()"<<endl; }
    ~B() { cout<<"~B()"<<endl; }
};

class C : public B
{
public:
    C() { cout<<"C()"<<endl; }
    ~C() { cout<<"~C()"<<endl; }
};

class AV
{
public:
    AV() { cout<<"AV()"<<endl; }
    virtual ~AV() { cout<<"~AV()"<<endl; }
};

class BV : public AV
{
public:
    BV() { cout<<"BV()"<<endl; }
    ~BV() { cout<<"~BV()"<<endl; }
};

class CV : public BV
{
public:
    CV() { cout<<"CV()"<<endl; }
    ~CV() { cout<<"~CV()"<<endl; }
};

class Cat
{
public:
    virtual ~Cat() { sayGoodbye(); }

    void askForFood() const
    {
        speak();
        eat();
    }

    virtual void speak() const { cout << "Meow! "; }
    virtual void eat() const { cout << "*champing*" << endl; }
    virtual void sayGoodbye() const { cout << "Meow-meow!" << endl; }
};

class CheshireCat : public Cat
{
public:
    virtual void speak() const { cout << "WTF?! Where\'s my milk? =) "; }
    virtual void sayGoodbye() const { cout << "Bye-bye! (:" << endl; }
};

int _tmain(int argc, _TCHAR* argv[])
{
    //C c;

    cout<<endl;
    A *aPtr = new C;
    delete aPtr;

    cout<<endl;
    AV *avPtr = new CV;
    delete avPtr;

    cout<<endl;
    Cat *cats[] = { new Cat, new CheshireCat };

    cout << "Ordinary Cat: "; cats[0]->askForFood();
    cout << "Cheshire Cat: "; cats[1]->askForFood();

    delete cats[0]; delete cats[1];

	return 0;
}
