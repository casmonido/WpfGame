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
        public String ImgSrc { get; private set; }
        public int Lp { get; private set; }
        private Die model;
        public DieVM(Die d, int lp)
        {
            model = d;
            ImgSrc = d.getRolledNum() == 0 ? IMG_DOWN : IMG_UP;
            Lp = lp;
            Action<object> messageTarget = delegate (object s) {
               //
            };
            RollOnClick = new ExecuteAction(messageTarget);
        }

        public ExecuteAction RollOnClick { get; set; }
    }
}
