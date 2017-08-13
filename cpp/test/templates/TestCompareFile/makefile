CC=g++
PROGS=main
CFLAGS=-Wall --std=c++0x

all: $(PROGS)
	$(CC) main.o -o result

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
