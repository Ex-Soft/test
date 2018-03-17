#include <iostream>

#include "a.h"
#include "TemplateCreate.h"

using namespace std;

int main(int argc, char **argv)
{
    A
        a=TemplateCreate<A>();

    a.ToString();
    a.x=10;
    a.y=20;
    a.ToString();

    int
        tmpInt=TemplateCreate<int>();

    cout<<tmpInt<<endl;

    a.x=100;
    a.y=200;
    a.ToString();
    
    tmpInt=100;

    cout<<tmpInt<<endl;

	return 0;
}
