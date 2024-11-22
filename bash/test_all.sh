#!/bin/bash

# Cheatsheet:
# A; B    # Run A and then B, regardless of success of A
# A && B  # Run B if and only if A succeeded
# A || B  # Run B if and only if A failed
# A &     # Run A in background.

Number_of_expected_args=2

if [ $# -ne "$Number_of_expected_args" ]
then
  echo "Usage: `basename $0` whatever"
fi

echo "Символ # не означает начало комментария."
echo 'Символ # не означает начало комментария.'
echo Символ \# не означает начало комментария.
echo А здесь символ # означает начало комментария.

echo ${PATH#*:}       # Подстановка -- не комментарий.
echo $(( 2#101011 ))  # База системы счисления -- не комментарий.

Array=(element1 element2 element3)

echo

echo "Проверяется \"0\""
if [ 0 ] # ноль
then
  echo "0 -- это истина."
else
  echo "0 -- это ложь."
fi # 0 -- это истина.

echo

echo "Проверяется \"1\""
if [ 1 ] # единица
then
  echo "1 -- это истина."
else
  echo "1 -- это ложь."
fi # 1 -- это ложь.

echo

echo "Testing \"-1\""
if [ -1 ] # минус один
then
  echo "-1 -- это истина."
else
  echo "-1 -- это ложь."
fi # -1 -- это истина.

echo

echo "Проверяется \"NULL\""
if [ ] # NULL (пустое условие)
then
  echo "NULL -- это истина."
else
  echo "NULL -- это ложь."
fi # NULL -- это ложь.

echo

echo "Проверяется \"xyz\""
if [ xyz ] # строка
then
  echo "Случайная строка -- это истина."
else
  echo "Случайная строка -- это ложь."
fi # Случайная строка -- это истина.

echo

echo "Проверяется \"\$xyz\""
if [ $xyz ] # Проверка, если $xyz это null, но...
            # только для неинициализированных переменных.
then
  echo "Неинициализированная переменная -- это истина."
else
  echo "Неинициализированная переменная -- это ложь."
fi # Неинициализированная переменная -- это ложь.

echo

echo "Проверяется \"-n \$xyz\""
if [ -n "$xyz" ] # Более корректный вариант.
then
  echo "Неинициализированная переменная -- это истина."
else
  echo "Неинициализированная переменная -- это ложь."
fi # Неинициализированная переменная -- это ложь.

echo

xyz= # Инициализирована пустым значением.

echo "Проверяется \"-n \$xyz\""
if [ -n "$xyz" ]
then
  echo "Пустая переменная -- это истина."
else
  echo "Пустая переменная -- это ложь."
fi # Пустая переменная -- это ложь.
					      
echo
					      
# Кргда "ложь" истинна?

echo "Проверяется \"false\""
if [ "false" ] #  это обычная строка "false".
then
  echo "\"false\" -- это истина." #+ и она истинна.
else
  echo "\"false\" -- это ложь."
fi # "false" -- это истина.

echo

echo "Проверяется \"\$false\""  # Опять неинициализированная переменная.
if [ "$false" ]
then
  echo "\"\$false\" -- это истина."
else
  echo "\"\$false\" -- это ложь."
fi # "$false" -- это ложь.
# Теперь мв получили ожидаемый результат.

echo

var1=20
var2=22
[ "$var1" -ne "$var2" ] && echo "$var1 не равно $var2"

echo

if [ -n $string1 ] # $string1 не была объявлена или инициализирована.
then
  echo "Строка \"string1\" не пустая."
else
  echo "Строка \"string1\" пустая."
fi

echo

if [ -n "$string1" ] # На этот раз, переменная $string1 заключена в кавычки.
then
  echo "Строка \"string1\" не пустая."
else
  echo "Строка \"string1\" пустая."
fi # Внутри квадратных скобок заключайте строки в кавычки!

echo

if [ $string1 ] # Опустим оператор -n.
then
  echo "Строка \"string1\" не пустая."
else
  echo "Строка \"string1\" пустая."
fi

echo

string1=initialized

if [ $string1 ] # Опять, попробуем строку без ничего.
then
  echo "Строка \"string1\" не пустая."
else
  echo "Строка \"string1\" пустая."
fi
    
string1="a = b"
	    
if [ $string1 ] # И снова, попробуем строку без ничего..
then
  echo "Строка \"string1\" не пустая."
else
  echo "Строка \"string1\" пустая."
fi

