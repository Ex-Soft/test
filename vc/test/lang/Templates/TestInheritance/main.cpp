#include <iostream>

#include "a.h"
#include "base.h"
#include "derived.h"

using namespace std;

int main(int argc, char **argv)
{
    BaseClass<int>
        bInt1 = BaseClass<int>(),
        bInt2(bInt1),
        bInt3=bInt2,
        bInt4;

    bInt1.ToString();
    cout<<bInt1<<endl;

    bInt3.x=bInt3.y=3;
    bInt4=bInt3;

    if(bInt1==bInt4)
        cout<<"bInt1==bInt4"<<endl;

    if(bInt1!=bInt4)
        cout<<"bInt1!=bInt4"<<endl;

    BaseClass<A>
        bA1 = BaseClass<A>(),
        bA2(bA1),
        bA3=bA2,
        bA4,
        *bAPtr;

    bA1.ToString();
    cout<<bA1<<endl;

    bA3.x=bA3.y=A(3,3);

    if(bA1==bA4)
        cout<<"bA1==bA4"<<endl;

    if(bA1!=bA4)
        cout<<"bA1!=bA4"<<endl;

    DerivedClass<int>
        dInt1 = DerivedClass<int>(1, 20, 300),
        dInt2(dInt1),
        dInt3=dInt2,
        dInt4(300, 20, 1);

    dInt1.ToString();
    cout<<dInt1<<endl;

    dInt3.x=dInt3.y=dInt3.z=3;
    dInt4=dInt3;

    if(dInt1==dInt4)
        cout<<"dInt1==dInt4"<<endl;

    if(dInt1!=dInt4)
        cout<<"bInt1!=bInt4"<<endl;

    DerivedClass<A>
        dA1 = DerivedClass<A>(A(1, 1), A(20, 20), A(300, 300)),
        dA2(dA1),
        dA3=dA2,
        dA4(A(300, 300), A(20, 20), A(1, 1)),
        *dAPtr;

    dA1.ToString();
    cout<<dA1<<endl;

    dA3.x=dA3.y=dA3.z=A(3,3);
	dA4 = dA3;

    if(dA1==dA4)
        cout<<"dA1==dA4"<<endl;

    if(dA1!=dA4)
        cout<<"dA1!=dA4"<<endl;

    cout<<endl;
    bAPtr=&bA1;
    bA1.ShowTypeId();
    bAPtr->ShowTypeId();
    bA1.ToString();
    bAPtr->ToString();

    cout<<endl;
    bAPtr=&dA1;
    dA1.ShowTypeId();
    bAPtr->ShowTypeId();
    dA1.ToString();
    bAPtr->ToString();

    cout<<endl;
    if(dAPtr=dynamic_cast<DerivedClass<A> *>(bAPtr))
        cout<<"dAPtr=dynamic_cast<DerivedClass<A> *>(bAPtr)"<<endl;

    cout<<endl;
    dInt4.x=dInt4.y=dInt4.z=4;
    bInt4.ToString();
    bInt4=dInt4;
    bInt4.ToString();

    cout<<endl;
    dA4.x=dA4.y=dA4.z=A(4,4);
    bA4.ToString();
    bA4=dA4;
    bA4.ToString();

    cout<<endl;
    bAPtr = new DerivedClass<A>();
    cout<<endl;
    delete bAPtr;

	return 0;
}
