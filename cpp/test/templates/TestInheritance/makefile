CC=g++
PROGS=a main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o a.o -o result

a: a.cpp
	$(CC) $(CFLAGS) -c a.cpp -o a.o

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
