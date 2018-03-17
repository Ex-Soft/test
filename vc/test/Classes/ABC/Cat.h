#ifndef CAT_H
#define CAT_H

#include <string>
#include "Animal.h"

class Cat : public Animal
{
    std::string SmthCatProperty;

public:
    Cat(std::string name = "WithoutName", std::string smthCatProperty = "WithoutSmthCatProperty");
    std::string Say(void);
};

#endif
