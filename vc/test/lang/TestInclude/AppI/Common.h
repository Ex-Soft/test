#ifndef __COMMON_H__
#define __COMMON_H__

// http://stackoverflow.com/questions/1562074/how-do-i-show-the-value-of-a-define-at-compile-time

#define VALUE_TO_STRING(x) #x
#define VALUE(x) VALUE_TO_STRING(x)
#define VAR_NAME_VALUE(var) #var "=" VALUE(var)

#pragma message(VAR_NAME_VALUE(_MSC_VER))

#define COMMON_STR "AppI"

extern void Foo(void);

#endif
