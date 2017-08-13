// http://www.sql.ru/forum/1105079/mozhno-li-sdelat-kod-dlya-sravneniya-dvuh-faylov-bystree-i-krasivee

#include<algorithm>
#include<iterator>
#include<iostream>
#include<fstream>
#include<string>
#include<assert.h>

#define WITH_OWN_ALGORITHM

#ifdef WITH_OWN_ALGORITHM

template <class T> bool equal (T first1, T first2, T last)
{
	for(; first1 != last && first2 != last; ++first1, ++first2)
		if(!(*first1 == *first2) )
			return false;

	return first1 == last && first2 == last;
}

#endif

int main(int argc, char *argv[])
{
	assert(argc == 3);

	std::ifstream s1(argv[1]);
	std::ifstream s2(argv[2]);

	#ifdef WITH_OWN_ALGORITHM
		typedef std::istream_iterator<std::string> iter;

		std::cout << (equal(iter(s1), iter(s2), iter()) ? "match" : "nonmatch" ) << std::endl;
	#else
		auto last = std::istream_iterator<std::string>();
		auto eq = std::mismatch( std::istream_iterator<std::string>(s1), last, std::istream_iterator<std::string>(s2) );

		std::cout << (eq.first == last && eq.second == last ? "match" : "nonmatch") << std::endl;
	#endif
}
