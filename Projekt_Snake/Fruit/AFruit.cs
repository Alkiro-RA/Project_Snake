using System;

namespace Projekt_Snake
{
    abstract class AFruit // parrent class
        // blueprint for all other "score classes"
    {
        private int _x;
        private int _y;
        protected AFruit()
        {
            Spawn();
        }
        
        public abstract void DrawFruit();
        public abstract bool FruitEaten(Player player, Snake snake);
        public abstract bool TimeExpired(int i); // it's used to make Bonus and Trap fruits temporary objects on the map
        private void Spawn()
        {
            X = Game.RandomX();
            Y = Game.RandomY();
        }
        public void GenerateNewFruit(Snake snake)
        {
            bool notFree;
            do
            {
                Spawn();
                notFree = false;
                for (int i = 0; i < snake.Size; i++)
                {
                    if (X == snake.X[i] && Y == snake.Y[i])
                    {
                        notFree = true;
                        break;
                    }
                }
            } while (notFree);
        }
        public AFruit ChangeFruitType()
        {
            Random rand = new Random();
            int num = 0;
            num = rand.Next(0, 100);

            if (num < 80)
                return new FNormal();
            else if (num >= 80 && num < 90)
                return new FBonus();
            else
                return new FTrap();
        }
        
        public abstract int ScoreModifier
        {
            get;
            set;
        }//properties
        public abstract int Timer
        {
            get;
            set;
        }
        public int X
        {
            get => _x;
            set => _x = value;
        }
        public int Y
        {
            get => _y;
            set => _y = value;
        }
    }
}
