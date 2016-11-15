#ifndef TEMPLATE_CLASS_1_H
#define TEMPLATE_CLASS_1_H

template <typename T> class TemplateClass1;

template <typename T> std::ostream& operator << (std::ostream& os, const TemplateClass1<T>&);

template <typename T> class TemplateClass1
{
public:
    T
        x,
        y;

    TemplateClass1(T=T(), T=T());
    TemplateClass1(const TemplateClass1<T>&);
    ~TemplateClass1(void);

    TemplateClass1<T>& operator = (const TemplateClass1<T>&);

    friend std::ostream& operator << <> (std::ostream& os, const TemplateClass1<T>&);
};

template <typename T> TemplateClass1<T>::TemplateClass1(T aX, T aY) : x(aX), y(aY)
{
    std::cout<<"template <typename T> TemplateClass1::TemplateClass1(T=T(), T=T())"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass1<T>::TemplateClass1(const TemplateClass1<T> &a) : x(a.x), y(a.y)
{
    std::cout<<"template <typename T> TemplateClass1<T>::TemplateClass1(const TemplateClass1<T>&)"<<std::endl;
    std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass1<T>::~TemplateClass1(void)
{
    std::cout<<"template <typename T> TemplateClass1<T>::~TemplateClass1(void)"<<std::endl;
}

template <typename T> TemplateClass1<T> &  TemplateClass1<T>::operator = (const TemplateClass1<T> &aA)
{
    std::cout<<"template <typename T> TemplateClass1<T> &  TemplateClass1<T>::operator = (const TemplateClass1<T>&)"<<std::endl;

    if(this!=&aA)
    {
        x=aA.x;
        y=aA.y;
    }

    return(*this);
}
 
template <typename T> std::ostream& operator << (std::ostream& os, const TemplateClass1<T> &aA)
{
    os<<"{ x: "<<aA.x<<", y: "<<aA.y<<" }";

    return os;
}

#endif