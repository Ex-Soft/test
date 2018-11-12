#include <iostream>

#include "Student.h"

Student::Student(std::string _name) : name(_name)
{}

Student::Student(const char* _name) : Student(std::string(_name))
{}

void Student::display(void)
{
    std::cout << "{name:\"" << name << "\"}" << std::endl;
}
