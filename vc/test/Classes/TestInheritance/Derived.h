#ifndef DERIVED_H
#define DERIVED_H

#include "Base.h"

class DerivedClass : public BaseClass
{
public:
    int
        z;

    DerivedClass(int=0, int=0, int=0);
    DerivedClass(const DerivedClass&);
    ~DerivedClass(void);

    void ToString(void);

    DerivedClass& operator = (const DerivedClass&);

    friend bool operator == (const DerivedClass&, const DerivedClass&);
    friend bool operator != (const DerivedClass&, const DerivedClass&);

    friend std::ostream& operator << (std::ostream&, const DerivedClass&);
};

#endif
