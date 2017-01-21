//---------------------------------------------------------------------------

#include <vcl.h>
#include <map>
#include <vector>
#include <fstream>
#include <set>
#include <list>
#include <algorithm>
#include <iterator>
#include <iostream>
#include <functional>
#pragma hdrstop

#include "main.h"
#include "TestClass.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

//#define TEST_STD_STRING
#define TEST_VECTOR
//#define TEST_LIST
//#define TEST_MAP
//#define CLASS_IN_VECTOR
//#define STRUCT_PTR_IN_MAP
//#define MAP_IN_VECTOR
//#define TEST_SET
//#define TEST_MULTISET
//#define STRUCT_IN_MULTIMAP
//#define STRUCT_IN_VECTOR
//#define STRUCT_IN_MAP
//#define MAP_IN_MAP
//#define MULTIMAP_IN_MAP
//#define MULTIMAP_IN_MULTIMAP
//#define READ_FROM_FILE
//#define WITH_FULL_FUNC

#pragma pack(push,1)
struct sTestStruct
{
   unsigned int
     uintValue;

   AnsiString
     AnsiStringValue;

   sTestStruct(unsigned int auintValue=0, AnsiString aAnsiStringValue=""):
   uintValue(auintValue),
   AnsiStringValue(aAnsiStringValue)
   {};

   sTestStruct(const sTestStruct &obj):
   uintValue(obj.uintValue),
   AnsiStringValue(obj.AnsiStringValue)
   {};

   sTestStruct & operator= (const sTestStruct &aObj);

   friend bool operator == (const sTestStruct &aTestStructLeft, const sTestStruct &aTestStructRight);
   friend bool operator != (const sTestStruct &aTestStructLeft, const sTestStruct &aTestStructRight);
   friend bool operator < (const sTestStruct &aLeft, const sTestStruct &aRight);
   friend bool operator > (const sTestStruct &aLeft, const sTestStruct &aRight);
};
//---------------------------------------------------------------------------

sTestStruct & sTestStruct::operator= (const sTestStruct &aObj)
{
   uintValue=aObj.uintValue;
   AnsiStringValue=aObj.AnsiStringValue;
}
//---------------------------------------------------------------------------

bool operator == (const sTestStruct &aTestStructLeft, const sTestStruct &aTestStructRight)
{
   return(aTestStructLeft.uintValue==aTestStructRight.uintValue && aTestStructLeft.AnsiStringValue==aTestStructRight.AnsiStringValue);
}
//---------------------------------------------------------------------------

bool operator != (const sTestStruct &aTestStructLeft, const sTestStruct &aTestStructRight)
{
   return(aTestStructLeft.uintValue!=aTestStructRight.uintValue || aTestStructLeft.AnsiStringValue!=aTestStructRight.AnsiStringValue);
}
//---------------------------------------------------------------------------

bool operator < (const sTestStruct &aLeft, const sTestStruct &aRight)
{
   return(aLeft.uintValue<aRight.uintValue && aLeft.AnsiStringValue<aRight.AnsiStringValue);
}
//---------------------------------------------------------------------------

bool operator > (const sTestStruct &aLeft, const sTestStruct &aRight)
{
   return(aLeft.uintValue>aRight.uintValue && aLeft.AnsiStringValue>aRight.AnsiStringValue);
}
//---------------------------------------------------------------------------

class TTestClass
{
public:

   unsigned int
     uintValue;

   AnsiString
     AnsiStringValue;

   TTestClass(unsigned int auintValue=0, AnsiString aAnsiStringValue=""):
   uintValue(auintValue),
   AnsiStringValue(aAnsiStringValue)
   {};

   TTestClass(const TTestClass &aTestClass) {uintValue=aTestClass.uintValue; AnsiStringValue=aTestClass.AnsiStringValue; };
};

class TClassWithAllocMem
{
   #if defined(WITH_FULL_FUNC)
     void CopyData(const TClassWithAllocMem &aObj);
   #endif

public:

   unsigned int
     size;

   char
     *buff;

   TClassWithAllocMem(unsigned int asize=0);
   #if defined(WITH_FULL_FUNC)
     TClassWithAllocMem(const TClassWithAllocMem &aObj);
   #endif
   virtual ~TClassWithAllocMem(void);

   #if defined(WITH_FULL_FUNC)
     TClassWithAllocMem & operator= (const TClassWithAllocMem &aObj);
   #endif
};

TClassWithAllocMem::TClassWithAllocMem(unsigned int asize)
{
   try
   {
      buff = (size=asize) ? new char [asize] : 0;
   }
   catch(std::bad_alloc)
   {
      throw Exception("Insufficient memory");
   }
}

#if defined(WITH_FULL_FUNC)
TClassWithAllocMem::TClassWithAllocMem(const TClassWithAllocMem &aObj)
{
   try
   {
      buff=0;
      if(size=aObj.size)
        CopyData(aObj);
   }
   catch(Exception &e)
   {
      throw Exception(e.Message);
   }
}
#endif

TClassWithAllocMem::~TClassWithAllocMem(void)
{
   if(buff)
   {
      delete []buff;
      buff=0;
   }
}

#if defined(WITH_FULL_FUNC)
void TClassWithAllocMem::CopyData(const TClassWithAllocMem &aObj)
{
   try
   {
      if(buff)
      {
         delete []buff;
         buff=0;
      }
      if(size=aObj.size)
      {
         buff=new char [size];
         memcpy(buff,aObj.buff,size);
      }
   }
   catch(std::bad_alloc)
   {
      throw Exception("Insufficient memory");
   }
}

TClassWithAllocMem & TClassWithAllocMem::operator= (const TClassWithAllocMem &aObj)
{
   try
   {
      if(this!=&aObj)
        CopyData(aObj);
   }
   catch(Exception &e)
   {
      throw Exception(e.Message);
   }

   return(*this);
}
#endif

#pragma pack(pop)

#if defined(TEST_VECTOR)
  using namespace std;
#endif

