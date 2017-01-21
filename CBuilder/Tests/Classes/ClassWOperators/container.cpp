#include <iostream>

#include "container.h"

using namespace std;

Container::Container(int aSize) : size(aSize)
{
    cout<<"Container::Container(int)"<<endl;
    arr = new ClassWOperators[size];
}

Container::Container(const Container &c) : size(c.size)
{
    cout<<"Container::Container(const Container&)"<<endl;
    delete []arr;
    arr = new ClassWOperators[size];
    for(int i=0; i<size; ++i)
        arr[i]=c.arr[i];
        //arr[i]=c[i]; // wo operator [] () const : error C2678: binary '[' : no operator found which takes a left-hand operand of type 'const Container' (or there is no acceptable conversion)
}

Container::~Container(void)
{
    cout<<"Container::~Container(void)"<<endl;
    delete []arr;
}

ClassWOperators & Container::operator [] (int idx) // const
{
    cout<<"Container::operator [] (int)"<<endl;

    return arr[idx];
}
