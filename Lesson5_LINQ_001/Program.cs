using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5_LINQ_001
{
    /*
        ТЕМА: LINQ

        Задания:

       +1."sum01": Дано масив строк.Знайти суму довжин всіх строк виключно за допомогою LINQ запиту

       +2."sum02": Є масив чисел int від 10 до 100 розміром N.Знайти суму чисел останніх цифр кожного числа. 
          Наприклад, масив { 13, 98, 24, 43}. Результат = 3 + 8 + 4 + 3 = 18

       +3."group02": Є масив чисел int. Серед усіх елементів послідовності, що закінчуються однією і тією ж цифрою, вибрати максимальний.
          Отриману послідовність максимальних елементів упорядкувати по зростанню їх останніх цифр

       +4."group03": Є список абітурієнтів.Кожен елемент списку включає наступні поля:
            <Прізвище> <Номер школи> <Рік вступу>
           Для кожної школи знайти усі роки вступу абітурієнтів і вивести номер школи і знайдені для неї роки 
           (роки розташовуються на тій же рядку, що і номер школи, і упорядковуються за зростанням).
           Відомості по кожній школі виводити на новій строці
    */
    class Program
    {
        const bool PrintItemAtNewLine = true;

        static void Main(string[] args)
        {

            // Задания - список
            List<string> examples = new List<string>
                         { "sum01", "sum02", "group02",  "group03" };

            // Выполняем все задания поочередно:
            foreach (string example in examples)
            {
                #region Реализация заданий

                // колекция строк
                List<string> names = new List<string>
                    {
                        "Brian Adams",
                        "Robert de Niro",
                        "Julia Roberts",
                        "Adam Lambert",
                        "Natalia Mogilevska"
                    };

                //---------------------------------------------------------------------

                if (example == "where01")
                {
                   PrintExampleTittle("Отбор с применением фразы where01 - найти запись по имени:");

                    // Выражение запроса.
                    var query =                                 // query - переменная запрса.
                            from nm in names                // from - объявляет переменную диапазона employee.
                            where nm == "Adam Lambert"      // where - фильтр
                            orderby nm                      // orderby - сортировка 
                            select nm
                                ;

                    Console.WriteLine("Результат:");

                    foreach (var item in query)
                    {
                        Console.WriteLine("{0}", item);
                    }

                    // Задержка.
                    PressAnyKey();
                }

                //---------------------------------------------------------------------

                if (example == "where02")
                {
                    PrintExampleTittle("Отбор с применением метода расширения where- Длина > 20:");

                    // Выражение запроса.
                    var query = names.Where(n => n.Length > 20);

                    Console.WriteLine("Результат:");

                    foreach (var item in query)
                    {
                        Console.WriteLine("{0}", item);
                    }

                    // Задержка.
                    PressAnyKey();
                }
                //---------------------------------------------------------------------

                // 1.Дано масив строк.Знайти суму довжин всіх строк виключно за допомогою LINQ запиту
                if (example == "sum01")
                {
                    PrintExampleTittle("Агрегация sum - сумма длин наименовний:");
                    
                    // Вывод исходной коллекции
                    PrintCollection(names, PrintItemAtNewLine);

                    // Выражение запроса.
                    var query = names.Sum((n) => { return n.Length; });

                    // Вывод результата
                    Console.WriteLine();
                    Console.WriteLine("Результат:");
                    Console.WriteLine("Sum = {0}", query);

                    // Задержка.
                    PressAnyKey();
                }

                //---------------------------------------------------------------------

                //  2.Є масив чисел int від 10 до 100 розміром N.Знайти суму чисел останніх цифр кожного числа. 
                //    Наприклад, масив { 13, 98, 24, 43}. Результат = 3 + 8 + 4 + 3 = 18
                if (example == "sum02")
                {
                    PrintExampleTittle("Агрегация sum- сума последних цифр каждого числа в списке:");

                    List<int> clInts = new List<int>
                          {52, 45,88,780,950,242 };

                    // Вывод исходной коллекции
                    PrintCollection(clInts);

                    // Выражение запроса.
                    // последняя цифра- это остаток от деления на 10
                    var sum = clInts.Sum((i) => { return i % 10; });

                    Console.WriteLine("Результат:");
                    Console.WriteLine("Sum = {0}", sum);

                    // Задержка.
                    PressAnyKey();
                }
                //---------------------------------------------------------------------

                //Grouping
                if (example == "group01")
                {
                    List<Phone> phones = new List<Phone>
                {
                    new Phone {Name="Lumia 430", Company="Microsoft" },
                    new Phone {Name="Mi 5", Company="Xiaomi" },
                    new Phone {Name="LG G 3", Company="LG" },
                    new Phone {Name="iPhone 11", Company="Apple" },
                    new Phone {Name="Lumia 930", Company="Microsoft" },
                    new Phone {Name="iPhone 6", Company="Apple" },
                    new Phone {Name="Lumia 630", Company="Microsoft" },
                    new Phone {Name="LG G 4", Company="LG" }
                };

                    var phoneGroups = from phone in phones
                                      group phone by phone.Company;

                    foreach (IGrouping<string, Phone> g in phoneGroups)
                    {
                        PrintExampleTittle(g.Key);
                        foreach (var t in g)
                            Console.WriteLine(t.Name);
                        Console.WriteLine();
                    }
                }
                //---------------------------------------------------------------------

                // 3.Є масив чисел int. 
                //   Серед усіх елементів послідовності, що закінчуються однією і тією ж цифрою, вибрати максимальний.
                //   Отриману послідовність максимальних елементів упорядкувати по зростанню їх останніх цифр
                if (example == "group02")
                {
                    PrintExampleTittle("Группировка по последней цифре + max из элементов в группе:");

                    List<int> clInts = new List<int>
                          {52, 45,88,780,950,242, 567,57,3456,680,782,4455,4826, 264,105 };

                    // Вывод исходной коллекции
                    PrintCollection(clInts);

                    var Groups = from i in clInts
                                 let Dgt = (i % 10)
                                 orderby Dgt, i descending
                                 group i by Dgt
                                 ;

                    Console.Write("\n\rИсходные данные (сгруппированные):");
                    foreach (IGrouping<int, int> grp in Groups)
                    {
                        // выводим группу
                        Console.Write("\n\rГруппа {0} :", grp.Key);

                        //выводим элементы группы
                        foreach (var i in grp)
                            Console.Write($"{i} ");
                    }
                    Console.WriteLine();

                    //-------------------

                    //Мах в группе
                    var dgtGroups = from i in clInts
                                    let Dgt = (i % 10)
                                    orderby (Dgt)
                                    group i by (Dgt) into grp
                                    select new
                                    {
                                        groupNm = grp.Key,
                                        maxElm = grp.Max()
                                    }
                                    ;

                    Console.WriteLine("\n\rРезультат- Мах в группе:");
                    foreach (var g in dgtGroups)
                    {
                        Console.WriteLine("Группа {0}: {1} ", g.groupNm, g.maxElm);
                    }

                    // Задержка.
                    PressAnyKey();
                }
                //---------------------------------------------------------------------

                //4. Є список абітурієнтів.Кожен елемент списку включає наступні поля:
                //    <Прізвище> <Номер школи> <Рік вступу>
                //    Для кожної школи знайти усі роки вступу абітурієнтів і вивести номер школи і знайдені для неї роки
                //    (роки розташовуються на тій же рядку, що і номер школи, і упорядковуються за зростанням).
                //    Відомості по кожній школі виводити на новій строці
                if (example == "group03")
                {
                    PrintExampleTittle("Группировка- школа, сортировка- ГодПоступления:");

                    List<Abiturient> Abits = new List<Abiturient>()
                        {
                            new Abiturient { Name = "Сенчина", SchoolNo = 33, AdmissionYear= 2018},
                            new Abiturient { Name = "Петров ", SchoolNo = 33, AdmissionYear= 2020},
                            new Abiturient { Name = "Васечкин", SchoolNo = 33, AdmissionYear= 2018},
                            new Abiturient { Name = "Солнцев", SchoolNo = 33, AdmissionYear= 2017},
                            new Abiturient { Name = "Иванов", SchoolNo = 80, AdmissionYear= 2015},
                            new Abiturient { Name = "Сидоров", SchoolNo = 80, AdmissionYear= 2016}
                        };

                    // Вывод исходной коллекции
                    PrintCollection(Abits, PrintItemAtNewLine);

                    var Groups = from a in Abits
                                 orderby a.SchoolNo
                                 group a by a.SchoolNo into g
                                 select new
                                 {
                                     SchoolNo = g.Key,
                                     AdmYears = from y in g
                                                orderby y.AdmissionYear
                                                select y.AdmissionYear
                                 };

                    Console.WriteLine("\n\rРезультат: школа + годы_Поступлений:");
                    foreach (var group in Groups)
                    {
                        Console.Write($"школа {group.SchoolNo} : ");
                        foreach (var y in group.AdmYears.Distinct())
                            Console.Write("{0} ", y);

                        Console.WriteLine();
                    }

                    // Задержка.
                    PressAnyKey();
                }
                #endregion

            }
        }

        
        #region Методы вывод на консоль

        // Задержка.
        private static void PrintExampleTittle(string Tittle)
        {
            ConsoleColor ForegroundColor_Old = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(Tittle);

            Console.ForegroundColor = ForegroundColor_Old;
        }

        // Вывод заданной коллекции на консоль
        private static void PrintCollection<T>(IEnumerable<T> collection, bool atNewLine = false)
        {
            
            ConsoleColor ForegroundColor_Old = Console.ForegroundColor;
           
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\nИсходная коллекция:");


           foreach (var item in collection)
            {
                Console.Write($"{item} ",item);
                if (atNewLine)   
                   { Console.WriteLine(); }
            }
            
            Console.WriteLine();
            Console.ForegroundColor = ForegroundColor_Old;
       }

        // Задержка.
        private static void PressAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press anyKey...");
            Console.ReadKey();
            Console.WriteLine();
        }
        #endregion

        #region additional classes
        class Phone
        {
            public string Name { get; set; }
            public string Company { get; set; }
        }

        class Abiturient
        {
            public string Name { get; set; }
            public int SchoolNo { get; set; }
            public int AdmissionYear { get; set; }

            public override string ToString()
            {
                return this.Name + " " + " " + this.SchoolNo + " " + this.AdmissionYear;
            }
        }

        #endregion

    }
}
