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
        public ObservableCollection<SquareVM> squares = new ObservableCollection<SquareVM>();
        public CompositeCollection compositeCollection = new CompositeCollection();

        public BoardVM(Board b, ObservableCollection<PieceVM> _pieces)
        {
            model = b;
            for (int i = 0; i < b.squares.Count; i++)
                squares.Add(new SquareVM(b.squares[i]));
            compositeCollection.Add(new CollectionContainer() { Collection = squares });
            compositeCollection.Add(new CollectionContainer() { Collection = _pieces });
        }
    }
}
