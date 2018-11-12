CC=g++
PROGS=ClassWOperators main
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o ClassWOperators.o -o rezult

ClassWOperators: ClassWOperators.cpp ClassWOperators.h
	$(CC) $(CFLAGS) -c ClassWOperators.cpp -o ClassWOperators.o

main: main.cpp ClassWOperators.h
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
