using System;

namespace Lab3
{
    class Calculator
    {
        public static string input, StringBeforeSign = "", StringAfterSign = "", sign;
        public static double number, number1, number2;
        public Calculator()
        {
            ReStart();
            static void ReStart()
            {
                int CounterOfSigns = 0;
                int counter = 0;
                StringBeforeSign = "";
                StringAfterSign = "";
                string StringVertical = "";
                sign = "";
                number = 0;
                Console.WriteLine("Введите пример для расчёта: ");
                Console.WriteLine("Если хотите ввести математическое выражение в вертикальном положении, впишите '1': ");
                char[] MassiveOfNeedElements = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '*', '.', ',' };
                char[] MassiveOfNeedElements2 = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',' };
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Введите первое число: ");
                    StringBeforeSign = Console.ReadLine();
                    Console.WriteLine("Введите знак математической операции: ");
                    sign = Console.ReadLine();
                    Console.WriteLine("Введите второе число: ");
                    StringAfterSign = Console.ReadLine();
                    foreach (char n in StringBeforeSign)
                    {
                        for (int i = 0; i < MassiveOfNeedElements2.Length; i++)
                        {
                            if (MassiveOfNeedElements2[i] == n)
                            {
                                if (n == '.' || n == ',')
                                {
                                    counter++;
                                    StringVertical = StringVertical + ",";
                                    continue;
                                }
                                else
                                {
                                    StringVertical = StringVertical + Convert.ToString(n);
                                }
                            }
                        }
                    }
                    if (counter > 1)
                    {
                        Console.WriteLine("Некорректный ввод данных");
                        ReStart();
                    }
                    counter = 0;
                    number1 = Convert.ToDouble(StringVertical);
                    StringVertical = "";
                    if (sign != "+" && sign != "-" && sign != "*")
                    {
                        Console.WriteLine("Некорректный ввод данных");
                        ReStart();
                    }
                    foreach (char n in StringAfterSign)
                    {
                        for (int i = 0; i < MassiveOfNeedElements2.Length; i++)
                        {
                            if (MassiveOfNeedElements2[i] == n)
                            {
                                if (n == '.' || n == ',')
                                {
                                    counter++;
                                    StringVertical = StringVertical + ",";
                                    continue;
                                }
                                else
                                {
                                    StringVertical = StringVertical + Convert.ToString(n);
                                }
                            }
                        }
                    }
                    if (counter > 1)
                    {
                        Console.WriteLine("Некорректный ввод данных");
                        ReStart();
                    }
                    number2 = Convert.ToDouble(StringVertical);
                    if (sign == "+")
                    {
                        ShowSumm();
                    }
                    else if (sign == "-")
                    {
                        ShowMinus();
                    }
                    else if (sign == "*")
                    {
                        ShowDobutok();
                    }
                    ReStart();
                }
                else
                {
                    foreach (char n in input)
                    {
                        if (n == '+' || n == '-' || n == '*')
                        {
                            CounterOfSigns++;
                            if (CounterOfSigns > 1)
                            {
                                Console.WriteLine("Некорректный ввод данных");
                                ReStart();
                            }
                        }
                    }
                    foreach (char n in input)
                    {
                        for (int i = 0; i < MassiveOfNeedElements.Length; i++)
                        {
                            if (n == MassiveOfNeedElements[i])
                            {
                                if (n == '.' || n == ',')
                                {
                                    if (number1 != 0)
                                    {
                                        counter++;
                                        StringAfterSign = StringAfterSign + ",";
                                    }
                                    else
                                    {
                                        counter++;
                                        StringBeforeSign = StringBeforeSign + ",";
                                    }
                                    continue;
                                }
                                if (n == '+' || n == '-' || n == '*')
                                {
                                    if (counter > 1)
                                    {
                                        Console.WriteLine("Некорректный ввод данных");
                                        counter = 0;
                                        ReStart();
                                    }
                                    else
                                    {
                                        counter = 0;
                                        number1 = Convert.ToDouble(StringBeforeSign);
                                        sign = Convert.ToString(n);
                                        continue;
                                    }
                                }
                                else
                                {
                                    StringBeforeSign = StringBeforeSign + Convert.ToString(n);
                                }
                                if (sign == "+" || sign == "-" || sign == "*")
                                {
                                    StringAfterSign = StringAfterSign + Convert.ToString(n);
                                }
                            }
                        }
                    }
                    if (counter > 1)
                    {
                        Console.WriteLine("Некорректный ввод данных");
                        ReStart();
                    }
                    number2 = Convert.ToDouble(StringAfterSign);
                    if (sign == "+")
                    {
                        ShowSumm();
                    }
                    else if (sign == "-")
                    {
                        ShowMinus();
                    }
                    else if (sign == "*")
                    {
                        ShowDobutok();
                    }
                    ReStart();
                }
            }
        }
        public static void ShowSumm()
        {
            number = number1 + number2;
            Console.WriteLine("Ответ: " + number);
        }
        public static void ShowMinus()
        {
            number = number1 - number2;
            Console.WriteLine("Ответ: " + number);
        }
        public static void ShowDobutok()
        {
            number = number1 * number2;
            Console.WriteLine("Ответ: " + number);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Console.InputEncoding = System.Text.Encoding.Unicode;
            Calculator calculate = new Calculator();
            Console.ReadLine();
        }
    }
}
