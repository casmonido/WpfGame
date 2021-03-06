﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfGame.models;

namespace WpfGame
{

    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow win = new MainWindow(this);
            win.Show();
        }

        public Game createModel()
        {
            List<IDie> dieList = new List<IDie>();
            for (int i = 0; i < Dice.DIE_NUM; ++i)
                dieList.Add(new Die());
            return new Game(dieList);
        }
    }
}

