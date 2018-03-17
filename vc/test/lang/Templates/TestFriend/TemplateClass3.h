#ifndef TEMPLATE_CLASS_3_H
#define TEMPLATE_CLASS_3_H

#include <iostream>

template <typename T> class TemplateClass3
{
public:
    T
        x,
        y;

    TemplateClass3(T=T(), T=T());
    TemplateClass3(const TemplateClass3<T>&);
    ~TemplateClass3(void);

    TemplateClass3<T>& operator = (const TemplateClass3<T>&);
        
    template <typename T> friend std::ostream& operator << (std::ostream& os, const TemplateClass3<T>&);
};

template <typename T> TemplateClass3<T>::TemplateClass3(T aX, T aY) : x(aX), y(aY)
{
    std::cout<<"template <typename T> TemplateClass3::TemplateClass3(T=T(), T=T())"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass3<T>::TemplateClass3(const TemplateClass3<T> &a) : x(a.x), y(a.y)
{
    std::cout<<"template <typename T> TemplateClass3<T>::TemplateClass3(const TemplateClass3<T>&)"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass3<T>::~TemplateClass3(void)
{
    std::cout<<"template <typename T> TemplateClass3<T>::~TemplateClass3(void)"<<std::endl;
}

template <typename T> TemplateClass3<T> &  TemplateClass3<T>::operator = (const TemplateClass3<T> &aA)
{
    std::cout<<"template <typename T> TemplateClass3<T> &  TemplateClass3<T>::operator = (const TemplateClass3<T>&)"<<std::endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
    }

    return(*this);
}
 
template <typename T> std::ostream& operator << (std::ostream& os, const TemplateClass3<T> &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<" }";

    return os;
}

#endif
