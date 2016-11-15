#include <iostream>

#include "Animal.h"
#include "Dog.h"
#include "Cat.h"

int main(int argc, char **argv)
{
    Animal animal;

    animal.Say();
    std::cout << "animal.GetName() = \"" << animal.GetName() << "\"" << std::endl;
    animal.SetName("dick");
    std::cout << "animal.GetName() = \"" << animal.GetName() << "\"" << std::endl;
    animal.SetName("Mickey");
    std::cout << "animal.GetName() = \"" << animal.GetName() << "\"" << std::endl;
    std::cout << std::endl;

    Dog
        dog("dog"),
        dogDog(dog);

    dog.Say();
    dogDog.Say();
    std::cout << std::endl;

    Cat cat("cat");
    cat.Say();
    std::cout << std::endl;

    Animal *smthAnimal;
    
    smthAnimal = new Animal();
    smthAnimal->Say();
    smthAnimal->SaySay();
    delete smthAnimal;
    std::cout << std::endl;

    smthAnimal = new Dog();
    smthAnimal->Say();
    smthAnimal->SaySay();
    delete smthAnimal;
    std::cout << std::endl;

    smthAnimal = new Cat();
    smthAnimal->Say();
    smthAnimal->SaySay();
    delete smthAnimal;
    std::cout << std::endl;

    return 0;
}