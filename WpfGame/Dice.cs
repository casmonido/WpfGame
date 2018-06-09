using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Dice: Die
    {
        private static int DIE_NUM = 4;
        private Game game;
        public List<Die> dice = new List<Die>();

        public Dice(Game g)
        {
            game = g;
            for (int i = 0; i < DIE_NUM; ++i)
                dice.Add(new Die());
        }

        new public int Roll()
        {
            if (game.Rolled)
                return rolledNum;
            game.Rolled = true;
            rolledNum = 0;
            for (int i = 0; i < dice.Count; ++i)
                rolledNum += dice[i].Roll();
            return rolledNum;
        }
    }
}
