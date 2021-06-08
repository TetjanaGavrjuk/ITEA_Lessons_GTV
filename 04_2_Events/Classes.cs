using System;

namespace Events04
{
    public enum WhereColor
    {
        Foreground,
        Background
    }


    public class CommandArgs : EventArgs
    {
        public ConsoleColor Color;
        public WhereColor WhereColor;

        public int Width;
        public int Height;

        public string Title;
        //-----------------------------------------

        #region constructors
        public CommandArgs() { }

        public CommandArgs(ConsoleColor color, WhereColor whereColor)
        {
            Color = color;
            WhereColor = whereColor;
        }

        public CommandArgs(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public CommandArgs(string title)
        {
            Title = title;
        }
        #endregion
    }

    // Комманда пользователя ( с параметрами )
    public class Command
    {
        // Событие "Команда - готова(сформирована) !"
        // Обработчик - стандартный, должен соответствать сигнатуре  EventHandler
        public event EventHandler<CommandArgs> CommandPrepared;

        public char CommandAbrv;   // Абревиатура команды
        public CommandArgs Args;   // аргументы для комманды
        //-----------------------------------------

        #region Constructors
        public Command()
        {
        }

        public Command(char commandAbrv, CommandArgs args)
        {
            CommandAbrv = commandAbrv;
            Args = args;
       }

        public Command(char commandAbrv, ConsoleColor color, WhereColor whereColor)
        {
            CommandAbrv = commandAbrv;
            Args = new CommandArgs(color, whereColor);
        }
        #endregion

        public void Clear()
        {
            CommandAbrv = default(char);
            Args = null;

        }

        #region Inputting
        // Ввод абревиатуры команды
        public void InputCommandAbrv()
        {
            Console.Write("\n\nWrite a command: ");
            ConsoleKeyInfo key = Console.ReadKey();
            CommandAbrv = key.KeyChar;
        }

        // После ввода аргументов комманды считаем, что команда -готова и 
        // генерим событие  CommandPrepared
        public void InputCommandArgs()
        {
            switch (CommandAbrv)
            {
                case 'C':
                    {
                        ConsoleColor color = InputColor();
                        Args = new CommandArgs(color, WhereColor.Foreground);
                        break;
                    }
                case 'B':
                    {
                        ConsoleColor color = InputColor();
                        Args = new CommandArgs(color, WhereColor.Background);
                        break;
                    }
                case 'S':
                    {   Args = InputSize();
                        break;
                    }
                case 'T': 
                    {
                        Args = InputTitle();
                        break;
                    }
                default:
                    {
                        Console.Write("\n");
                        Args = null;
                        break;
                    }
            }

            // raise event
            CommandPrepared?.Invoke(this, Args);
        }

        private static CommandArgs InputTitle()
        {
            Console.Write("\nWrite a title: ");
            string title = Console.ReadLine();
            return new CommandArgs(title);
        }

        private static CommandArgs InputSize()
        {
            try
            {
                Console.Write("\nSet Width: ");
                int Width = int.Parse(Console.ReadLine()) / 8;

                Console.Write("\nSet hight: ");
                int Height = int.Parse(Console.ReadLine()) / 8;

                return new CommandArgs(Width, Height);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unknown format!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("To large param!");
            }
            return null;
        }

        private static ConsoleColor InputColor()
        {
            bool isDone = false;
            ConsoleColor color = ConsoleColor.White;

            while (!isDone)
            {
                isDone = true;

                Console.Write("\nWrite a color: ");
                string colorName = Console.ReadLine();

                switch (colorName)
                {
                    case "Black":
                        {
                            color = ConsoleColor.Black;
                            break;
                        }
                    case "Yellow":
                        {
                            color = ConsoleColor.Yellow;
                            break;
                        }
                    case "Green":
                        {
                            color = ConsoleColor.Green;
                            break;
                        }
                    case "Red":
                        {
                            color = ConsoleColor.Red;
                            break;
                        }
                    case "Blue":
                        {
                            color = ConsoleColor.Blue;
                            break;
                        }
                    case "Gray":
                        {
                            color = ConsoleColor.Gray;
                            break;
                        }
                    case "White":
                        {
                            color = ConsoleColor.White;
                            break;
                        }
                    case "Exit":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Try smth another :(");
                            isDone = false;
                            break;
                        }
                }

            }
            return color;
        }
        #endregion
    }


    // Конфигуратор пользовательского интерфейса
    public  class UIConfigurator
    {
        // Событие "Конфигурация консоли - завершена!"
        public event Action<Command> ConfigСompleted;

        private Command Command;
        //-----------------------------------------
        
        #region public
        public UIConfigurator()
        {
            ConfigСompleted += OnConfigСompleted;
        }

        // параметр args- избыточен. Введен с целью соответствовать сигнатуре стандартного обработчика событий
        public void SetConsoleConfiguration(object command, CommandArgs args)
        {
            try
            {
                this.Command = command as Command;
                SetConsoleConfiguration();
            }
            catch (Exception ex)
            {
                PrintError($"Ошибка: {ex.Message}");
                return;
            }

            // raise event
            ConfigСompleted?.Invoke(Command);
        }
        #endregion
        

        #region exec
        private void SetConsoleConfiguration()
        {
            switch (Command.CommandAbrv)
            {
                case 'C':
                    {
                    SetConsoleColor(Command.Args); 
                    break;
                    }
                case 'B':
                    {
                    SetConsoleColor(Command.Args);
                    break;
                    }
                case 'S':
                    {
                    SetConsoleSize(Command.Args);
                    break; 
                    }
                case 'T':
                    {
                    SetConsoleTittle(Command.Args);
                    break; 
                    }
                case 'R':
                    {
                    ResetConsole(Command.Args);
                    break; 
                    }
                case 'E':
                    {
                    GoodBye(Command.Args);
                    break; 
                    }
                default:
                    {
                    throw new Exception("Command not found!");
                    }
            }
        }

        private  void ResetConsole(CommandArgs args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            
            // TODO еще размер нужно будет восстановить.
        }

        private  void SetConsoleColor(CommandArgs args)
        {
            if (args.WhereColor == WhereColor.Foreground)
                Console.ForegroundColor = args.Color;
            else
                Console.BackgroundColor = args.Color;
        }

        private  void SetConsoleTittle(CommandArgs args)
        {
            Console.Title = args.Title;
        }

        private  void SetConsoleSize(CommandArgs args)
        {
            Console.WindowWidth = args.Width;
            Console.WindowHeight = args.Height;
        }

        private  void GoodBye(CommandArgs args)
        {
            Console.Beep();
        }
        #endregion


        private void OnConfigСompleted(Command command) 
        {
            if (command.CommandAbrv == default(char) || command.CommandAbrv == 'E')
                return;

            Console.WriteLine("Console configuration has completed!");
        }

        private  void PrintError(string ErrorMsg)
        {
            Console.WriteLine($"\n{ErrorMsg}");
        }
    }
}
