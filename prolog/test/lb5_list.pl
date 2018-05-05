write_a_list([]).
write_a_list([H|T]) :- /* Виділяємо голову списку Н і хвіст Т, потім роздруковуєм Н і рекурсивно обробляємо Т */ write(H), nl, write_a_list(T).

length_of([], 0).
length_of([_|T], L) :- length_of(T, TailLength), L = TailLength + 1.

length_of_with_counter([], Result, Result).
length_of_with_counter([_|T], Result, Counter) :- NewCounter=Counter + 1,length_of_with_counter(T, Result, NewCounter).
% length_of_with_counter([1,2,3], L, 0) /* починає з значенням Counter = 0 */, write(L), nl.

sumlist([], 0, 0).
sumlist([H|T], Sum, N) :- sumlist(T, S1, N1),
Sum=H+S1,
N=1+N1.

person("Sherlock Holmes", "22B Baker Street", 42).
person("Pete Spiers", "Apt. 22, 21st Street", 36).
person("Mary Darrow", "Suite 2, Omega Home", 51).
% findall(Age, person(_, _, Age), L), sumlist(L, Sum, N), Ave = Sum/N, write(/*"Average =", */Ave), nl.
% findall(Who, person(Who,_,42), List).

word(abc).
word(abcd).
word(abcdf).

is_a_member_of(Name,[Name|_]).
is_a_member_of(Name,[_|Tail]) :- is_a_member_of(Name,Tail).


