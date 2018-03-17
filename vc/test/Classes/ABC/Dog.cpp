#include "Dog.h"

Dog::Dog(std::string name) : Animal(name)
{
}

std::string Dog::Say(void)
{
    return "Woof-woof";
}
