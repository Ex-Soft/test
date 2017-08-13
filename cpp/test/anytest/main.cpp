#define TEST_STRLEN
#define TEST_INITIALIZATION

#include <iostream>

#ifdef TEST_STRLEN
	#include <string.h>
#endif

#ifdef TEST_INITIALIZATION
	#include "a.h"
	#include "container.h"
#endif

using namespace std;

#ifdef TEST_INITIALIZATION
int foo(int param)
{
	cout<<"foo("<<param<<")"<<endl;

	return param;
}

int fooL(int param)
{
	cout<<"fooL("<<param<<")"<<endl;

	return param;
}

int fooR(int param)
{
	cout<<"fooR("<<param<<")"<<endl;

	return param;
}
#endif
 
int main(void)
{
	const int
		max = 10;

	int
		i;

#ifdef TEST_STRLEN
	char
		*buff;

	if(buff=new char[max])
	{
		cout<<"strlen(buff)="<<strlen(buff)<<endl;

		for(i=0; i<max; ++i)
			cout<<"*(buff+"<<i<<")="<<(int)*(buff+i)<<endl;

		delete []buff;
	}
#endif

#ifdef TEST_INITIALIZATION
	int
		arr[max],
		idx;

	//arr[idx=3] = foo(idx); // for(3) [3]=3
	//arr[fooL(idx=3)] = fooR(idx); // fooL(3) fooR(3) [3]=3
	//arr[idx] = foo(idx=3); // for(3) [3]=3
	//arr[fooL(idx)] = fooR(idx=3); // fooL(1197809604) fooR(3) Segmentation fault

	for(i=0; i<max; ++i)
		cout<<"["<<i<<"]="<<arr[i]<<endl;

	Container
		c(max);

	//c[idx=3] = foo(idx); // foo(1074153692) [3] = { 1074153692, 0}
	//c[fooL(idx=3)] = fooR(idx); // fooR(1074153692) fooL(3) [3] = { 1074153692, 0}
	//c[idx] = foo(idx=3); // foo(3) [3] = { 3, 0}
	c[fooL(idx)] = fooR(idx=3); // fooR(3) fooL(3) [3] = { 3, 0}
	cout<<c[3]<<endl;
#endif

	return 0;
}
