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
        public ObservableCollection<Piece> piecesModel = new ObservableCollection<Piece>();

        public Player(Whose who, Board boardModel)
        {
            int tmp = who == Whose.computers ? 4 : 0;
            for (int i = 0; i < NUM_PIECES; i++)
                piecesModel.Add(new Piece(who, boardModel, new StartingSquare(i+1, tmp, "Transparent")));
        }
    }
}
