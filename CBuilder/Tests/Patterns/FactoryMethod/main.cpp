//---------------------------------------------------------------------------

#include <vcl.h>
#include<iostream>
#include<string>
#pragma hdrstop
//---------------------------------------------------------------------------

using namespace std;

// "Product"
class Product
{
public:
   virtual string getName() = 0;
};

// "ConcreteProductA"
class ConcreteProductA:public Product
{
public:
   string getName()
   {
      return "ConcreteProductA";
   }
};

// "ConcreteProductB"
class ConcreteProductB:public Product
{
public:
   string getName()
   {
      return "ConcreteProductB";
   }
};

// "Creator"
class Creator
{
public:
   virtual Product* FactoryMethod() = 0;
};

// "ConcreteCreatorA"
class ConcreteCreatorA:public Creator
{
public:
   Product* FactoryMethod()
   {
      return new ConcreteProductA();
   }
};

// "ConcreteCreatorB"
class ConcreteCreatorB:public Creator
{
public:
   Product* FactoryMethod()
   {
      return new ConcreteProductB();
   }
};

#pragma argsused
int main(int argc, char* argv[])
{
   const int
     size=2;

   // An array of creators
   Creator
     *creators[size];

   creators[0]=new ConcreteCreatorA();
   creators[1]=new ConcreteCreatorB();

   // Iterate over creators and create products
   for(int i=0; i<size; i++)
   {
      Product
        *product=creators[i]->FactoryMethod();

      cout<<product->getName()<<endl;
      delete product;
   }

   for(int i=0; i<size; i++)
   {
      delete creators[i];
   }

   return(0);
}
//---------------------------------------------------------------------------
