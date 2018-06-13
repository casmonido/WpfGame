using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.models
{
    public class Square 
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int ImgNr { get; private set; }
        public event Action<Whose, Square> CommandLeave;
        private Whose whose = Whose.nobodys;

        public OccupyResponses tryAndOccupy(Piece p)
        {
            if (whose != Whose.nobodys && whose == p.Owner)
                return OccupyResponses.NOT_OK;
            if (CommandLeave != null)
                CommandLeave(whose, this);
            CommandLeave += p.HandleCommandLeave;
            whose = p.Owner;
            return OccupyResponses.OK;
        }

        public void leave(Piece p)
        {
            CommandLeave -= p.HandleCommandLeave;
            whose = Whose.nobodys;
        }

        public Square(int tx, int ty, int imgNr)
        {
            X = tx;
            Y = ty;
            ImgNr = imgNr;
        }
    }
}
