using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfGame.models;

namespace UnitTestProject
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void TestRoll_RolledZero()
        {
            Game g = new Game();
            Dice d = new Dice(g);
            for (int i = 0; i < 10; ++i)
                Assert.AreEqual(d.Roll(), d.Roll());
            int same = 0;
            for (int i = 0; i < 10; ++i)
            {
                g.Rolled = false;
                int res1 = d.Roll();
                g.Rolled = false;
                int res2 = d.Roll();
                if (res1 == res2)
                    same++;
            }
            Assert.AreNotEqual(same, 0);
        }
  
    }
}
