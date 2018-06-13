using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.models;

namespace UnitTestProject
{
    class ZeroDie : IDie
    {
        override public int Roll()
        {
            return 0;
        }
    }
}
