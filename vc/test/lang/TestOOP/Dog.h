#ifndef DOG_H
#define DOG_H

#include "Animal.h"

class Dog : public Animal
{
public:
    Dog(std::string="");
    Dog(const Dog&);
    virtual ~Dog(void);

    void Say(void);
};

#endif