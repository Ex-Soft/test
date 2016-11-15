// ABC.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

void SetName(TypeOfCat &, std::string);
std::string GetName(TypeOfCat &);

int _tmain(int argc, _TCHAR* argv[])
{
	auto baseObject = new BaseObject();
	std::cout << baseObject->height() << " " << baseObject->width() << std::endl;
	baseObject->ping();
	std::cout << baseObject->pong() << std::endl;
	delete baseObject;

    std::string name;

    TypeOfCat smthTypeOfCat;

    smthTypeOfCat.Name = "XYZ";
    name = smthTypeOfCat.Name;

    SetName(smthTypeOfCat, "blah-blah-blah");
    name = GetName(smthTypeOfCat);
    std::cout << "The cat\'s name is \"" << name << "\"" << std::endl;

    ClassOfCat
        smthClassOfCat,
        smthClassOfCatII("smthClassOfCatII");

    smthClassOfCat.SetName("blah-blah-blah");
    name = smthClassOfCat.GetName();
    std::cout << "The cat\'s name is \"" << name << "\"" << std::endl;

    Animal animal("Animal");
    std::cout << "\"" << animal.Say() << "\"" << std::endl;

    Cat cat("Boniface", "BonifaceBoniface");
    std::cout << "\"" << cat.GetName() << "\"" << std::endl;
    std::cout << "\"" << cat.Say() << "\"" << std::endl;

    Dog dog("Rex");
    std::cout << "\"" << dog.GetName() << "\"" << std::endl;
    std::cout << "\"" << dog.Say() << "\"" << std::endl;

    Animal *animalPtr;

    animalPtr = new Animal("AnotherAnimal");
    std::cout << "\"" << animalPtr->GetName() << "\"" << std::endl;
    std::cout << "\"" << animalPtr->Say() << "\"" << std::endl;
    delete animalPtr;

    animalPtr = new Fish("AnotherFish");
    std::cout << "\"" << animalPtr->GetName() << "\"" << std::endl;
    std::cout << "\"" << animalPtr->Say() << "\"" << std::endl;
    delete animalPtr;

    animalPtr = new Cat("AnotherCat");
    std::cout << "\"" << animalPtr->GetName() << "\"" << std::endl;
    std::cout << "\"" << animalPtr->Say() << "\"" << std::endl;
    delete animalPtr;

    animalPtr = new Dog("AnotherDog");
    std::cout << "\"" << animalPtr->GetName() << "\"" << std::endl;
    std::cout << "\"" << animalPtr->Say() << "\"" << std::endl;
    delete animalPtr;

    animalPtr = new Duck("AnotherDuck");
    std::cout << "\"" << animalPtr->GetName() << "\"" << std::endl;
    std::cout << "\"" << animalPtr->Say() << "\"" << std::endl;
    delete animalPtr;

	return 0;
}

void SetName(TypeOfCat &cat, std::string name)
{
    cat.Name = name;
}

std::string GetName(TypeOfCat &cat)
{
    return cat.Name;
}
