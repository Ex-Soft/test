IDIR=/etc/alternatives/java_sdk_1.8.0/include
CC=gcc
PROGS=libhello
CFLAGS=-Wall -I$(IDIR) -I$(IDIR)/linux
LDFLAGS=-shared

all: $(PROGS)

libhello: HelloJNI.c
	$(CC) $(CFLAGS) $(LDFLAGS) HelloJNI.c -o libhello.so

clean:
	rm -f *.o
	rm -f *.so

