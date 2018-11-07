#ifndef CONTAINER_H
#define CONTAINER_H

class Container
{
    size_t
        size;

    int
		*intArr;

public:
    Container(size_t = 0);
    Container(const Container&);
	Container(Container&&);
    virtual ~Container(void);

	Container& operator = (const Container&);
	Container& operator = (Container&&);

    int& operator [] (int) /* const */;
};

#endif
