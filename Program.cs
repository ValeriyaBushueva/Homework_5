using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    // Бушуева Валерия

    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Task1();
            Task4();
        }
        
        public static void Task4()
        {
            PupilsProcess.Execute();
            Console.Clear();
        }

        public static void Task1()
            {
                int AmountOfTries = 3;

                do
                {
                    Console.Write("Введите логин: ");
                    string login = Console.ReadLine();

                    if (CorrectLogin.CheckLogin(login) && CorrectLogin.CheckLoginRegular(login))
                    {
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        AmountOfTries--;
                        Console.WriteLine("Неверный ввод логина. \nДолжны быть соблюдены следующие условия:"
                                          + "\nдлина строки 2 до 10 символов;"
                                          + "\nбуквы только латинского алфавита или цифры;"
                                          + "\nцифра не может быть первой."
                                          + Environment.NewLine + "У Вас осталось " + AmountOfTries +
                                          CorrectLogin.RightTryWord(AmountOfTries));
                    }

                } while (AmountOfTries > 0);

                Console.WriteLine("Логин корректен!");

                Console.ReadKey();
                Console.Clear();
            }
    }
}
