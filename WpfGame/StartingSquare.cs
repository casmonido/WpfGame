using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class StartingSquare: Square
    {

        public event Action<Whose, Square> CommandLeave;

        public void tryAndOccupy()
        {

        }

        public StartingSquare(int tx, int ty, String img): base(tx, ty, img)
        {
        }
    }
}
