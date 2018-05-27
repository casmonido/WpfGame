using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfGame
{
    public class BoardVM
    {
        private Board model;
        public List<SquareVM> squares = new List<SquareVM>();
        public CompositeCollection compositeCollection = new CompositeCollection();
        ObservableCollection<PieceVM> pieces = new ObservableCollection<PieceVM>();

        public BoardVM(Board b, Player player, Player comp)
        {
            model = b;
            for (int i = 0; i < b.squares.Count; i++)
                squares.Add(new SquareVM(b.squares[i]));
            compositeCollection.Add(new CollectionContainer() { Collection = squares });
            for (int i = 0; i < player.piecesModel.Count; i++)
            {
                squares.Add(new StartingSquareVM(player.piecesModel[i].startingSquare));
                pieces.Add(new PieceVM(player.piecesModel[i], i));
            }
            for (int i = 0; i < comp.piecesModel.Count; i++)
            {
                squares.Add(new StartingSquareVM(comp.piecesModel[i].startingSquare));
                pieces.Add(new PieceVM(comp.piecesModel[i], i));
            }
            compositeCollection.Add(new CollectionContainer() { Collection = pieces });
        }
    }
}
