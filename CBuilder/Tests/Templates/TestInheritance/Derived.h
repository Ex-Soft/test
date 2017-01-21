#ifndef DERIVED_H
#define DERIVED_H

#include "Base.h"

template <typename T> class DerivedClass;

template<typename T> bool operator == (const DerivedClass<T>&, const DerivedClass<T>&);
template<typename T> bool operator != (const DerivedClass<T>&, const DerivedClass<T>&);

template<typename T> std::ostream& operator << (std::ostream& os, const DerivedClass<T>&);

template <typename T> class DerivedClass : public BaseClass<T>
{
public:
    T
        z;

    DerivedClass(T=T(), T=T(), T=T());
    DerivedClass(const DerivedClass<T>&);
    virtual ~DerivedClass(void);

    DerivedClass<T>& operator = (const DerivedClass<T>&);

    void ToString(void);

    friend bool operator == <> (const DerivedClass<T>&, const DerivedClass<T>&);
    friend bool operator != <> (const DerivedClass<T>&, const DerivedClass<T>&);

    friend std::ostream& operator << <> (std::ostream& os, const DerivedClass<T>&);
};

template <typename T> DerivedClass<T>::DerivedClass(T aX, T aY, T aZ) : BaseClass<T>(aX, aY), z(aZ)
{
    std::cout<<"template <typename T> DerivedClass::DerivedClass(T=T(), T=T(), T=T())"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> DerivedClass<T>::DerivedClass(const DerivedClass<T> &a) : BaseClass<T>(a.x, a.y), z(a.z)
{
    std::cout<<"template <typename T> DerivedClass<T>::DerivedClass(const DerivedClass<T>&)"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> DerivedClass<T>::~DerivedClass(void)
{
    std::cout<<"template <typename T> DerivedClass<T>::~DerivedClass(void)"<<std::endl;
}

template <typename T> DerivedClass<T> &  DerivedClass<T>::operator = (const DerivedClass<T> &aA)
{
    std::cout<<"template <typename T> DerivedClass<T> &  DerivedClass<T>::operator = (const DerivedClass<T>&)"<<std::endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
        z=aA.z;
    }

    return(*this);
}

template <typename T> void DerivedClass<T>::ToString(void)
{
    std::cout<<"{ x: "<<x<<", y: "<<y<<", z: "<<z<<" }"<<std::endl;
}

template <typename T> bool operator == (const DerivedClass<T> &aAL, const DerivedClass<T> &aAR)
{
   std::cout<<"template <typename T> bool operator == (const DerivedClass<T>&, const DerivedClass<T>&)"<<std::endl;
   return(aAL.x==aAR.x && aAL.y==aAR.y && aAL.z==aAR.z);
}

template <typename T> bool operator != (const DerivedClass<T> &aAL, const DerivedClass<T> &aAR)
{
   std::cout<<"template <typename T> bool operator != (const DerivedClass<T>&, const DerivedClass<T>&)"<<std::endl;
   return(!(aAL==aAR));
}

template <typename T> std::ostream& operator << (std::ostream& os, const DerivedClass<T> &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<", z: "<<aA.z<<" }";

    return os;
}

#endif
