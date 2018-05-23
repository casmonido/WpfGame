using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Board
    {
        public static int BOARD_LEN = 8;
        public static int BOARD_HEIGHT = 3;
        public ObservableCollection<Square> squares = new ObservableCollection<Square>();
        public Board()
        {
            for (int j = 0; j < BOARD_HEIGHT; j++)
                for (int i = 0; i < BOARD_LEN; i++)
                    squares.Add(new Square(i, j, (i + j) % 2 == 0 ? "Blue" : "Black"));
        }

        public Square getNextLocation(Whose whosePath, int i)
        {
            return squares[i];
        }
    }
}
