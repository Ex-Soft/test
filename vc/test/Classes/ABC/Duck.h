#ifndef DUCK_H
#define DUCK_H

#include "stdafx.h"
#include <string>

class Duck : public Animal
{
public:
    Duck(std::string name = "WithoutName");
    std::string Say(void);
};

#endif