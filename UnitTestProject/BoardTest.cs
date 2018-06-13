using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfGame.models;

namespace UnitTestProject
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void Test_ReturnZeroIfOutofRange()
        {
            List<IDie> dieList = new List<IDie>();
            for (int i = 0; i < Dice.DIE_NUM; ++i)
                dieList.Add(new Die());
            Game g = new Game(dieList);
            Board b = g.Board;
            Square zero = new Square(0, 0, -1);
            Piece p = new Piece(Whose.computers, b, zero, g.Computer);
            Square s = b.getNextLocation(p, 0);
            Assert.AreEqual(zero, s);
            s = b.getNextLocation(p, -2);
            Assert.AreEqual(zero, s);
            s = b.getNextLocation(p, 30);
            Assert.AreEqual(zero, s);
        }
    }
}
