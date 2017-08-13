#ifndef TEMPLATE_CLASS_H
#define TEMPLATE_CLASS_H

#include <iostream>
#include <typeinfo>

template <typename T> class TemplateClass;

template <typename T> bool operator == (const TemplateClass<T>&, const TemplateClass<T>&);
template <typename T> bool operator != (const TemplateClass<T>&, const TemplateClass<T>&);

template <typename T> std::ostream& operator << (std::ostream& os, const TemplateClass<T> &aA);

template <typename T> class TemplateClass
{
public:
	T
		x,
		y;

	TemplateClass(T=T(), T=T());
	TemplateClass(const TemplateClass<T>&);
	virtual ~TemplateClass(void);

	TemplateClass<T>& operator = (const TemplateClass<T>&);

	virtual void ToString(void);
	virtual void ShowTypeId(void);

	friend bool operator == <> (const TemplateClass<T>&, const TemplateClass<T>&);
	friend bool operator != <> (const TemplateClass<T>&, const TemplateClass<T>&);

	friend std::ostream& operator << <> (std::ostream& os, const TemplateClass<T>&);
};

template <typename T> TemplateClass<T>::TemplateClass(T aX, T aY) : x(aX), y(aY)
{
	std::cout<<"template <typename T> TemplateClass::TemplateClass(T=T(), T=T())"<<std::endl;
	std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass<T>::TemplateClass(const TemplateClass<T> &a) : x(a.x), y(a.y)
{
	std::cout<<"template <typename T> TemplateClass<T>::TemplateClass(const TemplateClass<T>&)"<<std::endl;
	std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> TemplateClass<T>::~TemplateClass(void)
{
	std::cout<<"template <typename T> TemplateClass<T>::~TemplateClass(void)"<<std::endl;
}

template <typename T> TemplateClass<T> &  TemplateClass<T>::operator = (const TemplateClass<T> &aA)
{
	std::cout<<"template <typename T> TemplateClass<T> &  TemplateClass<T>::operator = (const TemplateClass<T>&)"<<std::endl;

	if(this!=&aA)
	{
		x=aA.x;
		y=aA.y;
	}

	return(*this);
}

template <typename T> void TemplateClass<T>::ToString(void)
{
	std::cout<<"{ x: "<<x<<", y: "<<y<<" }"<<std::endl;
}

template <typename T> void TemplateClass<T>::ShowTypeId(void)
{
	std::cout<<typeid(*this).name()<<std::endl;
}

template <typename T> bool operator == (const TemplateClass<T> &aAL, const TemplateClass<T> &aAR)
{
	std::cout<<"template <typename T> bool operator == (const TemplateClass<T>&, const TemplateClass<T>&)"<<std::endl;
	return(aAL.x==aAR.x && aAL.y==aAR.y);
}

template <typename T> bool operator != (const TemplateClass<T> &aAL, const TemplateClass<T> &aAR)
{
	std::cout<<"template <typename T> bool operator != (const TemplateClass<T>&, const TemplateClass<T>&)"<<std::endl;
	return(!(aAL==aAR));
}

template <typename T> std::ostream& operator << (std::ostream& os, const TemplateClass<T> &aA)
{
	os<<"{ x: "<<aA.x<<", y: "<<aA.y<<" }";

	return os;
}

#endif
