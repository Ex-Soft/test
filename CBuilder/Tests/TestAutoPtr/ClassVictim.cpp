#include <iostream>
#include "ClassVictim.h"

ClassVictim::ClassVictim()
{
        std::cout<<"ClassVictim::ClassVictim()"<<std::endl;
}

ClassVictim::~ClassVictim()
{
        std::cout<<"ClassVictim::~ClassVictim()"<<std::endl;
}

void ClassVictim::Test()
{
        std::cout<<"ClassVictim::Test()"<<std::endl;
}
