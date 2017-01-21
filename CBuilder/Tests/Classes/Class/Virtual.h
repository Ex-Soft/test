//---------------------------------------------------------------------------

#ifndef VirtualH
#define VirtualH
//---------------------------------------------------------------------------

class TBaseBase
{
public:
   virtual void f1(void);
};

class TDerivedDerived:public TBaseBase
{
public:
   void f1(void);
};

class TDerivedDerivedDerived:public TDerivedDerived
{
public:
   void f1(void);
};

#endif
 