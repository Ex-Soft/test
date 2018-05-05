print_countries :- write("Some delightful places to live are"), nl, fail.
print_countries :- country(X), write(X) /* write the value of X */, nl /* start a new line */, fail.
print_countries :- write(" And maybe others."), nl.

country(england).
country(france).
country(germany).
country(denmark).
