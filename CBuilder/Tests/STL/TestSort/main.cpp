//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#include <algorithm>
#include <vector>
#pragma hdrstop
//---------------------------------------------------------------------------

using namespace std;

bool myfunction(int i,int j)
{
   cout<<"bool myfunction(int i,int j)"<<endl;
   return(i>j);
}

template <class T> bool myfunction(T i,T j)
{
   cout<<"template <class T> bool myfunction(T i,T j)"<<endl;
   return(i>j);
}

#pragma argsused
int main(int argc, char* argv[])
{
   int
     myints[]={32,71,12,45,26,80,53,33};

   vector<int>
     myvector(myints,myints+sizeof(myints)/sizeof(myints[0]));

   sort(myvector.begin(),myvector.end(),myfunction<int>);

   cout<<"myvector contains:";
   for(vector<int>::iterator it=myvector.begin(); it!=myvector.end(); ++it)
      cout<<" "<<*it;

   cout<<endl;

   return 0;
}
//---------------------------------------------------------------------------
/*

struct myclass {
  bool operator() (int i,int j) { return (i<j);}
} myobject;


int main () {

                 // 32 71 12 45 26 80 53 33
   it;

  // using default comparison (operator <):
//  sort (myvector.begin(), myvector.begin()+4);           //(12 32 45 71)26 80 53 33

  // using function as comp
   // 12 32 45 71(26 33 53 80)

  // using object as comp
//  sort (myvector.begin(), myvector.end(), myobject);     //(12 26 32 33 45 53 71 80)

  // print out content:

  return 0;
}
*/