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
            //Функция проверки баланса скобок
            static bool CheckBrackets(string text)
            {
                if (text == null)
                {
                    throw new ArgumentNullException("text", "Входной текст не может быть null.");
                }

                string openBrackets = "";

                foreach (char c in text)
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        openBrackets += c;
                    }
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        if (openBrackets.Length == 0) return false;
                        char lastOpen = openBrackets[openBrackets.Length - 1];

                        if ((c == ')' && lastOpen == '(') ||
                            (c == ']' && lastOpen == '[') ||
                            (c == '}' && lastOpen == '{'))
                        {
                            openBrackets = openBrackets.Substring(0, openBrackets.Length - 1);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return openBrackets.Length == 0;
            }

            static void Main(string[] args)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Title = "Практическая работа 12";

                Console.WriteLine("Здравствуй!");

                bool continueProgram = true;

                try
                {
                    while (continueProgram)
                    {
                        try
                        {
                            Console.Write("Введите пожалуйста текст: ");
                            string str = Console.ReadLine();

                            if (str != null && str.Length > 500)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Ошибка: Слишком длинный текст! Максимум 500 символов.");
                                Console.ForegroundColor = ConsoleColor.White;
                                continue;
                            }

                            if (String.IsNullOrEmpty(str) || str.Trim().Length == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Строка пуста или состоит из пробелов. Попробуйте снова.");
                                Console.ForegroundColor = ConsoleColor.White;
                                continue;
                            }

                            if (str.Contains("(") || str.Contains(")") || str.Contains("[") || str.Contains("]") || str.Contains("{") || str.Contains("}"))
                            {
                                bool isBalanced = CheckBrackets(str);

                                if (isBalanced)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Результат: Скобки расставлены верно (баланс соблюден).");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Результат: Ошибка! Скобки расставлены неверно (нарушен баланс).");
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("В тексте нет скобок. Проверять нечего.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
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

                            if (answer == null) answer = "";

                            if (answer.ToLower() == "да")
                            {
                                answerA = true;
                                Console.Clear();
                            }
                            else if (answer.ToLower() == "нет")
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
                }
                catch (Exception globalEx)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[КРИТИЧЕСКАЯ ОШИБКА] Программа столкнулась с непреодолимым сбоем: " + globalEx.Message);
                    Console.WriteLine("Работа будет аварийно завершена.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\nНажмите любую клавишу для выхода...");
                Console.ReadKey();
            }
    }
}
