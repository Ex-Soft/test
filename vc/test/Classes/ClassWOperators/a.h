#ifndef A_H
#define A_H

#include "stdafx.h"

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
    friend A operator + (const A& left, const A& right);
    friend A operator + (const A& left, int right);

    friend std::ostream& operator << (std::ostream& os, const A&);
};

#endif