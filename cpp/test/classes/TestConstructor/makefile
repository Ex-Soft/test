CC=g++
PROGS=main a c d container
CFLAGS=-Wall

all: $(PROGS)
	$(CC) main.o a.o c.o d.o container.o -o result

a: a.cpp a.h b.h
	$(CC) $(CFLAGS) -c a.cpp -o a.o

c: c.cpp c.h a.h
	$(CC) $(CFLAGS) -c c.cpp -o c.o

d: d.cpp d.h
	$(CC) $(CFLAGS) -c d.cpp -o d.o

container: container.cpp container.h
	$(CC) $(CFLAGS) -c container.cpp -o container.o

main: main.cpp
	$(CC) $(CFLAGS) -c main.cpp -o main.o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(PROGS)
