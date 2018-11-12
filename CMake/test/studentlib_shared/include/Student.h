#ifndef STUDENT_H
#define STUDENT_H

#include <string>

class Student
{
    std::string name;

public:

    Student(const char* = nullptr);
    Student(std::string);

    void display(void);
};

#endif