#if defined(TEST_VECTOR)
template<class Arg>
struct all_true : public unary_function<Arg, bool>
{
   bool operator()(const Arg& x){ return 1; }
};
#endif

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   std::fstream
     File;

   AnsiString
     FileName=ExtractFilePath(Application->ExeName)+"Log.log";

   File.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
   if(!File.good())
     {
        FileName="Can't create file: \""+FileName+"\"";
        Application->MessageBox(FileName.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

#if defined(TEST_STD_STRING)
   std::string
     str,
     s1="abc",
     s2="def";

   str.append(s1);
   str.append(s2);
   s1=str;

   s1="abcd\\r\\nqwer";

   int
     __idx__=s1.find("\\");

   __idx__=s1.find("\\",__idx__+1);
   __idx__=s1.find("\\",__idx__+1);
   if(__idx__==std::string::npos)
     __idx__=0;

   char
       *___idx___=std::find(s1.begin(),s1.end(),'\\');

   s1="aabbcc";
   s2="a";
   s1.replace(s1.begin(),s1.end(),s2);
   s1.replace(s1.begin(),s1.end(),3,'z');
   s1="aabbcc";
   s1.replace(s1.begin(),s1.end(),'a','z');
   s1.replace(s1.begin(),s1.end(),"b","y");
   str=s1;
   s1="aabbcc";
   std::replace(s1.begin(),s1.end(),'a','z');
#endif

#if defined(TEST_VECTOR)
   int
     arr[10]={1,2,3,4,5,6,7,8,9,10};

   std::vector<int>
     v(arr, arr+10);

   copy(v.begin(),v.end(),std::ostream_iterator<int,char>(File," "));
   File<<std::endl<<std::endl;

   // remove the 7
   std::vector<int>::iterator
     result=remove(v.begin(),v.end(),7);

   // delete dangling elements from the vector
   v.erase(result, v.end());
   copy(v.begin(),v.end(),std::ostream_iterator<int,char>(File," "));
   File<<std::endl<<std::endl;

   // remove everything beyond the fourth element
   result=remove_if(v.begin()+4,v.begin()+8,all_true<int>());

   // delete dangling elements
   v.erase(result, v.end());

   copy(v.begin(),v.end(),std::ostream_iterator<int,char>(File," "));
   File<<std::endl<<std::endl;

   std::vector<int>
     src,
     dest;

   src.push_back(1);
   src.push_back(2);
   src.push_back(3);
   src.push_back(4);
   src.push_back(5);

   dest.push_back(10);
   dest.push_back(20);
   dest.push_back(30);
   dest.push_back(40);
   dest.push_back(50);
   dest.push_back(60);
   dest.push_back(70);

   for(unsigned int i=0; i<src.size(); ++i)
      File<<src[i]<<std::endl;
   for(unsigned int i=0; i<dest.size(); ++i)
      File<<dest[i]<<std::endl;

   dest=src;
   for(unsigned int i=0; i<dest.size(); ++i)
      File<<dest[i]<<std::endl;
#endif

#if defined(TEST_LIST)
   typedef std::list<std::string> list_string;

   list_string
     TestListString;

   list_string::iterator
     result;

   std::string
     victim("str_1");

   TestListString.push_back("str_1");
   TestListString.push_back("str_2");
   TestListString.push_back("str_3");
   TestListString.push_back("str_1");
   TestListString.push_back("str_4");
   TestListString.push_back("str_1");
   TestListString.push_back("str_5");
   File<<"TestListString.size()="<<TestListString.size()<<std::endl;
   result=remove(TestListString.begin(),TestListString.end(),victim);
   File<<"result->begin()="<<result->begin()<<std::endl;
   File<<"result->end()-1="<<result->end()-1<<std::endl;
   File<<"result->end()="<<result->end()<<std::endl;
   File<<"*result="<<*result<<std::endl;
   ++result;
   File<<"result->begin()="<<result->begin()<<std::endl;
   File<<"result->end()-1="<<result->end()-1<<std::endl;
   File<<"result->end()="<<result->end()<<std::endl;
   File<<"*result="<<*result<<std::endl;
   File<<"TestListString.size()="<<TestListString.size()<<std::endl;
   TestListString.remove(victim);
   File<<"TestListString.size()="<<TestListString.size()<<std::endl;
   File<<std::endl;
#endif

#if defined(TEST_MAP)
   typedef std::map<AnsiString, AnsiString> mAnsiString;

   mAnsiString
     TestMap,
     CopyMap;

   TestMap.insert(mAnsiString::value_type("First","First"));
   TestMap.insert(mAnsiString::value_type("Second","Second"));
   TestMap.insert(mAnsiString::value_type("Third","Third"));
   TestMap.insert(mAnsiString::value_type("Fourth","Fourth"));
   TestMap.insert(mAnsiString::value_type("Fifth","Fifth"));
   TestMap.insert(mAnsiString::value_type("Sixth","Sixth"));
   TestMap.insert(mAnsiString::value_type("Seventh","Seventh"));
   TestMap.insert(mAnsiString::value_type("Eighth","Eighth"));
   TestMap.insert(mAnsiString::value_type("Ninth","Ninth"));

   mAnsiString::iterator
     i,
     TestMapEnd=TestMap.end();

   for(i=TestMap.begin(); i!=TestMapEnd; ++i)
      File<<"TestMap[\""<<i->first.c_str()<<"\"]=\""<<i->second.c_str()<<"\""<<std::endl;
   File<<std::endl;

   CopyMap=TestMap;
   TestMapEnd=CopyMap.end();
   for(i=CopyMap.begin(); i!=TestMapEnd; ++i)
      File<<"CopyMap[\""<<i->first.c_str()<<"\"]=\""<<i->second.c_str()<<"\""<<std::endl;
   File<<std::endl;

   CopyMap.clear();
   CopyMap.insert(mAnsiString::value_type("1","1"));
   CopyMap.insert(mAnsiString::value_type("2","2"));
   CopyMap.insert(mAnsiString::value_type("3","3"));
   CopyMap.insert(mAnsiString::value_type("4","4"));
   CopyMap.insert(mAnsiString::value_type("5","5"));
   CopyMap.insert(mAnsiString::value_type("6","6"));
   CopyMap.insert(mAnsiString::value_type("7","7"));
   CopyMap.insert(mAnsiString::value_type("8","9"));
   CopyMap.insert(mAnsiString::value_type("9","9"));

   TestMapEnd=CopyMap.end();
   for(i=CopyMap.begin(); i!=TestMapEnd; ++i)
      File<<"CopyMap[\""<<i->first.c_str()<<"\"]=\""<<i->second.c_str()<<"\""<<std::endl;
   File<<std::endl;

   CopyMap=TestMap;
   TestMapEnd=CopyMap.end();
   for(i=CopyMap.begin(); i!=TestMapEnd; ++i)
      File<<"CopyMap[\""<<i->first.c_str()<<"\"]=\""<<i->second.c_str()<<"\""<<std::endl;
   File<<std::endl;

   typedef std::map<int, TBase> mTBase;

   mTBase
     map_TBase;

   map_TBase.insert(mTBase::value_type(1,1));
   map_TBase.insert(mTBase::value_type(2,2));
   map_TBase.insert(mTBase::value_type(3,3));
   map_TBase.insert(mTBase::value_type(4,4));
   map_TBase.insert(mTBase::value_type(5,5));

   mTBase::iterator
     map_TBaseEnd=map_TBase.end();

   for(mTBase::iterator i=map_TBase.begin(); i!=map_TBaseEnd; i++)
      File<<i->second.TBaseInt;

   for(mTBase::iterator i=map_TBase.begin(); i!=map_TBaseEnd; ++i)
      File<<i->second.TBaseInt;
#endif

#if defined(CLASS_IN_VECTOR)
   std::vector<TTestClass>
     List1,
     List2;

   std::vector<TTestClass>::iterator
     beginVector,
     endVector;

   unsigned int
     max=3,
     size;

   TTestClass
     TestClass;

   for(unsigned int i=0; i<max; i++)
      {
         TestClass.uintValue=i;
         TestClass.AnsiStringValue=IntToStr(i);
         List1.push_back(TestClass);
      }

#endif

#if defined(STRUCT_PTR_IN_MAP)

   std::map<sTestStruct *, sTestStruct>
     List;

   std::map<sTestStruct *, sTestStruct>::iterator
     p,
     end;

   sTestStruct
     *ptr1=new sTestStruct(1,IntToStr(1)),
     *ptr2=new sTestStruct(2,IntToStr(2)),
     *ptr3=new sTestStruct(3,IntToStr(3));

   List.insert(std::map<sTestStruct *, sTestStruct>::value_type(ptr1,*ptr1));
   List.insert(std::map<sTestStruct *, sTestStruct>::value_type(ptr2,*ptr2));
   List.insert(std::map<sTestStruct *, sTestStruct>::value_type(ptr3,*ptr3));
   end=List.end();

   File<<"List.size()="<<IntToStr(List.size()).c_str()<<std::endl;
   for(std::map<sTestStruct *, sTestStruct>::iterator i=List.begin(); i!=end; ++i)
      File<<"List["<<std::hex<<std::showbase<<i->first<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<List[i->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   if((p=List.find(ptr2))!=end)
     File<<"List["<<std::hex<<std::showbase<<p->first<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<List[p->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   if((p=List.find(ptr3))!=end)
     File<<"List["<<std::hex<<std::showbase<<p->first<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<List[p->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   if((p=List.find(ptr1))!=end)
     File<<"List["<<std::hex<<std::showbase<<p->first<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<List[p->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;

   delete ptr1;
   delete ptr2;
   delete ptr3;
#endif

#if defined(MAP_IN_VECTOR)

   typedef std::map<unsigned int, sTestStruct> InnerList;

   std::vector<InnerList>
     OuterList;

   unsigned int
     maxO=3,
     CmaxI=5,
     maxI;

   for(unsigned int i=0; i<maxO; i++)
      {
         OuterList.push_back(InnerList());

         for(unsigned int j=0; j<CmaxI; j++)
            if(OuterList[i].find(j)==OuterList[i].end())
              OuterList[i].insert(std::map<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
      }

   File<<"OuterList.size()="<<IntToStr(OuterList.size()).c_str()<<std::endl<<std::endl;
   for(unsigned int i=0; i<maxO; i++)
      {
         File<<"OuterList["<<IntToStr(i).c_str()<<"].size()="<<IntToStr(OuterList[i].size()).c_str()<<std::endl;

         for(std::map<unsigned int, sTestStruct>::iterator iI=OuterList[i].begin(); iI!=OuterList[i].end(); iI++)
            File<<"OuterList["<<IntToStr(i).c_str()<<"]["<<IntToStr(iI->first).c_str()<<"]={ "<<IntToStr(iI->second.uintValue).c_str()<<", \""<<OuterList[i][iI->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;

         File<<std::endl;
      }

#endif

#if defined(TEST_SET)
   typedef std::set<char/*, less<char>, allocator<char> */> set_type;
   typedef set_type::iterator MI;

   set_type TestSet1;
   set_type::iterator
     i,
     end,
     lb,
     ub;

   File<<"TestSet1.empty()="<<TestSet1.empty()<<std::endl;

   for(char i='A'; i<='Z'; i+=5)
      {
         TestSet1.insert(i);
         if(i=='A')
           {
              TestSet1.insert(i);
              TestSet1.insert(i);
           }
      }
   File<<"TestSet1.empty()="<<TestSet1.empty()<<std::endl;

   end=TestSet1.end();
   for(i=TestSet1.begin(); i!=end;)
      {
         File<<*i;
         if(++i != end)
           File<<" ";
      }
   File<<std::endl;

   TestSet1.erase('Z');
   for(i=TestSet1.begin(); i!=end;)
      {
         File<<*i;
         if(++i != end)
           File<<" ";
      }
   File<<std::endl;

   i=TestSet1.find('F');
   if(i!=end)
     File<<"TestSet1.find('"<<*i<<"')"<<std::endl;

   for(char i='A'; i<='L'; ++i)
      {
         lb=TestSet1.lower_bound(i);
         ub=TestSet1.upper_bound(i);
         File<<"TestSet1.lower_bound("<<i<<")="<<*lb<<std::endl;
         File<<"TestSet1.upper_bound("<<i<<")="<<*ub<<std::endl;
      }

   std::pair<MI, MI> g=TestSet1.equal_range('F');

   for(MI p=g.first; p!=g.second; )
      {
         File<<*i;
         if(++p != g.second)
           File<<" ";
      }
   File<<std::endl;

  File<<"TestSet1.size()="<<IntToStr(TestSet1.size()).c_str()<<std::endl;
  File<<"TestSet1.max_size()="<<IntToStr(TestSet1.max_size()).c_str()<<std::endl;
  File<<"TestSet1.count('A')="<<IntToStr(TestSet1.count('A')).c_str()<<std::endl;

  TestSet1.clear();

  File<<"TestSet1.size()="<<IntToStr(TestSet1.size()).c_str()<<std::endl;
  File<<"TestSet1.max_size()="<<IntToStr(TestSet1.max_size()).c_str()<<std::endl;
  File<<"TestSet1.count('A')="<<IntToStr(TestSet1.count('A')).c_str()<<std::endl;

#endif

#if defined(TEST_MULTISET)
   typedef std::multiset<char/*, less<char>, allocator<char> */> set_type;
   typedef set_type::iterator MI;

   set_type TestSet1;
   set_type::iterator
     i,
     end,
     lb,
     ub;

   File<<"TestSet1.empty()="<<TestSet1.empty()<<std::endl;

   for(char i='A'; i<='Z'; i+=5)
      {
         TestSet1.insert(i);
         if(i=='A')
           {
              TestSet1.insert(i);
              TestSet1.insert(i);
           }
      }
   File<<"TestSet1.empty()="<<TestSet1.empty()<<std::endl;

   end=TestSet1.end();
   for(i=TestSet1.begin(); i!=end;)
      {
         File<<*i;
         if(++i != end)
           File<<" ";
      }
   File<<std::endl;

   TestSet1.erase('Z');
   for(i=TestSet1.begin(); i!=end;)
      {
         File<<*i;
         if(++i != end)
           File<<" ";
      }
   File<<std::endl;

   i=TestSet1.find('F');
   if(i!=end)
     File<<"TestSet1.find('"<<*i<<"')"<<std::endl;

   for(char i='A'; i<='L'; ++i)
      {
         lb=TestSet1.lower_bound(i);
         ub=TestSet1.upper_bound(i);
         File<<"TestSet1.lower_bound("<<i<<")="<<*lb<<std::endl;
         File<<"TestSet1.upper_bound("<<i<<")="<<*ub<<std::endl;
      }

   lb=TestSet1.lower_bound('A');
   ub=TestSet1.upper_bound('A');
   for(i=lb; i!=ub; )
      {
         File<<*i;
         if(++i != ub)
           File<<" ";
      }
   File<<std::endl;

   std::pair<MI, MI> g=TestSet1.equal_range('F');

   for(MI p=g.first; p!=g.second; )
      {
         File<<*i;
         if(++p != g.second)
           File<<" ";
      }
   File<<std::endl;

  File<<"TestSet1.size()="<<IntToStr(TestSet1.size()).c_str()<<std::endl;
  File<<"TestSet1.max_size()="<<IntToStr(TestSet1.max_size()).c_str()<<std::endl;
  File<<"TestSet1.count('A')="<<IntToStr(TestSet1.count('A')).c_str()<<std::endl;

  TestSet1.clear();

  File<<"TestSet1.size()="<<IntToStr(TestSet1.size()).c_str()<<std::endl;
  File<<"TestSet1.max_size()="<<IntToStr(TestSet1.max_size()).c_str()<<std::endl;
  File<<"TestSet1.count('A')="<<IntToStr(TestSet1.count('A')).c_str()<<std::endl;

#endif

#if defined(STRUCT_IN_MULTIMAP)

   std::multimap<unsigned int, sTestStruct> List1;

   unsigned int max=5;

   for(unsigned int i=0; i<max; i++)
      {
         List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));
         if(i==1)
           {
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i+2,sTestStruct(i+2,IntToStr(i)+"+2")));
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i+1,sTestStruct(i+1,IntToStr(i)+"+1")));
           }
         if(i==3)
           {
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i-1,sTestStruct(i-1,IntToStr(i)+"-1")));
              List1.insert(std::map<unsigned int, sTestStruct>::value_type(i-1,sTestStruct(i-1,IntToStr(i)+"-1")));
           }
      }

   File<<"List1.size()="<<IntToStr(List1.size()).c_str()<<std::endl;
   for(std::multimap<unsigned int, sTestStruct>::iterator i=List1.begin(); i!=List1.end(); ++i)
      File<<"List1["<<IntToStr(i->first).c_str()<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<i->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   max=1;

   std::multimap<unsigned int, sTestStruct>::iterator lb=List1.lower_bound(max);
   std::multimap<unsigned int, sTestStruct>::iterator ub=List1.upper_bound(max);
   //File<<"List1.upper_bound()-List1.lower_bound()="<<ub-lb<<std::endl;
   //File<<std::endl;

   for(std::multimap<unsigned int, sTestStruct>::iterator p=lb; p!=ub; ++p)
      {
         File<<"List1["<<IntToStr(p->first).c_str()<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<p->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;
      }
   File<<std::endl;

   typedef std::multimap<unsigned int, sTestStruct>::iterator MI;

   std::pair<MI, MI> g=List1.equal_range(max);
   //File<<"List1.equal_range().second-List1.equal_range().first="<<g.second-g.first<<std::endl;
   //File<<std::endl;

   for(MI p=g.first; p!=g.second; ++p)
      {
         File<<"List1["<<IntToStr(p->first).c_str()<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<p->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;
      }
   File<<std::endl;

