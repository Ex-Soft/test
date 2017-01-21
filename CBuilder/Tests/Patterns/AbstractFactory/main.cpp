//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#pragma hdrstop
//---------------------------------------------------------------------------

// AbstractProductA
class ICar
{
public:
   virtual void info() = 0;
};

// ConcreteProductA1
class Ford:public ICar
{
public:
   virtual void info()
   {
      std::cout<<"Ford"<<std::endl;
   }
};

//ConcreteProductA2
class Toyota:public ICar
{
public:
   virtual void info()
   {
      std::cout<<"Toyota"<<std::endl;
   }
};

// AbstractProductB
class IEngine
{
public:
   virtual void getPower() = 0;
};

// ConcreteProductB1
class FordEngine:public IEngine
{
public:
   virtual void getPower()
   {
      std::cout<<"Ford Engine 4.4"<<std::endl;
   }
};

//ConcreteProductB2
class ToyotaEngine : public IEngine
{
public:
   virtual void getPower()
   {
      std::cout<<"Toyota Engine 3.2"<<std::endl;
   }
};

// AbstractFactory
class CarFactory
{
public:
   ICar* getNewCar()
   {
      return createCar();
   }

   IEngine* getNewEngine()
   {
      return createEngine();
   }

protected:
   virtual ICar* createCar() = 0;
   virtual IEngine* createEngine() = 0;
};

// ConcreteFactory1
class FordFactory:public CarFactory
{
protected:
   // from CarFactory
   virtual ICar* createCar()
   {
      return new Ford();
   }

   virtual IEngine* createEngine()
   {
      return new FordEngine();
   }
};

// ConcreteFactory2
class ToyotaFactory:public CarFactory
{
protected:
   // from CarFactory
   virtual ICar* createCar()
   {
      return new Toyota();
   }

   virtual IEngine* createEngine()
   {
      return new ToyotaEngine();
   }
};

#pragma argsused
int main(int argc, char* argv[])
{
   CarFactory
     *curFactory=0;

   ICar
     *myCar=0;

   IEngine
     *myEngine=0;

   ToyotaFactory
     toyotaFactory;

   FordFactory
     fordFactory;

   curFactory=&toyotaFactory;
   myCar=curFactory->getNewCar();
   myCar->info();
   myEngine=curFactory->getNewEngine();
   myEngine->getPower();
   delete myCar;
   delete myEngine;

   curFactory=&fordFactory;
   myCar=curFactory->getNewCar();
   myCar->info();
   myEngine=curFactory->getNewEngine();
   myEngine->getPower();
   delete myCar;
   delete myEngine;

   return(0);
}
//---------------------------------------------------------------------------
 