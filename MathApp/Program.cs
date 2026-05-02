using System;
using System.Runtime.InteropServices;

namespace MathApp
{
    class Program
    {


        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Add(double a, double b);

        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Subtract(double a, double b);

        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Multiply(double a, double b);

        [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Divide(double a, double b);

        static void Main(string[] args)
        {
            Console.WriteLine("=== Калькулятор с использованием P/Invoke ===\n");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Сложение (+)");
                Console.WriteLine("2. Вычитание (-)");
                Console.WriteLine("3. Умножение (*)");
                Console.WriteLine("4. Деление (/)");
                Console.WriteLine("5. Выход");

                Console.Write("\nВаш выбор: ");
                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    exit = true;
                    Console.WriteLine("До свидания!");
                    continue;
                }

                // Проверка корректности выбора
                if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
                {
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    continue;
                }

                // Ввод чисел
                double num1, num2;

                Console.Write("Введите первое число: ");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.Write("Ошибка! Введите число: ");
                }

                Console.Write("Введите второе число: ");
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.Write("Ошибка! Введите число: ");
                }

                // Вычисление результата
                double result = 0;
                bool hasError = false;
                string operation = "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            result = Add(num1, num2);
                            operation = "+";
                            break;
                        case "2":
                            result = Subtract(num1, num2);
                            operation = "-";
                            break;
                        case "3":
                            result = Multiply(num1, num2);
                            operation = "*";
                            break;
                        case "4":
                            result = Divide(num1, num2);
                            operation = "/";
                            // Проверка на деление на ноль (NaN)
                            if (double.IsNaN(result))
                            {
                                Console.WriteLine("Ошибка: Деление на ноль!");
                                hasError = true;
                            }
                            break;
                    }

                    if (!hasError)
                    {
                        Console.WriteLine($"\nРезультат: {num1} {operation} {num2} = {result}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при вызове функции: {ex.Message}");
                }
            }
        }
    }
}