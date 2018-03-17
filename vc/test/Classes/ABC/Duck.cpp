#include "Duck.h"

Duck::Duck(std::string name) : Animal(name)
{
}

std::string Duck::Say(void)
{
    return "Quack-quack";
}
