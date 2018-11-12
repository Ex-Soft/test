CC=g++
PROGS=main ClassWString
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o ClassWString.o -o result

ClassWString: ClassWString.cpp ClassWString.h
	$(CC) $(CFLAGS) -c ClassWString.cpp -o ClassWString.o

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
