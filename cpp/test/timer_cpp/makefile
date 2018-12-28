CC=g++
PROGS=main
CFLAGS=-Wall -std=c++14 -pthread -fconcepts
LDFLAGS=-L/usr/lib -pthread

all: $(PROGS)
	$(CC) $(LDFLAGS) main.o -o result

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
