#include "stdafx.h"

Animal::Animal(std::string name)
{
    Name = name;
}

void Animal::SetName(std::string name)
{
    Name = name;
}

std::string Animal::GetName(void)
{
    return Name;
}

std::string Animal::Say(void)
{
    return "Nothing";
}