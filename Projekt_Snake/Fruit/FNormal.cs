using System;

namespace Projekt_Snake
{
    class FNormal : AFruit
    {
        private int _points;
        private int _timer;
        public FNormal() : base()
        {
            ScoreModifier = 1;
        }
        
        public override void DrawFruit()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("+");
        }
        public override bool FruitEaten(Player player, Snake snake)
        {
            if (snake.X[0] == X)
                if (snake.Y[0] == Y)
                {
                    snake.Size++;
                    player.Score++;
                    return true;
                }
            return false;
        }
        public override bool TimeExpired(int i)
        {
            return false;
        }// blueprint's requirement..
        
        public override int ScoreModifier
        {
            get => _points;
            set
            {
                if (value != 1)
                    _points = 1;
                else
                    _points = value;
            }
        }//properties
        public override int Timer
        {
            get => _timer;
            set => _timer = 1;
        }
    }
}
