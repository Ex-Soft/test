#include "Algorithm1.h"
#include "Algorithm2.h"
#include "TemplateClass.h"

int main(int argc, char* argv[])
{
   TemplateClass<int, Algorithm1> tc1 = TemplateClass<int, Algorithm1>();
   TemplateClass<int, Algorithm2> tc2 = TemplateClass<int, Algorithm2>();

   tc1.DoSmth();
   tc2.DoSmth();

   return 0;
}

 