#ifndef DERIVED_H
#define DERIVED_H

#include "stdafx.h"

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

    friend ostream& operator << (ostream& os, const DerivedClass&);
};

#endif