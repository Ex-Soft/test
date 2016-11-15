#ifndef ANIMAL_H
#define ANIMAL_H

#include "stdafx.h"
#include <string>

class Animal
{
    std::string Name;

public:
    Animal(std::string name = "WithoutName");

    void SetName(std::string name);
    std::string GetName(void);

    virtual std::string Say(void);
};

#endif