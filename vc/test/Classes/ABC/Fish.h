#ifndef FISH_H
#define FISH_H

#include "stdafx.h"
#include <string>

class Fish : public Animal
{
public:
    Fish(std::string name = "WithoutName");
};

#endif