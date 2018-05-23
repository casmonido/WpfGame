using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    class BoardVM
    {
        private Board model;
        public ObservableCollection<SquareVM> _board = new ObservableCollection<SquareVM>();

        public BoardVM(Board b)
        {
            model = b;
            for (int i = 0; i < b.squares.Count; i++)
                _board.Add(new SquareVM(b.squares[i]));
        }
    }
}
