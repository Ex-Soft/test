#include <iostream>

#include "container.h"

using namespace std;

Container::Container(int aSize) : size(aSize)
{
    //cout<<"Container::Container(int)"<<endl;
    arr = new A[size];
}

Container::Container(const Container &c) : size(c.size)
{
    //cout<<"Container::Container(const Container&)"<<endl;
    delete []arr;
    arr = new A[size];
    for(int i=0; i<size; ++i)
        arr[i]=c.arr[i];
}

Container::~Container(void)
{
    //cout<<"Container::~Container(void)"<<endl;
    delete []arr;
}

A & Container::operator [] (int idx)
{
    cout<<"Container::operator [] (int)"<<endl;

    return arr[idx];
}
