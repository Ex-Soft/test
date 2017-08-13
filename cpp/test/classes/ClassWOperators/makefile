CC=g++
PROGS=main classwoperators container
CFLAGS=-Wall	

all: $(PROGS)
	$(CC) main.o classwoperators.o container.o -o result

classwoperators: classwoperators.cpp classwoperators.h
	$(CC) $(CFLAGS) -c classwoperators.cpp -o classwoperators.o

container: container.cpp container.h
	$(CC) $(CFLAGS) -c container.cpp -o container.o

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)

