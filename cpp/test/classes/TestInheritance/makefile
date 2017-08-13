CC=g++
PROGS=Base Derived main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o Base.o Derived.o -o result

Base: Base.cpp Base.h
	$(CC) $(CFLAGS) -c Base.cpp -o Base.o

Derived: Derived.cpp Derived.h
	$(CC) $(CFLAGS) -c Derived.cpp -o Derived.o

main: main.cpp Base.h Derived.h
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
