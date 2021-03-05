select array_agg(x) from (values ('{1, 2}'), ('{3, 4}')) x(x);
/* {"{1, 2}","{3, 4}"} */

select array_agg(x) from (values ('{1, 2}'), ('{3, 4}'), (array[5, 6])) x(x);
/* {{1,2},{3,4},{5,6}} */
