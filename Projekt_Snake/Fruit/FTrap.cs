using System;

namespace Projekt_Snake
{
    class FTrap : AFruit
    {
        private int _penalty;
        private int _timer;
        public FTrap() : base()
        {
            ScoreModifier = 5;
            Timer = 4000;
        }
        
        public override void DrawFruit()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("X");
        }
        public override bool FruitEaten(Player player, Snake snake)
        {
            if (snake.X[0] == X)
                if (snake.Y[0] == Y)
                {
                        player.Score /= ScoreModifier;
                    
                    snake.Size /= ScoreModifier;
                    return true;
                }
            return false;
        }
        public override bool TimeExpired(int i)
        {
            Timer -= i;
            if (Timer <= 0)
            {
                return true;
            }
            else
                return false;
        }
        
        public override int ScoreModifier
        {
            get => _penalty;
            set
            {
                if (value != 2)
                    _penalty = 2;
                else
                    _penalty = value;
            }
        }//properties
        public override int Timer
        {
            get => _timer;
            set => _timer = value;
        }
    }
}

