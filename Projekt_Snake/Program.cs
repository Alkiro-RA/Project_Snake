using System;
using System.Collections.Generic;

namespace Projekt_Snake
{
    class Program
    {
        private static string _path = @".\games.xml";
        private bool _run;
        private List<Game> _topGames;
        Program()
        {
            TopGames = new List<Game>();
            Run = true;
            Console.CursorVisible = false;
        }

        static void Main()
        {
            Program program = new Program();
            program.DeserlializeTopGames();
            Console.Clear();
            program.Start();
            program.SerializeTopGames();
        }//Main
        private void Start()
        {
            while (Run)
            {
                Console.WriteLine(
                "[1] Start a new game\n" +
                "[2] Show top scores\n" +
                "[3] Quit");

                switch (GetUserInput())
                {
                    case 1:
                        {
                            Console.Write("Type your nickname: ");
                            Player player = new Player(GetName());
                            Game newGame = new Game(player);
                            while (newGame.RunGame()) { }
                            TopGames.Add(newGame);//null exception przez deserlializacje, topgames jest nullem
                            break;
                        }
                    case 2:
                        {
                            SortTopGames();
                            ShowTopGames();
                            break;
                        }
                    case 3:
                        {
                            Run = false;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Error. Try again.");
                            Console.WriteLine();
                            break;
                        }

                }
            }
        }
        private void ShowTopGames()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    TopGames[i].ShowGameInfo();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        private void SerializeTopGames()
        {
            ISerialize<Game> xmlSerializer = new XmlSerializer<Game>(_path);
            if (TopGames.Count > 10)
            {
                int del = TopGames.Count - 10;
                TopGames.RemoveRange(10, del);
            }
            xmlSerializer.Serialize(TopGames);
        }
        private void DeserlializeTopGames()
        {
            ISerialize<Game> xmlSerializer = new XmlSerializer<Game>(_path);
            try
            {
                TopGames = xmlSerializer.Deserialize();
                if (TopGames == null)
                    TopGames = new List<Game>();
            }
            catch (Exception)
            {
                Console.WriteLine("Game list is empty. Play a game to fill it!");
            }

        }
        private string GetName()
        {
            string nick = string.Empty;
            try
            {
                nick = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return nick;
        }
        private static int GetUserInput()
        {
            int input = 0;
            while (true)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return input;
        }
        private void SortTopGames()
        {
            try
            {
                for (int i = 0; i < TopGames.Count; i++)
                {
                    for (int j = 0; j < TopGames.Count; j++)
                    {
                        int scoreA = TopGames[i].Player.Score;
                        int scoreB = TopGames[j].Player.Score;
                        if (scoreA > scoreB)
                        {
                            Game tempG = TopGames[i];
                            TopGames[i] = TopGames[j];
                            TopGames[j] = tempG;
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        public bool Run
        {
            get => _run;
            set => _run = value;
        }//properties
        public List<Game> TopGames
        {
            get => _topGames;
            set => _topGames = value;
        }
    }
}
