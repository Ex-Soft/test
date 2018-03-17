#include <iostream>
#include <string>
#include <list>

#include "BaseObject.h"
#include "ClassWithConstructors.h"
#include "ClassWithoutInit.h"

#include "Animal.h"
#include "Fish.h"
#include "Cat.h"
#include "Dog.h"
#include "Duck.h"

#include "TypeOfCat.h"
#include "ClassOfCat.h"

void SetName(TypeOfCat &, std::string);
std::string GetName(TypeOfCat &);

int main(int argc, char **argv, char **envp)
{
	ClassWithoutInit
		classWithoutInit1 = ClassWithoutInit(),
		classWithoutInit2 = ClassWithoutInit(1),
		classWithoutInit3 = ClassWithoutInit(1, 2),
		classWithoutInit4 = ClassWithoutInit(1, 2, 3),
		classWithoutInit5 = ClassWithoutInit(classWithoutInit4);

	ClassWithConstructors
		classWithConstructors1 = 1,
		classWithConstructors2 = 1L,
		classWithConstructors3 = 1.1;

	BaseObject
		baseObject1 = BaseObject(10, 20),
		baseObject2 = BaseObject(baseObject1),
		baseObject3,
		baseObject4;

	baseObject3 = baseObject4 = baseObject1;

	int
		tmpInt = baseObject1;

	std::cout << baseObject1 << std::endl;

	std::list<BaseObject>
		listOfBaseObjects;

	listOfBaseObjects.push_back(baseObject1);
	listOfBaseObjects.push_back(baseObject2);

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
