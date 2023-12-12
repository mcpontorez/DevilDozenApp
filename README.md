# Тестовое задание повышенной сложности
В данной задаче будут рассматриваться 13-ти значные числа в тринадцатиричной системе исчисления(цифры 0,1,2,3,4,5,6,7,8,9, A, B, C) с ведущими нулями.  
Например, ABA98859978C0, 6789110551234, 0000007000000

Назовем число красивым, если сумма его первых шести цифр равна сумме шести последних цифр.  
Пример:  
Число 0055237050A00 - красивое, так как 0+0+5+5+2+3 = 0+5+0+A+0+0  
Число 1234AB988BABA - некрасивое, так как 1+2+3+4+A+B != 8+8+B+A+B+A​

Задача:  
написать программу на С# печатающую в стандартный вывод количество 13-ти значных красивых чисел с ведущими нулями в тринадцатиричной системе исчисления.  
количество должно быть представлено в десятичной системе исчисления  
Желательно не использовать BigInteger

## Решение
[Не до конца причёсано и лежит тут](https://github.com/mcpontorez/DevilDozenApp/blob/master/DevilDozenApp/Program.cs)

## Получилось такое число: `9203637295151`
![image](https://github.com/mcpontorez/DevilDozenApp/assets/31940612/08c1192b-067e-4a07-bbe8-3630807c5d7a)

# Подвох задачи
При решении в лоб захочется сделать **13^13 итераций** в цикле for,  
а даже пустой проход цикла for при таком количестве итераций занимает **очень-очень много времени** на текущих мощностях компьютеров
доступных простым людям