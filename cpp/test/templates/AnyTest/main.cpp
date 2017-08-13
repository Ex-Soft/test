#include <iostream>

#include "TemplateClass.h"

using namespace std;

int main(void)
{
	TemplateClass<int>
		tcInt1 = TemplateClass<int>(),
		tcInt2(tcInt1),
		tcInt3=tcInt2,
		tcInt4;

	tcInt1.ToString();

	tcInt3.x=tcInt3.y=3;
	tcInt4=tcInt3;

	if(tcInt1==tcInt4)
		cout<<"tcInt1==tcInt4"<<endl;

	if(tcInt1!=tcInt4)
		cout<<"tcInt1!=tcInt4"<<endl;

	return 0;
}
