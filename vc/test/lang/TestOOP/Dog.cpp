#include <iostream>
#include "Dog.h"

Dog::Dog(std::string name) : Animal(name)
{
    std::cout << "Dog::Dog(std::string name = \"" << name << "\")" << std::endl;
}

Dog::Dog(const Dog &dog) : Animal(dog)
{
    std::cout << "Dog::Dog(const Dog &dog (dog.GetName() = \"" << dog.GetName() << "\"))" << std::endl;
}

Dog::~Dog(void)
{
    std::cout << "Dog::~Dog(void)" << std::endl;
}

void Dog::Say(void)
{
    std::cout << "Say(): Gav-Gav!!!" << std::endl;
}