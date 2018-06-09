﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame
{
    public class Player
    {
        public static int NUM_PIECES = 6;
        public ObservableCollection<Piece> Pieces { get; private set; }
        private Game game;
        private Whose who;
        private Random rand = new Random();

        public Player(Whose w, Board boardModel, Game g)
        {
            game = g;
            who = w;
            Pieces = new ObservableCollection<Piece>();
            int tmp = who == Whose.computers ? 4 : 0;
            for (int i = 0; i < NUM_PIECES; i++)
                Pieces.Add(new Piece(who, boardModel, new StartingSquare(i+1, tmp, "Transparent"), this));
            if (who == Whose.computers)
                game.PropertyChanged += (sender, e) =>
                {
                    if (!e.PropertyName.Equals("Turn"))
                        return;
                    if (game.Turn != Whose.computers)
                        return;
                    game.Dice.Roll();
                    int i;
                    do
                    {
                        i = rand.Next(0, NUM_PIECES);
                    } while (Pieces[i].WholePathCrossed);
                    move(Pieces[i]);
                };
        }

        public void move(Piece p)
        {
            if (game.Turn != who || !game.Rolled)
                return;
            p.move(game.Dice.rolledNum);
            game.changeTurn();
        }
    }
}
