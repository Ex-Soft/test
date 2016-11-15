#include "stdafx.h"

ClassOfCat::ClassOfCat(std::string name)
{
    Name = name;
}

void ClassOfCat::SetName(std::string name)
{
    Name = name;
}

std::string ClassOfCat::GetName(void)
{
    return Name;
}