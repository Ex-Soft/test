#ifndef TEMPLATE_CLASS_2_H
#define TEMPLATE_CLASS_2_H

#include <iostream>
#include <typeinfo>

template <typename T> class TemplateClass2
{
public:
    T
        x,
        y;

    TemplateClass2(T=T(), T=T());
    TemplateClass2(const TemplateClass2<T>&);
    ~TemplateClass2(void);

    TemplateClass2<T>& operator = (const TemplateClass2<T>&);

    template <typename TT> friend std::ostream& operator << (std::ostream& os, const TemplateClass2<TT>&); // E2335 Overloaded 'operator ostream & << <int>(ostream &,const TemplateClass2<int> &)' ambiguous in this context
};

template <typename T> TemplateClass2<T>::TemplateClass2(T aX, T aY) : x(aX), y(aY)
{
    std::cout<<"template <typename T> TemplateClass2::TemplateClass2(T=T(), T=T())"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass2<T>::TemplateClass2(const TemplateClass2<T> &a) : x(a.x), y(a.y)
{
    std::cout<<"template <typename T> TemplateClass2<T>::TemplateClass2(const TemplateClass2<T>&)"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass2<T>::~TemplateClass2(void)
{
    std::cout<<"template <typename T> TemplateClass2<T>::~TemplateClass2(void)"<<std::endl;
}

template <typename T> TemplateClass2<T> &  TemplateClass2<T>::operator = (const TemplateClass2<T> &aA)
{
    std::cout<<"template <typename T> TemplateClass2<T> &  TemplateClass2<T>::operator = (const TemplateClass2<T>&)"<<std::endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
    }

    return(*this);
}
 
template <typename T> std::ostream& operator << (std::ostream& os, const TemplateClass2<T> &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<" }";

    return os;
}

#endif