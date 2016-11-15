#ifndef DOG_H
#define DOG_H

#include "stdafx.h"
#include <string>

class Dog : public Animal
{
public:
    Dog(std::string name = "WithoutName");
    std::string Say(void);
};

#endif