using System;

namespace Projekt_Snake
{
    public class Snake
    {
        private int[] _x;
        private int[] _y;
        private int _size;
        private ConsoleKey _lastMove; // created to resolve problem when user's last imput was a pause button 
        public Snake()
        {
            X = new int[200];
            Y = new int[200];
            Size = 3;
            X[0] = 5;
            Y[0] = 5;
        }
        
        public void SetSnakeParts()
        {
            for (int i = Size; i > 1; i--) //zaczyna od ogona 
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
        }
        public void Move(ConsoleKey action)
        {
            int[] helpX = new int[Size];
            int[] helpY = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                helpX[i] = X[i];
                helpY[i] = Y[i];
            }
            switch (action)
            {
                case ConsoleKey.UpArrow:
                    {
                        //łeb w góre
                        MoveUp(helpY);
                        LastMove = action;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        //łeb w dół
                        MoveDown(helpY);
                        LastMove = action;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        //łeb w lewo
                        MoveLeft(helpX);
                        LastMove = action;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        //łeb w prawo
                        MoveRight(helpX);
                        LastMove = action;
                        break;
                    }
                default:
                    {
                        RepeatMove();
                        break;
                    }
            }
        }
        public void RepeatMove() // here it changes "esc" (pause button) to last arrowkey imput there was, so that game doesn't freeze
        {
            if (LastMove == ConsoleKey.UpArrow)
                Y[0]--;
            else if (LastMove == ConsoleKey.DownArrow)
                Y[0]++;
            else if (LastMove == ConsoleKey.LeftArrow)
                X[0]--;
            else if (LastMove == ConsoleKey.RightArrow)
                X[0]++;
        }
        public void MoveUp(int[] y)
        {
            if ((--y[0]) == y[2])
            {
                Y[0]++;
            }
            else
                Y[0]--;
        }
        public void MoveDown(int[] y)
        {
            if ((++y[0]) == y[2])
            {
                Y[0]--;
            }
            else
                Y[0]++;
        }
        public void MoveLeft(int[] x)
        {
            if ((--x[0]) == x[2])
            {
                X[0]++;
            }
            else
                X[0]--;
        }
        public void MoveRight(int[] x)
        {
            if ((++x[0]) == x[2])
            {
                X[0]--;
            }
            else
                X[0]++;
        }
        public void DrawSnake()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.SetCursorPosition(X[i], Y[i]);
                Console.Write("#");
            }
        }
        
        public int[] X
        {
            get => _x;
            set => _x = value;
        } //properties
        public int[] Y
        {
            get => _y;
            set => _y = value;
        }
        public int Size
        {
            get => _size;
            set
            {
                if (value < 3)
                    _size = 3;
                else
                    _size = value;
            }
        }
        public ConsoleKey LastMove
        {
            get => _lastMove;
            set => _lastMove = value;
        }
    }
}
