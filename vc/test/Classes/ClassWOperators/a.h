#ifndef A_H
#define A_H

#include <iostream>

class A
{
public:
    int
        x,
        y;

    A(int=0, int=0);
    A(const A&);
    ~A(void);

    A& operator = (const A&);

    friend bool operator == (const A&, const A&);
    friend bool operator != (const A&, const A&);
    friend A operator + (const A&, const A&);
    friend A operator + (const A&, int);

    friend std::ostream& operator << (std::ostream&, const A&);
};

#endif
