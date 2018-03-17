#ifndef FISH_H
#define FISH_H

#include <string>
#include "Animal.h"

class Fish : public Animal
{
public:
    Fish(std::string name = "WithoutName");
};

#endif
