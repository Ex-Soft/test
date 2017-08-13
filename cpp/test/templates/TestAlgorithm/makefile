CC=g++
PROGS=Algorithm1 Algorithm2 main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o Algorithm1.o Algorithm2.o -o result

Algorithm1: Algorithm1.cpp
	$(CC) $(CFLAGS) -c Algorithm1.cpp -o Algorithm1.o

Algorithm2: Algorithm2.cpp
	$(CC) $(CFLAGS) -c Algorithm2.cpp -o Algorithm2.o

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
