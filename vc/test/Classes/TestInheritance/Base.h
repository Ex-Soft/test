#ifndef BASE_H
#define BASE_H

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

    friend ostream& operator << (ostream& os, const BaseClass&);
};

#endif