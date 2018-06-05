using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class DieVM
    {
        private static string IMG_UP = "/img/diceup.gif";
        private static string IMG_DOWN = "/img/dicedown.gif";
        public string imgSrc { get; private set; }
        private Die model;
        public DieVM(Die d)
        {
            model = d;
            imgSrc = d.getRolledNum() == 0 ? IMG_DOWN : IMG_UP;
        }
    }
}
