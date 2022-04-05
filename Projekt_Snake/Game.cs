using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Snake
{
    public class Game
    {
        private const int boardWidth = 22;
        private const int boardHeight = 12;
        private ConsoleKey _action;
        private bool _run;
        private Player _player;
        private int _gameSpeed;
        public Game(Player player)
        {
            Run = true;
            Player = player;
            GameSpeed = 200;
            Action = ConsoleKey.DownArrow;
        }
        public Game()//testowanie
        {
            Run = true;
            Player = new Player();
            GameSpeed = 200;
            Action = ConsoleKey.DownArrow;
        }
        public void ShowGameInfo()
        {
            Console.WriteLine(Player.ToString());
            Console.WriteLine();
        }
        public bool RunGame()
        {
            Snake snake = new Snake();
            AFruit fruit = new FNormal(); // funkcja AFruit będzie mogła manipulować którą klasą będzie fruit (MAM NADZIEJE)          
            while (Run)
            {
                DrawBoard();
                Input();
                if (fruit.TimeExpired(GameSpeed))
                {
                    fruit = fruit.ChangeFruitType();
                    fruit.GenerateNewFruit(snake);
                }
                else if (fruit.FruitEaten(Player, snake))
                {
                    fruit = fruit.ChangeFruitType();
                    fruit.GenerateNewFruit(snake);
                }
                snake.SetSnakeParts();
                GameControl(snake);
                snake.DrawSnake();
                fruit.DrawFruit();
                if (CheckCollision(snake))
                {
                    Run = false;
                    Console.Clear();
                    Console.WriteLine($"Game over. Your score is {Player.Score}!");
                }
                Thread.Sleep(GameSpeed);
            }
            return Run;
        }
        public void DrawBoard()
        {
            Console.Clear();
            for (int i = 0; i < boardWidth; i++)
            {
                Console.SetCursorPosition(i, 0); // górny bok
                if ((i == 0) || (i == boardWidth - 1))
                    Console.Write('+');
                else
                    Console.Write('-');
            }
            for (int i = 0; i < boardWidth; i++) //dolny bok
            {
                Console.SetCursorPosition(i, boardHeight - 1);
                if ((i == 0) || (i == boardWidth - 1))
                    Console.Write('+');
                else
                    Console.Write('-');
            }
            for (int i = 0; i < boardHeight; i++) //lewy bok
            {
                Console.SetCursorPosition(0, i);
                if ((i == 0) || (i == boardHeight - 1))
                    Console.Write('+');
                else
                    Console.Write('|');
            }
            for (int i = 0; i < boardHeight; i++) //prawy bok
            {
                Console.SetCursorPosition(boardWidth - 1, i);
                if ((i == 0) || (i == boardHeight - 1))
                    Console.Write('+');
                else
                    Console.Write('|');
            }
            Console.SetCursorPosition(0, boardHeight + 2);
            Console.WriteLine(Player.ToString());
        }
        private void Input()
        {
            if (Console.KeyAvailable) //sprawdza czy jest wciśniety przycisk
                Action = Console.ReadKey(true).Key;
        }
        private void GameControl(Snake snake)
        {
            if (Action == ConsoleKey.Escape)
                Pause(snake);
            else
                snake.Move(Action);
        }
        private void Pause(Snake snake)
        {
            Console.WriteLine();
            Console.WriteLine("Game pasued. Continue? [N if no / Anything else if yes]");
            string answer = Console.ReadLine();
            if (answer == "N" || answer == "n")
            {
                Run = false;
                Console.Clear();
            }
            else
                Action = snake.LastMove;
            snake.RepeatMove();
        }
        public bool CheckCollision(Snake snake)
        {
            for (int i = 1; i < snake.Size; i++)
            {
                if (snake.X[0] == snake.X[i])
                    if (snake.Y[0] == snake.Y[i])
                        return true;
            }
            for (int i = 0; i < boardWidth; i++)
            {
                if (snake.X[0] == i)
                    if (snake.Y[0] == 0)
                        return true;
                if (snake.X[0] == i)
                    if (snake.Y[0] == boardHeight - 1)
                        return true;
            }
            for (int i = 0; i < boardHeight; i++)
            {
                if (snake.X[0] == 0)
                    if (snake.Y[0] == i)
                        return true;
                if (snake.X[0] == boardWidth - 1)
                    if (snake.Y[0] == i)
                        return true;
            }
            return false;
        }
        public static int RandomX()
        {
            Random rand = new Random();
            return rand.Next(2, (boardWidth - 2));
        }
        public static int RandomY()
        {
            Random rand = new Random();
            return rand.Next(2, (boardHeight - 2));
        }
        public bool Run
        {
            get => _run;
            set => _run = value;
        }//properties
        public Player Player
        {
            get => _player;
            set => _player = value;
        }
        public ConsoleKey Action
        {
            get => _action;
            set => _action = value;
        }
        public int GameSpeed
        {
            get => _gameSpeed;
            set
            {
                if (value != 200)
                    _gameSpeed = 200;
                else
                    _gameSpeed = value;
            }
        }

        //testownie

    }
}