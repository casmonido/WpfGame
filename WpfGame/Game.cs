using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Game
    {
        public Board Board { get; private set; }
        public Player Player { get; private set; }
        public Player Computer { get; private set; }
        public Dice Dice { get; private set; }
        public Whose Turn { get; set; } = Whose.players;
        public bool Rolled { get; set; } = false;

        public Game()
        {
            Board = new Board();
            Player = new Player(Whose.players, Board, this);
            Computer = new Player(Whose.computers, Board, this);
            Dice = new Dice(this);
        }

        public void changeTurn()
        {
            Turn = Turn == Whose.players ? Whose.computers : Whose.players;
            Rolled = false;
        }
    }
}
