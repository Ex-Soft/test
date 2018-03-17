#ifndef CONTAINER_H
#define CONTAINER_H

#include "a.h"

class Container
{
    int
        size;

    A
        *arr;

public:
    Container(int=0);
    Container(const Container&);
    ~Container(void);

    A& operator [] (int) /* const */;
};

#endif
