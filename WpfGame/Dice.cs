using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Dice: Die
    {
        private static int DIE_NUM = 4;
        public List<Die> dice = new List<Die>();

        public Dice()
        {
            for (int i = 0; i < DIE_NUM; ++i)
                dice.Add(new Die());
        }

        public int roll()
        {
            rolledNum = 0;
            for (int i = 0; i < dice.Count; ++i)
                rolledNum += dice[i].roll();
            return rolledNum;
        }
    }
}
