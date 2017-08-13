CC=g++
PROGS=f1 f2 make_lib main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o -L. -lfs -o rezult

f1: f1.cpp
	$(CC) $(CFLAGS) -c f1.cpp -o f1.o

f2: f2.cpp
	$(CC) $(CFLAGS) -c f2.cpp -o f2.o

make_lib: f1 f2
	ar rc libfs.a f1.o f2.o
	ranlib libfs.a

main: main.cpp
	$(CC) -Wall -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
