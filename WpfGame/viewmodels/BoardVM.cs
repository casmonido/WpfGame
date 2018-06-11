using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfGame.models;

namespace WpfGame.viewmodels
{
    public class BoardVM
    {
        private Board model;
        public List<SquareVM> squares = new List<SquareVM>();
        public CompositeCollection CompositeCollection { get; set; } = new CompositeCollection();
        ObservableCollection<PieceVM> pieces = new ObservableCollection<PieceVM>();

        public BoardVM(Board b, 
            Collection<Piece> playersPieces, Collection<Piece> computersPieces)
        {
            model = b;
            for (int i = 0; i < b.squares.Count; i++)
                squares.Add(new SquareVM(b.squares[i]));
            CompositeCollection.Add(new CollectionContainer() { Collection = squares });
            for (int i = 0; i < playersPieces.Count; i++)
            {
                squares.Add(new StartingSquareVM(playersPieces[i].startingSquare));
                pieces.Add(new PieceVM(playersPieces[i], i));
            }
            for (int i = 0; i < computersPieces.Count; i++)
            {
                squares.Add(new StartingSquareVM(computersPieces[i].startingSquare));
                pieces.Add(new PieceVM(computersPieces[i], i));
            }
            CompositeCollection.Add(new CollectionContainer() { Collection = pieces });
        }
    }
}
