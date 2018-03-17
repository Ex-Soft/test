#ifndef DOG_H
#define DOG_H

#include <string>
#include "Animal.h"

class Dog : public Animal
{
public:
    Dog(std::string name = "WithoutName");
    std::string Say(void);
};

#endif
