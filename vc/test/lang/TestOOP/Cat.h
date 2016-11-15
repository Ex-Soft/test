#ifndef CAT_H
#define CAT_H

#include "Animal.h"

class Cat : public Animal
{
public:
    Cat(std::string="");
    Cat(const Cat&);
    virtual ~Cat(void);

    void Say(void);
    void SaySay(void);
};

#endif