#endif

#if defined(STRUCT_IN_VECTOR)

   sTestStruct
     tmpTestStruct;

   std::vector<sTestStruct>
     List1,
     List2;

   std::vector<sTestStruct>::iterator
     beginVector,
     endVector,
     iFind;

   unsigned int
     max=3,
     size;

   for(unsigned int i=0; i<max; i++)
      List1.push_back(sTestStruct(i,IntToStr(i)));
   List1.insert(List1.begin()+1,sTestStruct(103,IntToStr(103)));

   List2.clear();
   beginVector=List2.begin();
   endVector=List2.end();
   if(beginVector==endVector)
     File<<"After List2.clear() List2.begin()==List2.end()"<<std::endl;
   List2=List1;
   if(List2.begin()==beginVector)
     File<<"After List2=List1 List2.begin()==beginVector"<<std::endl;
   else
     File<<"After List2=List1 List2.begin()!=beginVector"<<std::endl;
   beginVector=List2.begin();
   if(List2.end()==endVector)
     File<<"After List2=List1 List2.end()==endVector"<<std::endl;
   else
     File<<"After List2=List1 List2.end()!=endVector"<<std::endl;
   endVector=List2.end();
   List1.clear();
   List1=List2;

   if(List1[0]==List2[0])
     File<<"List1[0]==List2[0]"<<std::endl;
   if(List1[0]!=List2[0])
     File<<"List1[0]!=List2[0]"<<std::endl;
   if(List1[0]==List2[1])
     File<<"List1[0]==List2[1]"<<std::endl;
   if(List1[0]!=List2[1])
     File<<"List1[0]!=List2[1]"<<std::endl;

   beginVector=List1.begin();
   endVector=List1.end();
   tmpTestStruct.uintValue=1;
   tmpTestStruct.AnsiStringValue="1";
   iFind=std::find(beginVector,endVector,tmpTestStruct);
   if(iFind!=endVector)
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } found in List1 @ "<<IntToStr(iFind-beginVector).c_str()<<" (List1["<<IntToStr(iFind-beginVector).c_str()<<"]={ "<<IntToStr(List1[iFind-beginVector].uintValue).c_str()<<", \""<<List1[iFind-beginVector].AnsiStringValue.c_str()<<"\" })"<<std::endl;
   else
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } was not found in List1"<<std::endl;

   tmpTestStruct.uintValue=2;
   tmpTestStruct.AnsiStringValue="2";
   iFind=std::find(beginVector,endVector,tmpTestStruct);
   if(iFind!=endVector)
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } found in List1 @ "<<IntToStr(iFind-beginVector).c_str()<<" (List1["<<IntToStr(iFind-beginVector).c_str()<<"]={ "<<IntToStr(List1[iFind-beginVector].uintValue).c_str()<<", \""<<List1[iFind-beginVector].AnsiStringValue.c_str()<<"\" })"<<std::endl;
   else
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } was not found in List1"<<std::endl;

   tmpTestStruct.uintValue=0;
   tmpTestStruct.AnsiStringValue="0";
   iFind=std::find(beginVector,endVector,tmpTestStruct);
   if(iFind!=endVector)
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } found in List1 @ "<<IntToStr(iFind-beginVector).c_str()<<" (List1["<<IntToStr(iFind-beginVector).c_str()<<"]={ "<<IntToStr(List1[iFind-beginVector].uintValue).c_str()<<", \""<<List1[iFind-beginVector].AnsiStringValue.c_str()<<"\" })"<<std::endl;
   else
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } was not found in List1"<<std::endl;

   tmpTestStruct.uintValue=5;
   tmpTestStruct.AnsiStringValue="5";
   iFind=std::find(beginVector,endVector,tmpTestStruct);
   if(iFind!=endVector)
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } found in List1 @ "<<IntToStr(iFind-beginVector).c_str()<<" (List1["<<IntToStr(iFind-beginVector).c_str()<<"]={ "<<IntToStr(List1[iFind-beginVector].uintValue).c_str()<<", \""<<List1[iFind-beginVector].AnsiStringValue.c_str()<<"\" })"<<std::endl;
   else
     File<<"{ "<<IntToStr(tmpTestStruct.uintValue).c_str()<<", \""<<tmpTestStruct.AnsiStringValue.c_str()<<"\" } was not found in List1"<<std::endl;

   File<<std::endl;

   size=List1.size();
   File<<"List1.size()="<<IntToStr(size).c_str()<<std::endl;
   for(unsigned int i=0; i<size; i++)
      File<<"List1["<<IntToStr(i).c_str()<<"]={ "<<IntToStr(List1[i].uintValue).c_str()<<", \""<<List1[i].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   List1.clear();
   for(unsigned int i=0; i<max; i++)
      List1.push_back(sTestStruct(i,"List1 "+IntToStr(i)));

   List2.clear();
   max=5;
   for(unsigned int i=0; i<max; i++)
      List2.push_back(sTestStruct(i,"List2 "+IntToStr(i)));

   List1=List2;
   size=List1.size();
   File<<"List1.size()="<<IntToStr(size).c_str()<<std::endl;
   for(unsigned int i=0; i<size; i++)
      File<<"List1["<<IntToStr(i).c_str()<<"]={ "<<IntToStr(List1[i].uintValue).c_str()<<", \""<<List1[i].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   List1.clear();
   for(unsigned int i=0; i<max; i++)
      List1.push_back(sTestStruct(i,"List1 "+IntToStr(i)));

   List2.clear();
   max=3;
   for(unsigned int i=0; i<max; i++)
      List2.push_back(sTestStruct(i,"List2 "+IntToStr(i)));

   List1=List2;
   size=List1.size();
   File<<"List1.size()="<<IntToStr(size).c_str()<<std::endl;
   for(unsigned int i=0; i<size; i++)
      File<<"List1["<<IntToStr(i).c_str()<<"]={ "<<IntToStr(List1[i].uintValue).c_str()<<", \""<<List1[i].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   List1.clear();
   List1.push_back(sTestStruct(0,"List1 "+IntToStr(0)));
   List1.push_back(sTestStruct(1,"List1 "+IntToStr(1)));
   List1.push_back(sTestStruct(3,"List1 "+IntToStr(3)));
   List1.push_back(sTestStruct(4,"List1 "+IntToStr(4)));
   List1.insert(List1.begin()+2,sTestStruct(2,"List1 "+IntToStr(2)));

   size=List1.size();
   File<<"List1.size()="<<IntToStr(size).c_str()<<std::endl;
   for(unsigned int i=0; i<size; i++)
      File<<"List1["<<IntToStr(i).c_str()<<"]={ "<<IntToStr(List1[i].uintValue).c_str()<<", \""<<List1[i].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   int offset;

   for(std::vector<sTestStruct>::iterator i=List1.begin(); i<List1.end(); i++)
      {
         offset=i-List1.begin();

         File<<"List1["<<IntToStr(offset).c_str()<<"]={ "<<IntToStr(i->uintValue).c_str()<<", \""<<i->AnsiStringValue.c_str()<<"\" }"<<std::endl;

         if(i==List1.end())
           File<<"The End of List1"<<std::endl;
      }
   File<<std::endl;
                                            //List1.rbegin()  //!=List1.rend()
   for(std::vector<sTestStruct>::iterator i=List1.end()-1; i>=List1.begin(); i--)
      {
         offset=i-List1.begin();

         File<<"List1["<<IntToStr(offset).c_str()<<"]={ "<<IntToStr(i->uintValue).c_str()<<", \""<<i->AnsiStringValue.c_str()<<"\" }"<<std::endl;

         if(i==List1.begin())
           File<<"The Begin of List1"<<std::endl;
      }
   File<<std::endl;

   for(std::vector<sTestStruct>::reverse_iterator i=List1.rbegin(); i!=List1.rend(); ++i)
      {
         offset=List1.rend()-i-1;

         File<<"List1["<<IntToStr(offset).c_str()<<"]={ "<<IntToStr(i->uintValue).c_str()<<", \""<<i->AnsiStringValue.c_str()<<"\" }"<<std::endl;

         if(i==List1.rend()-1)
           File<<"The Begin of List1"<<std::endl;
      }
   File<<std::endl;


   std::vector<sTestStruct>::iterator List1End=List1.end()-1;
   File<<"List1["<<IntToStr(List1End-List1.begin()).c_str()<<"]={ "<<IntToStr(List1End->uintValue).c_str()<<", \""<<List1End->AnsiStringValue.c_str()<<"\" }"<<std::endl;

   std::vector<sTestStruct>::reverse_iterator List1ri=List1.rbegin()+1;
   List1End=List1ri.base();
   List1End--;
   File<<"List1["<<IntToStr(List1End-List1.begin()).c_str()<<"]={ "<<IntToStr(List1End->uintValue).c_str()<<", \""<<List1End->AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   List1.erase(std::find(List1.begin(),List1.end(),sTestStruct(1,"List1 "+IntToStr(1))));
   size=List1.size();
   File<<"List1.size()="<<IntToStr(size).c_str()<<std::endl;
   for(unsigned int i=0; i<size; i++)
      File<<"List1["<<IntToStr(i).c_str()<<"]={ "<<IntToStr(List1[i].uintValue).c_str()<<", \""<<List1[i].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;
#endif

#if defined(STRUCT_IN_MAP)

   std::map<unsigned int, sTestStruct>
     List1,List2;

   std::map<unsigned int, sTestStruct>::iterator
     p;

   unsigned int
     max=36;

   for(unsigned int i=0; i<max; i+=5)
      if(List1.find(i)==List1.end())
        List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));

   File<<"List1.size()="<<IntToStr(List1.size()).c_str()<<std::endl;
   for(std::map<unsigned int, sTestStruct>::iterator i=List1.begin(); i!=List1.end(); ++i)
      File<<"List1["<<IntToStr(i->first).c_str()<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<List1[i->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   std::pair<std::map<unsigned int, sTestStruct>::iterator, bool>
     ip;

   List1.clear();
   List1.insert(std::map<unsigned int, sTestStruct>::value_type(5,sTestStruct(5,IntToStr(5))));
   for(unsigned int i=0; i<max; i+=5)
      {
         ip=List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct()));
         if(ip.second) // insert
           {
              ip.first->second.uintValue=i;
              ip.first->second.AnsiStringValue=IntToStr(i);
           }
         else //already exists
           {
              ip.first->second.uintValue++;
              ip.first->second.AnsiStringValue+=ip.first->second.AnsiStringValue;
           }
      }
   File<<"List1.size()="<<IntToStr(List1.size()).c_str()<<std::endl;
   for(std::map<unsigned int, sTestStruct>::iterator i=List1.begin(); i!=List1.end(); ++i)
      File<<"List1["<<IntToStr(i->first).c_str()<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<List1[i->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   for(unsigned int i=0; i<=max+5; ++i)
      {
         p=List1.lower_bound(i); /* Last node which is not less than __k. */
         if(p!=List1.end())
           {
              File<<"lower_bound("<<IntToStr(i).c_str()<<") List1["<<IntToStr(p->first).c_str()<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<List1[p->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
           }

         p=List1.upper_bound(i); /* Last node which is greater than __k. */
         if(p!=List1.end())
           {
              File<<"upper_bound("<<IntToStr(i).c_str()<<") List1["<<IntToStr(p->first).c_str()<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<List1[p->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
           }
         if(!(i%5))
           File<<std::endl;
      }
   File<<std::endl;

   max=3;
   List1.clear();
   for(unsigned int i=0; i<max; i++)
      if(List1.find(i)==List1.end())
        List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,IntToStr(i))));

   List2.clear();
   List2=List1;
   List1.clear();
   List1=List2;

   File<<"List1.size()="<<IntToStr(List1.size()).c_str()<<std::endl;
   for(std::map<unsigned int, sTestStruct>::iterator i=List1.begin(); i!=List1.end(); i++)
      File<<"List1["<<IntToStr(i->first).c_str()<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<List1[i->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   List1.clear();
   for(unsigned int i=0; i<max; i++)
      if(List1.find(i)==List1.end())
        List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,"List1 "+IntToStr(i))));

   List2.clear();
   max=5;
   for(unsigned int i=0; i<max; i++)
      if(List2.find(i)==List2.end())
        List2.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,"List2 "+IntToStr(i))));

   List1=List2;
   File<<"List1.size()="<<IntToStr(List1.size()).c_str()<<std::endl;
   for(std::map<unsigned int, sTestStruct>::iterator i=List1.begin(); i!=List1.end(); i++)
      File<<"List1["<<IntToStr(i->first).c_str()<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<List1[i->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   List1.clear();
   for(unsigned int i=0; i<max; i++)
      if(List1.find(i)==List1.end())
        List1.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,"List1 "+IntToStr(i))));

   List2.clear();
   max=3;
   for(unsigned int i=0; i<max; i++)
      if(List2.find(i)==List2.end())
        List2.insert(std::map<unsigned int, sTestStruct>::value_type(i,sTestStruct(i,"List2 "+IntToStr(i))));

   List1=List2;
   File<<"List1.size()="<<IntToStr(List1.size()).c_str()<<std::endl;
   for(std::map<unsigned int, sTestStruct>::iterator i=List1.begin(); i!=List1.end(); i++)
      File<<"List1["<<IntToStr(i->first).c_str()<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<List1[i->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   if(List1.find(1)!=List1.end())
     {
        unsigned int i=List1.erase(1);

        File<<"Count deleted="<<IntToStr(i).c_str()<<std::endl;
     }
   File<<"List1.size()="<<IntToStr(List1.size()).c_str()<<std::endl;
   for(std::map<unsigned int, sTestStruct>::iterator i=List1.begin(); i!=List1.end(); i++)
      File<<"List1["<<IntToStr(i->first).c_str()<<"]={ "<<IntToStr(i->second.uintValue).c_str()<<", \""<<List1[i->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;
   File<<std::endl;

   std::map<sTestStruct, unsigned int>
     mapStruct;

   mapStruct.insert(std::map<sTestStruct, unsigned int>::value_type(sTestStruct(0,"0"),0));
   mapStruct.insert(std::map<sTestStruct, unsigned int>::value_type(sTestStruct(1,"1"),1));
   mapStruct.insert(std::map<sTestStruct, unsigned int>::value_type(sTestStruct(2,"2"),2));

   std::map<sTestStruct, unsigned int>::iterator
     msi;

   if((msi=mapStruct.find(sTestStruct(1,"1")))!=mapStruct.end())
     File<<"mapStruct["<<msi->first.uintValue<<", \""<<msi->first.AnsiStringValue.c_str()<<"\"]="<<msi->second<<std::endl;
   File<<std::endl;

   std::map<unsigned int, TClassWithAllocMem>
     mapWithClass;

   char
     *tmpPtr;

   {
      TClassWithAllocMem
        tmpClassWithAllocMem1(0x0ff),
        tmpClassWithAllocMem2(0x0ff),
        tmpClassWithAllocMem3;

      tmpPtr=tmpClassWithAllocMem1.buff;
      tmpPtr=tmpClassWithAllocMem2.buff;
      tmpPtr=tmpClassWithAllocMem3.buff;
      strcpy(tmpClassWithAllocMem1.buff,"tmpClassWithAllocMem_1");
      strcpy(tmpClassWithAllocMem2.buff,"tmpClassWithAllocMem_2");
      tmpClassWithAllocMem3=tmpClassWithAllocMem2;
      tmpPtr=tmpClassWithAllocMem3.buff;
      strcpy(tmpClassWithAllocMem3.buff,"tmpClassWithAllocMem_3");
      mapWithClass.insert(std::map<unsigned int, TClassWithAllocMem>::value_type(1,tmpClassWithAllocMem1));
      mapWithClass.insert(std::map<unsigned int, TClassWithAllocMem>::value_type(2,tmpClassWithAllocMem2));
      mapWithClass.insert(std::map<unsigned int, TClassWithAllocMem>::value_type(3,tmpClassWithAllocMem3));
   }

   tmpPtr=mapWithClass[1].buff;
   tmpPtr=mapWithClass[2].buff;
   tmpPtr=mapWithClass[3].buff;

   File<<mapWithClass[1].buff<<std::endl;
   File<<mapWithClass[2].buff<<std::endl;
   File<<mapWithClass[3].buff<<std::endl;
#endif

#if defined(MULTIMAP_IN_MULTIMAP)

   typedef std::multimap<unsigned int, sTestStruct> InnerList;

   std::multimap<unsigned int, InnerList> OuterList;
   std::multimap<unsigned int, InnerList>::iterator lb,ub;
   unsigned int maxO=3,CmaxI=3,maxI;

   for(unsigned int i=0; i<maxO; i++)
      {
         OuterList.insert(std::multimap<unsigned int, InnerList>::value_type(i,InnerList()));
         if(i==1)
           OuterList.insert(std::multimap<unsigned int, InnerList>::value_type(i,InnerList()));

         if(i==1)
           maxI=CmaxI+2;
         else if(i==2)
                maxI=CmaxI-2;
              else
                maxI=CmaxI;

         lb=OuterList.lower_bound(i);
         ub=OuterList.upper_bound(i);
         for(std::multimap<unsigned int, InnerList>::iterator p=lb; p!=ub; p++)
            {
               for(unsigned int j=0; j<maxI; j++)
                  {
                     p->second.insert(std::multimap<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
                     if(j==1 || j==2)
                       p->second.insert(std::multimap<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
                     if(j==1 && p!=lb)
                       p->second.insert(std::multimap<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
                     if(i==1 && p==lb)
                       p->second.insert(std::multimap<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
                  }
            }
      }

   unsigned int CurrIdx=255;

   File<<"OuterList.size()="<<IntToStr(OuterList.size()).c_str()<<std::endl<<std::endl;
   for(std::multimap<unsigned int, InnerList>::iterator iO=OuterList.begin(); iO!=OuterList.end(); iO++)
      {
         if(CurrIdx==iO->first)
           continue;
         else
           CurrIdx=iO->first;

         lb=OuterList.lower_bound(iO->first);
         ub=OuterList.upper_bound(iO->first);
         for(std::multimap<unsigned int, InnerList>::iterator p=lb; p!=ub; p++)
            {
               File<<"OuterList["<<IntToStr(iO->first).c_str()<<"].size()="<<IntToStr(p->second.size()).c_str()<<std::endl;
               for(std::map<unsigned int, sTestStruct>::iterator iI=p->second.begin(); iI!=p->second.end(); iI++)
                  File<<"OuterList["<<IntToStr(iO->first).c_str()<<"]["<<IntToStr(iI->first).c_str()<<"]={ "<<IntToStr(iI->second.uintValue).c_str()<<", \""<<iI->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;
            }
         File<<std::endl;
      }

#endif

#if defined(MULTIMAP_IN_MAP)

   typedef std::multimap<unsigned int, sTestStruct> InnerList;

   std::map<unsigned int, InnerList> OuterList;
   unsigned int maxO=3,CmaxI=5,maxI;

   for(unsigned int i=0; i<maxO; i++)
      {
         if(OuterList.find(i)==OuterList.end())
           OuterList.insert(std::map<unsigned int, InnerList>::value_type(i,InnerList()));

         if(i==1)
           maxI=CmaxI+2;
         else if(i==2)
                maxI=CmaxI-2;
              else
                maxI=CmaxI;

         for(unsigned int j=0; j<maxI; j++)
            {
               OuterList[i].insert(std::map<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
               if(i==1 && (j==1 || j==2))
                 OuterList[i].insert(std::map<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
               if(i==1 && j==1)
                 OuterList[i].insert(std::map<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
            }
      }

   File<<"OuterList.size()="<<IntToStr(OuterList.size()).c_str()<<std::endl<<std::endl;
   for(std::map<unsigned int, InnerList>::iterator iO=OuterList.begin(); iO!=OuterList.end(); iO++)
      {
         File<<"OuterList["<<IntToStr(iO->first).c_str()<<"].size()="<<IntToStr(iO->second.size()).c_str()<<std::endl;
         for(std::multimap<unsigned int, sTestStruct>::iterator iI=OuterList[iO->first].begin(); iI!=OuterList[iO->first].end(); iI++)
            File<<"OuterList["<<IntToStr(iO->first).c_str()<<"]["<<IntToStr(iI->first).c_str()<<"]={ "<<IntToStr(iI->second.uintValue).c_str()<<", \""<<iI->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;

         File<<std::endl;
      }

   maxI=10;
   maxO=1;

   std::multimap<unsigned int, sTestStruct>::iterator lb=OuterList[maxO].lower_bound(maxI);
   std::multimap<unsigned int, sTestStruct>::iterator ub=OuterList[maxO].upper_bound(maxI);

   for(std::multimap<unsigned int, sTestStruct>::iterator p=lb; p!=ub; ++p)
      {
         File<<"OuterList["<<IntToStr(maxO).c_str()<<"]["<<IntToStr(p->first).c_str()<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<p->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;
      }
   File<<std::endl;

   typedef std::multimap<unsigned int, sTestStruct>::iterator MI;

   std::pair<MI, MI> g=OuterList[maxO].equal_range(maxI);

   for(MI p=g.first; p!=g.second; ++p)
      {
         File<<"OuterList["<<IntToStr(maxO).c_str()<<"]["<<IntToStr(p->first).c_str()<<"]={ "<<IntToStr(p->second.uintValue).c_str()<<", \""<<p->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;
      }
   File<<std::endl;

#endif

#if defined(MAP_IN_MAP)

   typedef std::map<unsigned int, sTestStruct>
     InnerList;

   std::map<unsigned int, InnerList>
     OuterList;

   unsigned int
     maxO=3,
     CmaxI=5,
     maxI;

   for(unsigned int i=0; i<maxO; i++)
      {
         if(OuterList.find(i)==OuterList.end())
           OuterList.insert(std::map<unsigned int, InnerList>::value_type(i,InnerList()));

         if(i==1)
           maxI=CmaxI+2;
         else if(i==2)
                maxI=CmaxI-2;
              else
                maxI=CmaxI;

         for(unsigned int j=0; j<maxI; j++)
            if(OuterList[i].find(j)==OuterList[i].end())
              OuterList[i].insert(std::map<unsigned int, sTestStruct>::value_type(j,sTestStruct(j,IntToStr(i)+" "+IntToStr(j))));
      }

   File<<"OuterList.size()="<<IntToStr(OuterList.size()).c_str()<<std::endl<<std::endl;
   for(std::map<unsigned int, InnerList>::iterator iO=OuterList.begin(); iO!=OuterList.end(); iO++)
      {
         File<<"OuterList["<<IntToStr(iO->first).c_str()<<"].size()="<<IntToStr(iO->second.size()).c_str()<<std::endl;

         for(std::map<unsigned int, sTestStruct>::iterator iI=OuterList[iO->first].begin(); iI!=OuterList[iO->first].end(); iI++)
            File<<"OuterList["<<IntToStr(iO->first).c_str()<<"]["<<IntToStr(iI->first).c_str()<<"]={ "<<IntToStr(iI->second.uintValue).c_str()<<", \""<<OuterList[iO->first][iI->first].AnsiStringValue.c_str()<<"\" }"<<std::endl;

         File<<std::endl;
      }

   std::pair<std::map<unsigned int, InnerList>::iterator, bool>
     pO;

   std::pair<InnerList::iterator, bool>
     pI;

   OuterList.clear();
   for(unsigned int i=0; i<maxO; i++)
      {
         pO=OuterList.insert(std::map<unsigned int, InnerList>::value_type(i,InnerList()));
         if(pO.second)
           {
              if(i==1)
                maxI=CmaxI+2;
              else if(i==2)
                     maxI=CmaxI-2;
                   else
                     maxI=CmaxI;

              for(unsigned int j=0; j<maxI; j++)
                 {
                    pI=pO.first->second.insert(std::map<unsigned int, sTestStruct>::value_type(j,sTestStruct()));
                    if(pI.second)
                      {
                         pI.first->second.uintValue=j;
                         pI.first->second.AnsiStringValue=IntToStr(i)+" "+IntToStr(j);
                      }
                 }
           }
      }

   File<<"OuterList.size()="<<IntToStr(OuterList.size()).c_str()<<std::endl<<std::endl;
   for(std::map<unsigned int, InnerList>::iterator iO=OuterList.begin(); iO!=OuterList.end(); ++iO)
      {
         File<<"OuterList["<<IntToStr(iO->first).c_str()<<"].size()="<<IntToStr(iO->second.size()).c_str()<<std::endl;

         for(InnerList::iterator iI=iO->second.begin(); iI!=iO->second.end(); ++iI)
            File<<"OuterList["<<IntToStr(iO->first).c_str()<<"]["<<IntToStr(iI->first).c_str()<<"]={ "<<IntToStr(iI->second.uintValue).c_str()<<", \""<<iI->second.AnsiStringValue.c_str()<<"\" }"<<std::endl;

         File<<std::endl;
      }

#endif

#if defined(READ_FROM_FILE)

   char
     *Buff=0;

   unsigned int
     BuffSize=0xffff,
     len;

   std::fstream
     InputFile;

   ShowMessage("InputFile.is_open()="+BoolToStr(InputFile.is_open(),true)+"\r\nInputFile.good()="+BoolToStr(InputFile.good(),true));
   //InputFile.is_open()==False
   //InputFile.good()==True

   AnsiString
     Mess,
     InputFileName=ExtractFilePath(Application->ExeName)+"test.txt";

   try
     {
        while(!Buff&&BuffSize)
          {
             Buff=new char [BuffSize];
             if(!Buff)
               BuffSize>>=1;
          }
        if(!Buff&&!BuffSize)
          {
             Mess="Insufficient memory";
             throw Exception(Mess);
          }

        std::ifstream
           f(InputFileName.c_str());

        if(!f.is_open() || !f.good())
          {
             Mess="Can't open file: \""+InputFileName+"\"";
             throw Exception(Mess);
          }

        InputFile.open(InputFileName.c_str(),std::ios_base::in);
        if(!InputFile.is_open() || !InputFile.good())
          {
             Mess="Can't open file: \""+InputFileName+"\"";
             throw Exception(Mess);
          }

        while(!InputFile.eof())
          {
             InputFile.getline(Buff,BuffSize);
             if(!InputFile.good() && !InputFile.eof())
               {
                  Mess="Data read error from file: \""+InputFileName+"\"";
                  throw Exception(Mess);
               }

             ShowMessage("\""+AnsiString(Buff)+"\" EOF="+BoolToStr(InputFile.eof(),true));

             if((len=strlen(Buff)) && *(Buff+len-1)=='\n')
               *(Buff+len-1)='\x0';
          }
     }
   __finally
     {
        if(Buff)
          delete []Buff;

        if(InputFile.is_open())
          InputFile.close();
     }

#endif

   File.close();
}
//---------------------------------------------------------------------------

