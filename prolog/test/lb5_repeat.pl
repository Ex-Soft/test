repeat.
repeat :- repeat.

typewriter :- repeat,
readchar(C),
write(C),
char_int(C,13).
