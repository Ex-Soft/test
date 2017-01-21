#ifndef BASE_H
#define BASE_H

#include <iostream>
#include <typeinfo>

template <typename T> class BaseClass;

template <typename T> bool operator == (const BaseClass<T>&, const BaseClass<T>&);
template <typename T> bool operator != (const BaseClass<T>&, const BaseClass<T>&);

template <typename T> std::ostream& operator << (std::ostream& os, const BaseClass<T>&);

template <typename T> class BaseClass
{
public:
    T
        x,
        y;

    BaseClass(T=T(), T=T());
    BaseClass(const BaseClass<T>&);
    virtual ~BaseClass(void);

    BaseClass<T>& operator = (const BaseClass<T>&);

    virtual void ToString(void);
    virtual void ShowTypeId(void);

    friend bool operator == <> (const BaseClass<T>&, const BaseClass<T>&);
    friend bool operator != <> (const BaseClass<T>&, const BaseClass<T>&);

    friend std::ostream& operator << <> (std::ostream& os, const BaseClass<T>&);
};

template <typename T> BaseClass<T>::BaseClass(T aX, T aY) : x(aX), y(aY)
{
    std::cout<<"template <typename T> BaseClass::BaseClass(T=T(), T=T())"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> BaseClass<T>::BaseClass(const BaseClass<T> &a) : x(a.x), y(a.y)
{
    std::cout<<"template <typename T> BaseClass<T>::BaseClass(const BaseClass<T>&)"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> BaseClass<T>::~BaseClass(void)
{
    std::cout<<"template <typename T> BaseClass<T>::~BaseClass(void)"<<std::endl;
}

template <typename T> BaseClass<T> &  BaseClass<T>::operator = (const BaseClass<T> &aA)
{
    std::cout<<"template <typename T> BaseClass<T> &  BaseClass<T>::operator = (const BaseClass<T>&)"<<std::endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
    }

    return(*this);
}

template <typename T> void BaseClass<T>::ToString(void)
{
    std::cout<<"{ x: "<<x<<", y: "<<y<<" }"<<std::endl;
}

template <typename T> void BaseClass<T>::ShowTypeId(void)
{
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> bool operator == (const BaseClass<T> &aAL, const BaseClass<T> &aAR)
{
   std::cout<<"template <typename T> bool operator == (const BaseClass<T>&, const BaseClass<T>&)"<<std::endl;
   return(aAL.x==aAR.x && aAL.y==aAR.y);
}

template <typename T> bool operator != (const BaseClass<T> &aAL, const BaseClass<T> &aAR)
{
   std::cout<<"template <typename T> bool operator != (const BaseClass<T>&, const BaseClass<T>&)"<<std::endl;
   return(!(aAL==aAR));
}

template <typename T> std::ostream& operator << (std::ostream& os, const BaseClass<T> &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<" }";

    return os;
}

#endif