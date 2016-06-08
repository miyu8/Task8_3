using System;
using System.Linq;
using Life.Initialization;
using Life.BaseData;
using Life;
using Life.Gaming;
using Life.GameConsole;
using System.Threading;

namespace Life_Console
{
    public class Menu
    {
        bool exit;
        int choise = 0;
        int choise2 = 0;
        int choise3 = 0;
        public bool[] boolMenu = new bool[2];
        public string[] menu = new string[2];
        public string[] menu2 = new string[4];
        public string[] menu3;
        ConsoleKeyInfo answer;
        DataModelContainer db;
        string join;
        RecordBase recordBase = new RecordBase();
        Options options;
        JSON jSON = new JSON();
        public GameBase igame;
        public GameBaseConsole gameBaseConsole;
        public ServerInit serverInit;

        public void Run()
        {
            Console.CursorVisible = false;
            menu[0] = "Новая игра";
            menu[1] = "Загрузить существующую игру";
            menu2[0] = "Стандартная";
            menu2[1] = "Альтернативная";
            menu2[2] = "Смешанная";
            menu2[3] = "С травоядными животными";
            boolMenu[0] = true;
            options = jSON.GetJson();
            serverInit = new ServerInit(options);
            MainMenu();
        }

        private void ColorMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Главное меню\nИспользуйте стрелки для выбора опции. Esc для возврата и выхода");
            Console.ForegroundColor = ConsoleColor.White;
            if (choise == 0)
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(menu[0]);
            Console.ResetColor();
            if (boolMenu[1])
                Console.ForegroundColor = ConsoleColor.White;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            if (choise == 1)
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(menu[1]);
            Console.ResetColor();
        }

        private void NewGame()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите тип игры");
                for (int i = 0; i < menu2.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (i == choise2)
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(menu2[i]);
                    Console.ResetColor();
                }
                answer = Console.ReadKey(true);
                if (answer.Key == ConsoleKey.Escape)
                {
                    exit = true;
                    break;
                }
                else if (answer.Key == ConsoleKey.Enter)
                {
                    Move(choise2 + 1);
                    serverInit.RunNew(igame);
                    Begin();
                }
                else if (answer.Key == ConsoleKey.UpArrow)
                    choise2--;
                else if (answer.Key == ConsoleKey.DownArrow)
                    choise2++;
                if (choise2 < 0)
                    choise2 = menu2.Length - 1;
                else if (choise2 == menu2.Length)
                    choise2 = 0;
            }
        }

        private void OldGame()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите сохранённую игру. Для удаления игры нажмите Delete");
                Console.WriteLine(string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", "Идентификатор", "Тип игры", "Итерация", "Количество строк", "Количество столбцов"));
                int i = 0;
                try
                {
                    using (db = new DataModelContainer())
                    {
                        int count = db.GameSet.Count();
                        if (count == 0) break;
                        menu3 = new string[count];
                        foreach (var item in db.GameSet)
                        {
                            menu3[i] = string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", item.Id, item.Type, item.Iteration, item.SizeX, item.SizeY);
                            i++;
                        }
                        join = string.Join("\n", menu3);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(join);
                        Console.SetCursorPosition(0, choise3 + 2);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(menu3[choise3]);
                        Console.ResetColor();
                        answer = Console.ReadKey(true);
                        if (answer.Key == ConsoleKey.Escape)
                        {
                            exit = true;
                            break;
                        }
                        else if (answer.Key == ConsoleKey.Enter)
                        {
                            options.gameProperty.SizeX = db.GameSet.ToList().ElementAt(choise3).SizeX;
                            options.gameProperty.SizeY = db.GameSet.ToList().ElementAt(choise3).SizeY;
                            Move(db.GameSet.ToList().ElementAt(choise3).Type);
                            serverInit.RunSave(db.GameSet.ToList().ElementAt(choise3).Id, db.GameSet.ToList().ElementAt(choise3).Iteration, igame);
                            Begin();
                        }
                        else if (answer.Key == ConsoleKey.Delete)
                        {
                            serverInit.Remove(db.GameSet.ToList().ElementAt(choise3).Id);
                        }
                        else if (answer.Key == ConsoleKey.UpArrow)
                        {
                            choise3--;
                        }
                        else if (answer.Key == ConsoleKey.DownArrow)
                        {
                            choise3++;
                        }
                        if (choise3 < 0)
                            choise3 = menu3.Length - 1;
                        else if (choise3 == menu3.Length)
                            choise3 = 0;
                    }
                }
                catch (Exception ex)
                {
                    recordBase.ErrorBase(ex);
                }
            }
        }

        private void MainMenu()
        {
            while (true)
            {
                serverInit.IsData(boolMenu);
                ColorMenu();
                answer = Console.ReadKey(true);
                if (answer.Key == ConsoleKey.Escape)
                    break;
                else if (answer.Key == ConsoleKey.Enter)
                {
                    switch (choise)
                    {
                        case 0:
                            NewGame();
                            break;
                        case 1:
                            OldGame();
                            break;
                    }
                    if (exit)
                    {
                        continue;
                    }
                    exit = false;
                }
                else if (answer.Key == ConsoleKey.UpArrow)
                    choise--;
                else if (answer.Key == ConsoleKey.DownArrow)
                    choise++;
                if (choise < 0)
                    choise = menu.Length - 1;
                else if (choise == menu.Length)
                    choise = 0;
            }
        }

        public void Move(int type)
        {
            Console.Clear();
            switch (type)
            {
                case 1:
                    igame = serverInit.Game1New();
                    gameBaseConsole = new Game1Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
                    break;
                case 2:
                    igame = serverInit.Game2New();
                    gameBaseConsole = new Game2Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
                    break;
                case 3:
                    igame = serverInit.Game3New();
                    gameBaseConsole = new Game3Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
                    break;
                case 4:
                    igame = serverInit.Game4New();
                    gameBaseConsole = new Game4Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
                    break;
            }
        }

        public void Begin()
        {
            gameBaseConsole.DrawConsole(igame.gameField, igame.iteration, igame.ValueCells);
            Thread.Sleep(500);
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                serverInit.End(igame);
                return;
            }
            while (serverInit.Step(igame))
            {
                gameBaseConsole.ClearNumbers();
                gameBaseConsole.DrawConsole(igame.gameField, igame.iteration, igame.ValueCells);
                Thread.Sleep(500);
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    serverInit.End(igame);
                    return;
                }
            }
        }
    }
}
