using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> marks = new Dictionary<string, int>()
            {
                {"Иванов",10 },
                {"Даненков", 9 },
                {"Ломейко", 7 }
            };

            foreach (KeyValuePair<string, int> mark in marks)
            {
                Console.WriteLine($"Name:{mark.Key}-Mark:{mark.Value}");
            }
            
            int f = 0;
            while (f != -1)
            {
                Console.WriteLine("--------------------Меню-----------------------");
                Console.WriteLine(@"Press operation:" + Environment.NewLine + 
                    "1. Добавить учащегося и его оценку" + Environment.NewLine +
                    "2. Удалить оценку" + Environment.NewLine +
                    "3. Изменить оценку" + Environment.NewLine + 
                    "4. Вывести учеников с оценкой 8 и выше" + Environment.NewLine + 
                    "5. Вывести учеников с оценкой 4 и ниже" + Environment.NewLine + 
                    "6. Вывести среднее арифметическое всех учащихся" + Environment.NewLine+
                    "7. Показать учащихся, с самой высокой оценкой" + Environment.NewLine + 
                    "8. Отобразить учеников и их оценки" + Environment.NewLine + 
                    "9. Закрыть приложение");
                string reader = Console.ReadLine();
                Menu klown = Enum.Parse<Menu>(reader); //perevod string v enum
                string[] names = Enum.GetNames(typeof(Menu));

                //foreach (KeyValuePair<string, int> mark in marks)
                //{
                //    Console.WriteLine($"Name:{mark.Key}-Mark:{mark.Value}");
                //}
                string addname;
                int addmark = 0;
                switch (klown)
                {
                    case Menu.Addmark:
                        {
                            Console.WriteLine("Введите фамилию учащегося");
                            addname = Console.ReadLine();
                            Console.WriteLine("Введите оценку");
                            addmark = int.Parse(Console.ReadLine());
                            if (marks.ContainsKey(addname))
                            {
                                Console.WriteLine($"Учащийся {addname} уже добавлен. Его(ее) оценка : {marks[$"{addname}"]}");
                            }
                            else 
                            {
                                marks.Add(addname,addmark);
                                Console.WriteLine($"Учащийся {addname} добавлен в библиотеку. Его(Ее) оценка :{marks[$"{addname}"]}");
                            }
                            break;
                        }
                    case Menu.Deletemark:
                        {
                            Console.WriteLine("Введите фамилию учащегося");
                            addname = Console.ReadLine();
                            if (marks.ContainsKey(addname))
                            {
                                marks.Remove($"{addname}");
                                Console.WriteLine($"Учащийся {addname} удален из реестра");
                            }
                            else
                            {
                                Console.WriteLine($"Учащийся {addname} не найден. Добавьте его в пункте 1. или попробуйте еще раз.");
                            }
                            break;
                        }
                    case Menu.Beststudents:
                        {
                            int maxmark = 0;
                            foreach (int tempmark in marks.Values)
                            {
                                if (tempmark > maxmark)
                                {
                                    maxmark = tempmark;
                                }
                            }
                            foreach (KeyValuePair<string, int> ravnie in marks)
                            {
                                if (ravnie.Value == maxmark)
                                {
                                    Console.WriteLine($"Студент с наивысшим баллом {maxmark}: {ravnie.Key}");
                                }
                            }
                            break;
                        }
                    case Menu.Students8ormore:
                        {
                            foreach (KeyValuePair<string, int> ravnie in marks)
                            {
                                if (ravnie.Value >= 8)
                                {
                                    Console.WriteLine($"студент с баллом 8 и выше: {ravnie.Key}");
                                }
                                //else if (ravnie.Value < 8)
                                //{
                                //    Console.WriteLine("Учащихся с такой оценкой не найдено.");
                                //}
                            }
                            break;
                        }
                    case Menu.Students4orless:
                        {
                            foreach (KeyValuePair<string, int> ravnie in marks)
                            {
                                if (ravnie.Value <= 4)
                                {
                                    Console.WriteLine($"студент с баллом 4 и ниже : {ravnie.Key}");
                                }
                                //else
                                //{
                                //    Console.WriteLine("Учащихся с такой оценкой не найдено.");
                                //}
                            }
                            break;
                        }
                    case Menu.Arithmeticmean:
                        {
                            double summ = 0;
                            foreach (int temp in marks.Values)
                            {
                                summ += temp;
                            }
                           // Console.WriteLine(summ);

                            double artm = summ / marks.Count;
                        
                            Console.WriteLine($"Среднее арифметическое всех оценок в классе = {artm}");
                            break;
                        }
                    case Menu.Changemark:
                        {
                            Console.WriteLine("Введите фамилию учащегося");
                            addname = Console.ReadLine();
                            Console.WriteLine("Введите его оценку");
                            addmark = int.Parse(Console.ReadLine());
                            if (marks.ContainsKey(addname))
                            {
                                marks[addname] = addmark;
                                Console.WriteLine($"Вы заменили оценку учащегося с фамилией {addname} на {addmark}");
                            }
                            else
                            {
                                Console.WriteLine($"Учащийся {addname} Не найден. Добавьте его в пункте 1. или попробуйте еще раз");
                            }
                            break;
                        }
                    case Menu.Showall:
                        {
                            foreach (KeyValuePair<string, int> mark in marks)
                                {
                                    Console.WriteLine($"Фамилия:{mark.Key}-Оценка:{mark.Value}");
                                }
                                break;
                        }
                    case Menu.Exitprogramm:
                        {
                            f = -1;
                            Console.WriteLine("Вы закрыли приложение");
                            break;
                        }
                   default:
                        Console.WriteLine("Введите корректное значение меню");
                        break;
                }
            }

        }
    }
}
