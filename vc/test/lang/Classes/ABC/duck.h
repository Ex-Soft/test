#ifndef DUCK_H
#define DUCK_H

#include <string>
#include "Animal.h"

class Duck : public Animal
{
public:
    Duck(std::string name = "WithoutName");
    std::string Say(void);
};

#endif
