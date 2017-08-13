CC=g++
PROGS=liblib make_lib main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o -ldl -o rezult

liblib: lib.cpp
	$(CC) $(CFLAGS) -fPIC -c -g3 lib.cpp -o lib.o

make_lib: liblib
	gcc -shared -o libpowers.so lib.o

main: main.cpp
	$(CC) $(CFLAGS) -c -g3 main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
