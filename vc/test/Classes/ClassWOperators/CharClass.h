#ifndef CharClass_H
#define CharClass_H

#include "stdafx.h"

class CharClass
{
public:
    char
        c;

    CharClass(char='\x0');
    CharClass(int=0);
    CharClass(long=0);
    CharClass(const CharClass&);
    ~CharClass(void);

    friend std::ostream& operator << (std::ostream& os, const CharClass&);
};

#endif