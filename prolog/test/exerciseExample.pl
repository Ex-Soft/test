not_(1, 0).
not_(0, 1).

and_(0, 0, 0).
and_(0, 1, 0).
and_(1, 0, 0).
and_(1, 1, 1).

or_(0, 0, 0).
or_(0, 1, 1).
or_(1, 0, 1).
or_(1, 1, 1).

xor(Input1, Input2, Output) :-
	not_(Input1, N1),
	not_(Input2, N2),
	and_(Input1, N2, N3),
	and_(Input2, N1, N4),
	or_(N3, N4, Output).

