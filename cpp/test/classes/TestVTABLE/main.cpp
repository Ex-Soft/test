// http://www.sql.ru/forum/1293891/virtual-methods

class A {
public :
    virtual void m() {
        std::cout << "A\n";
    }

    virtual ~A() {
        std::cout << "~A\n";
    }
};

class B : public A {
public :
    void m() override {
        std::cout << "B\n";
    }

    virtual ~B() {
        std::cout << "~B\n";
    }
};

class C : public B {
public :
    void m() override {
        std::cout << "C\n";
    }

    virtual ~C() {
        std::cout << "~C\n";
    }
};

int main() {
    A *o = new C();
    o->m();
    delete o;

    typedef void (*PMethodProto)(void*);  // -- (void*) - неявный параметр this
    A* a = new A();
    C* c = new C();
    PMethodProto **pVTBL = reinterpret_cast<PMethodProto**>(c);
    (*pVTBL)[0](pVTBL);
    *pVTBL = *reinterpret_cast<PMethodProto**>(a);
    (*pVTBL)[0](pVTBL);
    delete c;
}