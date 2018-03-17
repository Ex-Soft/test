#include <iostream>
#include <stdarg.h>
#include <assert.h>

#define begin {
#define end }

#ifndef MSG
#define MSG "Smth message"
#endif

#ifndef MAX
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#endif

// https://docs.microsoft.com/en-us/cpp/preprocessor/stringizing-operator-hash
// Stringizing Operator (#)
#define stringer(x) printf(#x "\n")

#define F abc  
#define B def  
#define FB(arg) #arg  
#define FB1(arg) FB(arg)

// https://docs.microsoft.com/en-us/cpp/preprocessor/token-pasting-operator-hash-hash
// Token-Pasting Operator (##)
#define paster(n) printf("token" #n " = %d\n", token##n)

// https://docs.microsoft.com/en-us/cpp/preprocessor/charizing-operator-hash-at
// Charizing Operator (#@)
#define makechar(x)  #@x

#pragma pack(show)
#pragma pack(push, 1)
#pragma pack(show)
struct t1 {
	char a;
	float b;
};
#pragma pack(pop) 

struct t2 {
	char a;
	float b;
};

void foo(int count, ...);
#define FOO(count, ...) foo(count, __VA_ARGS__)

int main(int argc, char **argv)
{
	int tmpInt = 9;
	//assert(tmpInt > 10);

	printf("In quotes in the printf function call\n" "\n");
	printf("\"In quotes when printed to the screen\"\n" "\n");
	printf("\"This: \\\" prints an escaped double quote\"" "\n");

	stringer(In quotes in the printf function call);
	stringer("In quotes when printed to the screen");
	stringer("This: \"  prints an escaped double quote");

	const char *const_char_ptr = FB(F B); // "F B"
	std::cout << "FB(F B) = \"" << const_char_ptr << "\"" << std::endl;
	
	const_char_ptr = FB1(F B); // "abc def"
	std::cout << "FB1(F B) = \"" << const_char_ptr << "\"" << std::endl;

	int token9 = 9;
	paster(9);
	// printf("token" "9" " = %d", token9);
	// printf("token9 = %d", token9);

	char a = makechar(b);
	// a = 'b';

	std::cout << "__FILE__ = \"" << __FILE__ << "\"" << std::endl;
	std::cout << "__LINE__ = \"" << __LINE__ << "\"" << std::endl;
	std::cout << "__DATE__ = \"" << __DATE__ << "\"" << std::endl;
	std::cout << "__TIME__ = \"" << __TIME__ << "\"" << std::endl;
	std::cout << "__TIMESTAMP__ = \"" << __TIMESTAMP__ << "\"" << std::endl;

	#if __STDC__
	std::cout << "__STDC__" << std::endl;
	#endif

	#if __cplusplus
	std::cout << "__cplusplus" << std::endl;
	#endif

	#if _WIN32
	std::cout << "_WIN32" << std::endl;
	#endif

	#if _WIN64
	std::cout << "_WIN64" << std::endl;
	#endif

	#ifdef MSG
	std::cout << "MSG = \"" << MSG << "\"" << std::endl;
	#endif

	#ifdef MAX
	std::cout << "MAX(169, 13) = " << MAX(169, 13) << std::endl;
	std::cout << "MAX(13 + 169, 169 + 13) = " << MAX(13 + 169, 169 + 13) << std::endl;
	#endif

	#define SMTH_VAL 5
	#ifdef SMTH_VAL
	std::cout << "SMTH_VAL = " << SMTH_VAL << std::endl;
	#endif

	#if SMTH_VAL == 5
	std::cout << "SMTH_VAL == " << SMTH_VAL << std::endl;
	#endif

	#define SMTH_VAL 10
	#ifdef SMTH_VAL
		std::cout << "SMTH_VAL = " << SMTH_VAL << std::endl;
	#endif

	#undef SMTH_VAL
	#ifdef SMTH_VAL
	std::cout << "SMTH_VAL = " << SMTH_VAL << std::endl;
	#endif

	#ifndef SMTH_VAL
	//#error "SMTH_VAL is undefined"
	#endif

	//#pragma warning

	std::cout << std::boolalpha << (sizeof(t1) == sizeof(t2)) << std::endl;

	foo(5, "1st", "2nd", "3rd", "4th", "5th");
	FOO(5, "1st", "2nd", "3rd", "4th", "5th");

	return 0;
}

void foo(int count, ...)
begin
	std::cout << "__FUNCTION__ = \"" << __FUNCTION__ << "\"" << std::endl;
	std::cout << "__FUNCDNAME__ = \"" << __FUNCDNAME__ << "\"" << std::endl;
	std::cout << "__FUNCSIG__ = \"" << __FUNCSIG__ << "\"" << std::endl;
	std::cout << "__func__ = \"" << __func__ << "\"" << std::endl;

	const char *value;

	va_list vl;
	va_start(vl, count);

	for (int i = 0; i < count; ++i)
	begin
		value = va_arg(vl, const char *);
		std::cout << "[" << i << "] = \"" << value << "\"" << std::endl;
	end

	va_end(vl);
end
