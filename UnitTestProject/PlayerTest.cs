using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfGame.models;

namespace UnitTestProject
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Test_PlayerMovePiece()
        {
            List<IDie> dieList = new List<IDie>();
            for (int i = 0; i < Dice.DIE_NUM; ++i)
                dieList.Add(new NonZeroDie());
            Game g = new Game(dieList);
            g.Dice.Roll();
            Player p = g.Player;
            Piece piece = p.Pieces[0];
            Assert.AreEqual(g.Turn, p.Who);
            Assert.AreEqual(g.Rolled, true);
            Assert.AreNotEqual(g.Dice.RolledNum, 0);

            Assert.AreEqual(piece.PathCrossed, 0);
            Square scr = g.Board.getNextLocation(piece, g.Dice.RolledNum);
            Assert.AreEqual(piece.move(g.Dice.RolledNum), OccupyResponses.OK);
            Assert.AreEqual(piece.move(0), OccupyResponses.OK);
            Assert.AreEqual(piece.PathCrossed, g.Dice.RolledNum);
            Assert.AreEqual(p.Pieces[1].move(g.Dice.RolledNum), OccupyResponses.NOT_OK);

            piece.HandleCommandLeave(p.Who, scr);
            Assert.AreEqual(scr.Whose, Whose.nobodys);
            
            Assert.AreEqual(piece.PathCrossed, 0);

            Assert.AreEqual(g.Turn, Whose.players);
            Assert.AreEqual(g.Rolled, true);
            Assert.AreNotEqual(g.Dice.RolledNum, 0);
            Assert.AreEqual(p.move(piece), OccupyResponses.OK);
            Assert.AreEqual(g.Turn, Whose.computers);
            Assert.AreEqual(g.Rolled, false);
            Assert.AreEqual(piece.Location, scr);

        }
    }
}
