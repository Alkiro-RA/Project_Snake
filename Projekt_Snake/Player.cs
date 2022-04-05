using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Snake
{
    public class Player
    {
        private string _name;
        private int _score;
        public Player()
        {
            Name = string.Empty;
            Score = 0;
        }
        public Player(string name)
        {
            Name = name;
            Score = 0;
        }
        public override string ToString()
        {
            return $"Player's name: {Name}\n" +
                $"Player's score: {Score}";
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        } //properties
        public int Score
        {
            get => _score;
            set => _score = value;
        }
    }
}
