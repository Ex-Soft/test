CC=g++
CFLAGS=-Wall

TARGET=main

all: $(TARGET)
	$(CC) $(TARGET).o -o $(TARGET)

$(TARGET): $(TARGET).cpp
	$(CC) $(CFLAGS) -c $(TARGET).cpp -o $(TARGET).o

clean:
	rm -f *.o
	rm -f *.so
	rm -f *.a
	rm -f $(TARGET)
