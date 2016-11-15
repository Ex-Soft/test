#include <iostream>
#include "Animal.h"

Animal::Animal(std::string name)
{
    std::cout << "Animal::Animal(std::string name = \"" << name << "\")" << std::endl;
    Name = name;
}

Animal::Animal(const Animal &animal)
{
    std::cout << "Animal::Animal(const Animal &animal (animal.Name = \"" << animal.Name << "\"))" << std::endl;
    Name = animal.Name;
}

Animal::~Animal(void)
{
    std::cout << "Animal::~Animal(void)" << std::endl;
}

void Animal::SetName(std::string name)
{
    if(name == "dick")
    {
        std::cout << "SetName(): Invalid name" << std::endl;
        return;
    }

    Name = name;
}

std::string Animal::GetName(void) const
{
    return Name;
}

void Animal::Say(void)
{
    std::cout << "Say(): Nothing" << std::endl;
}

void Animal::SaySay(void)
{
    std::cout << "SaySay(): NothingNothing" << std::endl;
}