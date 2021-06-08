using System;

namespace Events04
{
    // Настройка консоли
    class Program
    {

        static void Main()
        {
            PrintCommandsDescrs(); 

            // конфигуратор UI
            UIConfigurator UIConfigurator = new UIConfigurator();
            UIConfigurator.ConfigСompleted += PrintEndOfConfiguration;

            // Комманда пользователя
            // Сформированную комманду - обработает конфигуратор с помощью обработчика события CommandPrepared
            Command UserCommand = new Command();
            UserCommand.CommandPrepared += UIConfigurator.SetConsoleConfiguration;
            UserCommand.CommandPrepared += PrintEndOfCommand;

            do
            {
                UserCommand.Clear();
                UserCommand.InputCommandAbrv(); //ввод абревиатуры комманды
                UserCommand.InputCommandArgs(); //По окончании ввода аргументов для комманды инициируется 
                                                //установка конфигурации консоли по event-у CommandPrepared
            }
            while (UserCommand.CommandAbrv != 'E'); // 'E'=Exit
        }


        static void PrintCommandsDescrs()
        {
            SetColor(ConsoleColor.Green);
            Console.WriteLine("***************************\n\nConsole tune program"
                + "\n___________________________\n");

            SetColor(ConsoleColor.Yellow);
            Console.WriteLine("Commands: \n");
            PrintCommandDescr("C", "Change font color");
            PrintCommandDescr("B", "Change background dolor");
            PrintCommandDescr("S", "Change console size");
            PrintCommandDescr("T", "Change window header");
            PrintCommandDescr("R", "Reset changes");
            PrintCommandDescr("E", "Exit");
            Console.WriteLine();
        }

        static void PrintCommandDescr(string abrev, string descr)
        {
            SetColor(ConsoleColor.Red);
            Console.Write(abrev);

            SetColor(ConsoleColor.White);
            Console.Write(" - " + descr + "\n");
        }

        public static void PrintEndOfCommand(object s, CommandArgs arg)
        {
            Console.WriteLine("!!!!!!!!!! EndOfCommand !!!!!!!!!!!!!");
        }

        public static void PrintEndOfConfiguration(Command command)
        {
            //Console.WriteLine("?????????????????????????????????");
            // Какие то глобальные действия
        }

        static void SetColor(ConsoleColor color, WhereColor whereColor = WhereColor.Foreground)
        {
            if (whereColor == WhereColor.Foreground)
                Console.ForegroundColor = color;
            else
                Console.BackgroundColor = color;
        }
   }

}
