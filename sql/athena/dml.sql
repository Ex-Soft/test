select array [1, 2, 3, 4] as items;
select array [array[1, 2], array[3, 4]] as items;

with dataset as
(
    select 1 as x, 2 as y, 3 as z
)
select array[x, y, z] as items from dataset;

with dataset as
(
    select
        array ['hello', 'amazon', 'athena'] as words,
        array ['hi', 'alexa'] as alexa
)
select array[words, alexa] as welcome_msg from dataset;

with dataset as
(
    select
        array ['hello', 'amazon', 'athena'] as words,
        array ['hi', 'alexa'] as alexa
)
select concat(words, alexa) as welcome_msg from dataset;

select array[
    map(array['first', 'last', 'age'], array['Bob', 'Smith', '40']),
    map(array['first', 'last', 'age'], array['Jane', 'Doe', '30']),
    map(array['first', 'last', 'age'], array['Billy', 'Smith', '8'])
] as people;

select
    array[cast(map(array['a1', 'a2', 'a3'], array[1, 2, 3]) as json)] ||
    array[cast(map(array['b1', 'b2', 'b3'], array[4, 5, 6]) as json)]
as items;

with dataset as
(
    select
        array[cast(map(array['a1', 'a2', 'a3'], array[1, 2, 3]) as json)] ||
        array[cast(map(array['b1', 'b2', 'b3'], array[4, 5, 6]) as json)]
    as items
)
select items[1] as item from dataset;

with dataset as
(
    select array ['hello', 'amazon', 'athena'] as words
)
select
    element_at(words, 1) as first_word,
    element_at(words, -2) as middle_word,
    element_at(words, cardinality(words)) as last_word
from dataset;

select flatten(array[ array[1,2], array[3,4] ]) as items;

with dataset as
(
    select
        'engineering' as department,
        array['Sharon', 'John', 'Bob', 'Sally'] as users
)
select
    department,
	names
from
    dataset
    cross join unnest(users) as t(names);

with dataset as
(
    select array [
        cast(row('objectType1', array[cast(row('valueType11', 11, 'value11') as row(type varchar, id int, value varchar)), cast(row('valueType12', 12, 'value12') as row(type varchar, id int, value varchar)), cast(row('valueType13', 13, 'value13') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar)))),
        cast(row('objectType2', array[cast(row('valueType21', 21, 'value21') as row(type varchar, id int, value varchar)), cast(row('valueType22', 22, 'value22') as row(type varchar, id int, value varchar)), cast(row('valueType23', 23, 'value23') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar)))),
        cast(row('objectType3', array[cast(row('valueType31', 31, 'value31') as row(type varchar, id int, value varchar)), cast(row('valueType32', 32, 'value32') as row(type varchar, id int, value varchar)), cast(row('valueType33', 33, 'value33') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar))))
    ] as objects
)
select
    *
from
    dataset;

with dataset as
(
    select array [
        cast(row('objectType1', array[cast(row('valueType11', 11, 'value11') as row(type varchar, id int, value varchar)), cast(row('valueType12', 12, 'value12') as row(type varchar, id int, value varchar)), cast(row('valueType13', 13, 'value13') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar)))),
        cast(row('objectType2', array[cast(row('valueType21', 21, 'value21') as row(type varchar, id int, value varchar)), cast(row('valueType22', 22, 'value22') as row(type varchar, id int, value varchar)), cast(row('valueType23', 23, 'value23') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar)))),
        cast(row('objectType3', array[cast(row('valueType31', 31, 'value31') as row(type varchar, id int, value varchar)), cast(row('valueType32', 32, 'value32') as row(type varchar, id int, value varchar)), cast(row('valueType33', 33, 'value33') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar))))
    ] as objects
),
objects as
(
    select
        object
    from
        dataset,
        unnest(dataset.objects) as t(object)
)
select
    object.type,
    object."values"
from
    objects;

with dataset as
(
    select array [
        cast(row('objectType1', array[cast(row('valueType11', 11, 'value11') as row(type varchar, id int, value varchar)), cast(row('valueType12', 12, 'value12') as row(type varchar, id int, value varchar)), cast(row('valueType13', 13, 'value13') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar)))),
        cast(row('objectType2', array[cast(row('valueType21', 21, 'value21') as row(type varchar, id int, value varchar)), cast(row('valueType22', 22, 'value22') as row(type varchar, id int, value varchar)), cast(row('valueType23', 23, 'value23') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar)))),
        cast(row('objectType3', array[cast(row('valueType31', 31, 'value31') as row(type varchar, id int, value varchar)), cast(row('valueType32', 32, 'value32') as row(type varchar, id int, value varchar)), cast(row('valueType33', 33, 'value33') as row(type varchar, id int, value varchar))]) as row(type varchar, "values" array(row(type varchar, id int, value varchar))))
    ] as objects
),
objects as
(
    select
        object
    from
        dataset,
        unnest(dataset.objects) as t(object)
)
select
    object.type,
    value.id,
    value.type,
    value.value
from
    objects
    cross join unnest(object."values") as t(value)
order by object.type;
