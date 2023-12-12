//Тестовое задание.
//В данной задаче будут рассматриваться 13-ти значные числа в тринадцатиричной системе исчисления(цифры 0,1,2,3,4,5,6,7,8,9, A, B, C) с ведущими нулями.
//Например, ABA98859978C0, 6789110551234, 0000007000000
//Назовем число красивым, если сумма его первых шести цифр равна сумме шести последних цифр.
//Пример:
//Число 0055237050A00 - красивое, так как 0+0+5+5+2+3 = 0+5+0+A+0+0
//Число 1234AB988BABA - некрасивое, так как 1+2+3+4+A+B != 8+8+B+A+B+A​
//Задача:
//написать программу на С# печатающую в стандартный вывод количество 13-ти значных красивых чисел с ведущими нулями в тринадцатиричной системе исчисления.
//количество должно быть представлено в десятичной системе исчисления
//Желательно не использовать BigInteger


using System;
using System.Linq;

namespace DevilDozenApp
{
    class Program
    {
        class DDint
        {
            public const int DD = 13, DigitMaxValue = DD - 1;
            //да, можно было разместить на стеке
            private int[] _value;

            public DDint(int lenght)
            {
                _value = new int[lenght];
            }

            public void Increment()
            {
                //идем справа налево - от младших разрядов к старшим
                for (int i = _value.Length - 1; i >= 0; i--)
                {
                    var currentValue = _value[i];

                    if (currentValue < DigitMaxValue)
                    {
                        currentValue++;
                        _value[i] = currentValue;
                        break;
                    }
                    //else if (i == 0)
                    //    throw new OverflowException($"{nameof(DDint)}.{nameof(Increment)}");

                    currentValue = 0;
                    _value[i] = currentValue;
                }
            }
            //да, можно оптимизированнее считать сумму
            public int Sum { get => _value.Sum(); }

            public override string ToString()
            {
                return $"{string.Join(string.Empty, _value.Select(i => i.ToString("X")))}";
            }
        }

        static void Main(string[] args)
        {
            //всего 13 разрядов. При этом нам интересны только 6 разрядов потому что они будут повторяться в левой и правой части числа
            const int digitCount = 6;

            long beautifulNumberCount = 0;
            //максимальное количество вариаций исходя из разряда числа
            long maxCount = (long)Math.Pow(DDint.DD, digitCount);
            //работает быстрее, чем словарь - я гарантирую это. Длина массива это максимально возможная сумма элементов
            int[] sumCountPairs = new int[((DDint.DigitMaxValue) * digitCount) + 1];

            DDint ddint = new DDint(digitCount);

            //можно хакнуть for на скорость, как это сделано внутри некоторых типов BCL. И вообще можно векторизации налить
            for (long i = 0; i < maxCount; i++)
            {
                //просто видеть корректность 13ричности
                //if (i > maxCount - 2)
                //    Console.WriteLine(ddint);

                //на всякий случай TODO: можно убрать
                checked
                {
                    ++sumCountPairs[ddint.Sum];
                }
                ddint.Increment();
            }

            //приводит sum к long чтобы не было переполнения при умножении
            //возводим количество сумм в степень количества "разрядов"
            foreach (long sum in sumCountPairs)
            {
                beautifulNumberCount += sum * sum;
            }
            //домножаем на оставшийся неиспользуемый разряд
            beautifulNumberCount *= DDint.DD;

            //TODO: возможно оптимизировать возводя в степень в 2 раза меньше раз - потому что количество сумм повторяется
            //var halfSumCountPairsCool = sumCountPairs.Distinct().ToArray();
            //var halfSumCountPairs = sumCountPairs.Take(sumCountPairs.Length / 2 + 1).ToArray();

            //Console.WriteLine(halfSumCountPairs.SequenceEqual(halfSumCountPairsCool));

            //Выведется: 9203637295151
            Console.WriteLine(beautifulNumberCount);
            Console.Read();
        }
    }
}