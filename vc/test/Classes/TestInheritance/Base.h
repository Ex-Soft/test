#ifndef BASE_H
#define BASE_H

#include <iostream>

class BaseClass
{
public:
    int
        x,
        y;

    BaseClass(int=0, int=0);
    BaseClass(const BaseClass&);
    virtual ~BaseClass(void);

    virtual void ToString(void);
    virtual void ShowTypeId(void);

    BaseClass& operator = (const BaseClass&);

    friend bool operator == (const BaseClass&, const BaseClass&);
    friend bool operator != (const BaseClass&, const BaseClass&);

    friend std::ostream& operator << (std::ostream&, const BaseClass&);
};

#endif
