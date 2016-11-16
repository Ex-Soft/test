select cast('0,123' as number(10,6)) from dual;
select cast('0,123' as numeric(10,6)) from dual;
select to_number('0.123','99999999999999d999999','nls_numeric_characters=''. ''') from dual;
select to_number('0,123') from dual;
select cast(replace('0.123','.',',') as number(10,6)) from dual;
select * from nls_session_parameters where parameter = 'NLS_NUMERIC_CHARACTERS';
