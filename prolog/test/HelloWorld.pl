% животные
animal(X) :-
    dog(X); % это либо собака
    cat(X); % либо кошка
    hamster(X). % либо хомячок

% Читается как: X - животное, если X - собака, либо Х - кошка, либо Х - хомяк.

% люди
human(X) :-
    man(X); % либо мужчина
    woman(X). % либо женщина

% живые (или жившие) существа
living(X) :-
    animal(X);
    human(X).

% живые (в данный момент) существа
alive(X) :-
    living(X),
    \+ dead(X).

% старый
old(X) :-
    (   animal(X)
    ->  age(X, Age),
        Age >= 10 % считаем, что животные старше 10 лет - старые
    ;   human(X),
        age(X, Age),
        Age >= 60 % считаем, что люди старше 60 лет - старые
    ), 
    \+ dead(X). % старые, но при этом - живые

% молодой - значит - живой и не старый
young(X) :-
    alive(X),
    \+ old(X).

% собаки
dog(sharik). % дословно означает, что Шарик - собака
dog(tuzik). % --//--

% кошки
cat(pushok).
cat(druzgok).

% хомячки
hamster(pit).

% мужчины
man(bill).
man(george).
man(barak).
man(platon).
man(sokrat).

% женщины
woman(ann).
woman(kate).
woman(pam).

% ныне покойные
dead(sharik).
dead(platon).
dead(sokrat).

% возраст
age(sharik, 18). % возраст Шарика - 18 лет
age(tuzik, 10). % --//--
age(pushok, 5).
age(druzhok, 2).
age(bill, 62).
age(george, 62).
age(barak, 47).
age(sokrat, 70).
age(platon, 80).
age(ann, 20).
age(kate, 25).
age(pam, 30).

