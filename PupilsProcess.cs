using System;
using System.IO;

namespace Homework_5
{
    // Бушуева Валерия
    
    //На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
    //В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
    // <Фамилия> <Имя> <оценки>,
    // где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
    // <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
    //Пример входной строки: Иванов Петр 4 5 3

    public struct Pupils
    {
        public string firstName;
        public string secondName;
        public int[] scores;

        public double MyAverageScore
        {
            get
            {
                double result = 0;

                for (int i = 0; i < scores.Length; i++)
                {
                    result += scores[i];
                }

                result /= scores.Length;
                return result;
            }
        }
       
    }
    
    internal class PupilsProcess
    {
        private static void SortPupils(Pupils[] pupils)
        {
            for (int i = 0; i < pupils.Length; i++)
            {
                for (int j = 0; j < pupils.Length - 1; j++)
                {
                    if (pupils[j].MyAverageScore > pupils[j + 1].MyAverageScore)
                    {
                        Pupils tmp = pupils[j + 1];
                        pupils[j + 1] = pupils[j];
                        pupils[j] = tmp;
                    }
                }
            }
        }

        public static Pupils[] LoadPupilsFromFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            int number = int.Parse(streamReader.ReadLine());
            Pupils[] pupilsArray = new Pupils[number];
                
            for (int i = 0; i < number; i++)
            {
                string[] fileStrings = streamReader.ReadLine().Split(' ');
                Pupils pupil = pupilsArray[i];
                
                pupil.firstName = fileStrings[0];
                pupil.secondName = fileStrings[1];

                int scoreLength = fileStrings.Length - 2;
                    
                pupil.scores = new int[scoreLength];
                    
                for (int j = 2; j < fileStrings.Length; j++)
                {
                    if (int.TryParse(fileStrings[j], out int score))
                    {
                        pupil.scores[j - 2] = score;

                    }
                }

                pupilsArray[i] = pupil;
            }

            streamReader.Close();

            return pupilsArray;
        }

        public static void Execute()
        {
            int amountOfWorstPupils = 3;
            var pupilsArray = LoadPupilsFromFile("PupilsJournal.txt");

            SortPupils(pupilsArray);

            String result = String.Format("{0,-20} {1,-15} {2, -10}\n", "Фамилия", "Имя", "Средняя оценка");
            result += "---------------------------------------------------\n";

            Pupils previous = pupilsArray[0];
                
            for (int i = 0; i < amountOfWorstPupils; i++)
            {
                if (i > 0)
                {
                    if (previous.MyAverageScore == pupilsArray[i].MyAverageScore)
                        amountOfWorstPupils++;
                    previous = pupilsArray[i];
                }

                result += String.Format("{0,-20} {1,-15} {2,-10:F2}\n", pupilsArray[i].firstName,pupilsArray[i].secondName, pupilsArray[i].MyAverageScore);
            }
                
            Console.WriteLine("Программа вывода на экран учеников с тремя худшими средними баллами.");

            Console.WriteLine($"\n{result}");

            Console.ReadKey();
                
        }
    }
}