using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Die
    {
        protected int rolledNum = 0;
        protected Random random = new Random();
        public int roll()
        {
            rolledNum = random.Next(0, 2);
            return rolledNum;
        }

        public int getRolledNum()
        {
            return rolledNum;
        }
    }
}
