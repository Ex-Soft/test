#ifndef TEMPLATE_CLASS_H
#define TEMPLATE_CLASS_H

template <typename T, typename C> class TemplateClass
{
public:
   void DoSmth(void);
};

template <typename T, typename C> void TemplateClass<T, C>::DoSmth(void)
{
   C::DoSmth();
}

#endif
