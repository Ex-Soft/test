#ifndef CONTAINER_H
#define CONTAINER_H

#include "ClassWOperators.h"

class Container
{
    int
        size;

    ClassWOperators
        *arr;

public:
    Container(int=0);
    Container(const Container&);
    ~Container(void);

    ClassWOperators& operator [] (int) /* const */;
};

#endif
