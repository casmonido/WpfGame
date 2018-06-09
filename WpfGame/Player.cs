using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Player
    {
        public static int NUM_PIECES = 6;
        public ObservableCollection<Piece> Pieces { get; private set; }
        private Game game;

        public Player(Whose who, Board boardModel, Game g)
        {
            game = g;
            Pieces = new ObservableCollection<Piece>();
            int tmp = who == Whose.computers ? 4 : 0;
            for (int i = 0; i < NUM_PIECES; i++)
                Pieces.Add(new Piece(who, boardModel, new StartingSquare(i+1, tmp, "Transparent")));
        }
    }
}
