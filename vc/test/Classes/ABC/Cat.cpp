#include "Cat.h"

Cat::Cat(std::string name, std::string smthCatProperty) : Animal(name)
{
    SmthCatProperty = smthCatProperty;
}

std::string Cat::Say(void)
{
    return "Meow";
}
