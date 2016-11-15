#ifndef ANIMAL_H
#define ANIMAL_H

#include <string>

class Animal
{
    std::string
        Name;

public:
    Animal(std::string="");
    Animal(const Animal&);
    virtual ~Animal(void);

    virtual void SetName(std::string="");
    virtual std::string GetName(void) const;
    virtual void Say(void);
    virtual void SaySay(void);
};

#endif