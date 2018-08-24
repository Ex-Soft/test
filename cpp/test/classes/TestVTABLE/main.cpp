// http://www.sql.ru/forum/1293891/virtual-methods

#include <iostream>

class A {
public:
    virtual void m() {
        std::cout << "A::m()" << std::endl;
    }

    virtual ~A() {
        std::cout << "A::~A()" << std::endl;
    }
};

class B : public A {
public:
    void m() override {
        std::cout << "B::m()" << std::endl;
    }

    virtual ~B() {
        std::cout << "B::~B()" << std::endl;
    }
};

class C : public B {
public:
    void m() override {
        std::cout << "C::m()" << std::endl;
    }

    virtual ~C() {
        std::cout << "C::~C()" << std::endl;
    }
};

int main() {
    A *o = new C();
    o->m();
    delete o;

    typedef void (*PMethodProto)(void*);  // -- (void*) - неявный параметр this
    A *a = new A();
    C *c = new C();
    PMethodProto **pVTBL = reinterpret_cast<PMethodProto**>(c);
    (*pVTBL)[0](pVTBL);
    *pVTBL = *reinterpret_cast<PMethodProto**>(a);
    (*pVTBL)[0](pVTBL);
    delete c;
}
