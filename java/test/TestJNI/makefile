IDIR=/usr/lib/jvm/java/include
CC=gcc
PROGS=libhello
CFLAGS=-Wall -I$(IDIR) -I$(IDIR)/linux -fPIC
LDFLAGS=-shared

all: $(PROGS)

libhello: HelloJNI.c
	$(CC) $(CFLAGS) $(LDFLAGS) HelloJNI.c -o libhello.so

clean:
	rm -f *.o
	rm -f *.so

