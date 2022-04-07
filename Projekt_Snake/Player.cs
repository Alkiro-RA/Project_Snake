using System;

namespace Projekt_Snake
{
    public class Player
    {
        private string _name;
        private int _score;
        public Player(string name)
        {
            Name = name;
            Score = 0;
        }
        
        public override string ToString()
        {
            return $"Player's name: {Name}\n" +
                $"Player's score: {Score}";
        } // returns string showing player's game info (nick, score)
        
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
