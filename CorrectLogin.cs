using System;
using System.Text.RegularExpressions;

namespace Homework_5
{
    // Бушуева Валерия
    class CorrectLogin
    {
        // Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        //а) без использования регулярных выражений;
        //б) с использованием регулярных выражений.

        
        // Метод отображения слова "попытка" в правильной форме
        public static string RightTryWord(int x)
        {
            string strting = "";
            // Попытка, когда заканчивается на один, кроме 11.
            if (x % 10 == 1 && x != 11) strting += " попытка";
            else
                // Попытки
            if ((x >= 2 && x <= 4) || (x >= 22 && x <= 24) || (x >= 32 && x <= 34) || (x > 41 && x < 45))
                strting += " попытки";
            else
                // Попыток
            if ((x == 11) || (x >= 5 && x <= 20) || (x >= 25 && x <= 30) || (x >= 35 && x < 41) ||
                (x > 44 && x < 51)) strting += " попыток";
            return strting;
        }

        //Метод проверки на соответствие логина требованиям
        public static bool CheckLogin(string login)
        {
            int length = login.Length;
            if (length >= 2 && length <= 10)
            {
                bool check = true;
                char letter = login[0];
                if (Char.IsDigit(letter))
                    return false;
                for (int i = 1; i < length; i++)
                {
                    letter = login[i];
                    if (!(Char.IsDigit(letter) || IsLatinLetter(letter)))
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                    return true;
            }

            return false;
        }

        //Метод проверки на соответствие логина требованиям через регулярные выражения
        public static bool CheckLoginRegular(string login)
        {
            char letter = login[0];
            if (Char.IsDigit(letter))
                return false;
            if (!Regex.IsMatch(login, @"^[a-zA-Z0-9]+${2,10}"))
                return false;
            return true;
        }

        //Метод проверяет, что символ - латинская буква
        public static bool IsLatinLetter(char letter)
        {
            int num = letter;
            if ((num >= 65 && num <= 90) || (num >= 97 && num <= 122))
                return true;
            else
                return false;
        }
    }
}