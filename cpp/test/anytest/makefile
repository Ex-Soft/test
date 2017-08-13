CC=g++
PROGS=main a container
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o a.o container.o -o result

a: a.cpp a.h
	$(CC) $(CFLAGS) -c a.cpp -o a.o

container: container.cpp container.h
	$(CC) $(CFLAGS) -c container.cpp -o container.o

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)

