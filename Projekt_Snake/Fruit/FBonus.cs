using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Snake
{
    class FBonus : AFruit
    {
        private int _bonusPoints;
        private int _timer;
        public FBonus() : base()
        {
            ScoreModifier = 5;
            Timer = 6000;
        }
        public override void DrawFruit()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("O");
        }
        public override bool FruitEaten(Player player, Snake snake)
        {
            if (snake.X[0] == X)
                if (snake.Y[0] == Y)
                {
                    player.Score += ScoreModifier;
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
            get => _bonusPoints;
            set
            {
                if (value != 5)
                    _bonusPoints = 5;
                else
                    _bonusPoints = value;
            }
        }//properties
        public override int Timer
        {
            get => _timer;
            set => _timer = value;
        }
    }
}
