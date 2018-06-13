using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfGame.models;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class DiceTest
    {

        [TestMethod]
        public void TestRoll_RollIfNotRolled()
        {
            List<IDie> dieList = new List<IDie>();
            for (int i = 0; i < Dice.DIE_NUM; ++i)
                dieList.Add(new Die());
            Game g = new Game(dieList);
            Dice d = g.Dice;
            for (int i = 0; i < 10; ++i)
                Assert.AreEqual(d.Roll(), d.Roll());
            int same = 0;
            for (int i = 0; i < 100; ++i)
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

        [TestMethod]
        public void TestRoll_RolledZero()
        {
            List<IDie> dieList = new List<IDie>();
            for (int i = 0; i < Dice.DIE_NUM; ++i)
                dieList.Add(new ZeroDie());
            Game zeroGame = new Game(dieList);
            Dice d = zeroGame.Dice;
            Assert.AreEqual(zeroGame.Rolled, false);
            int res = d.Roll();
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void TestRoll_RolledOne()
        {
            List<IDie> dieList = new List<IDie>();
            for (int i = 0; i < Dice.DIE_NUM; ++i)
                dieList.Add(new NonZeroDie());
            Game nonzeroGame = new Game(dieList);
            Dice d = nonzeroGame.Dice;
            int res = d.Roll();
            Assert.AreEqual(res, 4);
            Assert.AreEqual(nonzeroGame.Rolled, true);
        }
    }
}
