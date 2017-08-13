CC=g++
PROGS=ClassWithStaticMethod main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o ClassWithStaticMethod.o -o rezult

ClassWithStaticMethod: ClassWithStaticMethod.cpp ClassWithStaticMethod.h
	$(CC) $(CFLAGS) -c ClassWithStaticMethod.cpp -o ClassWithStaticMethod.o

main: main.cpp ClassWithStaticMethod.h
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
