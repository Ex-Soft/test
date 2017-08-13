CC=g++
PROGS=f1 f2 make_lib main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o -L. -lfsdyn -o rezult

f1: f1.cpp
	$(CC) $(CFLAGS) -fPIC -c f1.cpp -o f1.o

f2: f2.cpp
	$(CC) $(CFLAGS) -fPIC -c f2.cpp -o f2.o

make_lib: f1 f2
	gcc -shared -o libfsdyn.so f1.o f2.o

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
