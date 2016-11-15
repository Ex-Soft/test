#include <iostream>
#include "Cat.h"

Cat::Cat(std::string name) : Animal(name)
{
    std::cout << "Cat::Cat(std::string name = \"" << name << "\")" << std::endl;
}

Cat::Cat(const Cat &cat) : Animal(cat)
{
    std::cout << "Cat::Cat(const Cat &cat (cat.GetName() = \"" << cat.GetName() << "\"))" << std::endl;
}

Cat::~Cat(void)
{
    std::cout << "Cat::~Cat(void)" << std::endl;
}

void Cat::Say(void)
{
    std::cout << "Say(): Meow-Meow!!!" << std::endl;
}

void Cat::SaySay(void)
{
    std::cout << "SaySay(): Meow-Meow-Meow-Meow!!!" << std::endl;
}