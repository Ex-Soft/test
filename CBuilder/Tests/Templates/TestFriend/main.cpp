#include <iostream>

#include "TemplateClass1.h"
#include "TemplateClass2.h"
#include "TemplateClass3.h"

using namespace std;

int main(int argc, char* argv[])
{
    TemplateClass1<int> tc1Int = TemplateClass1<int>(1,1);
    TemplateClass2<int> tc2Int = TemplateClass2<int>(2,2);
    TemplateClass3<int> tc3Int = TemplateClass3<int>(3,3);

    cout<<tc1Int<<endl;
    //cout<<tc2Int<<endl; // E2335 Overloaded 'operator ostream & << <int>(ostream &,const TemplateClass2<int> &)' ambiguous in this context
    //cout<<tc3Int<<endl; // E2335 Overloaded 'operator ostream & << <int>(ostream &,const TemplateClass3<int> &)' ambiguous in this context

    return 0;
}
//---------------------------------------------------------------------------
