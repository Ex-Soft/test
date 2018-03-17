#ifndef A_H
#define A_H

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
};

#endif
