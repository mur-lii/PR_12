//************************************************
//* Практичсекая работа № 12                     *
//* Выполнила: Трухина Е.Д., группа 2ИСП         *
//* Задание: организация и использование функций *
//************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_12
{
    internal class Program
    {
        static void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Произошла непредвиденная ошибка: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static int Bracket(int n)
        {

            return n;
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа 12";

            Console.WriteLine("Здравствуй!");

            bool continueProgram = true;

            while (continueProgram)
            {
                try
                {
                    Console.Write("Введите пожалуйста текст: ");
                    string str = Console.ReadLine();

                    if (String.IsNullOrEmpty(str))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Строка пуста. Попробуйте снова.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    string str1 = str.Replace(" ", "");
                    if (str1.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Строка состоит только из пробелов! Введите что-то осмысленное.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    else Console.WriteLine(str);
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }

                bool answerA = false;

                while (!answerA)
                {
                    Console.Write("\nПродолжить выполнение программы? (да/нет): ");
                    string answer = Console.ReadLine();

                    if (answer == null)
                    {
                        answer = "";
                    }
                    if (answer == "да")
                    {
                        answerA = true;
                        Console.Clear();
                    }
                    else if (answer == "нет")
                    {
                        answerA = true;
                        continueProgram = false;
                        Console.WriteLine("Выход из программы. До свидания!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: введите \"да\" или \"нет\".");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
