#ifndef CLASS_OF_CAT_H
#define CLASS_OF_CAT_H

#include <string>

class ClassOfCat
{
    std::string Name;

public:
    ClassOfCat(std::string name = "WithoutName");

    void SetName(std::string name);
    std::string GetName(void);
};

#endif
