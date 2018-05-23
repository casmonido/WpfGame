using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGame
{

    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static int UNIT = 100;
        public static int NUM_PIECES = 7;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ObservableCollection<Piece> piecesModel = new ObservableCollection<Piece>();
            ObservableCollection<PieceVM> _pieces = new ObservableCollection<PieceVM>();

            Board boardModel = new Board();
            BoardVM boardVM = new BoardVM(boardModel);

            for (int i = 0; i < NUM_PIECES; i++)
                piecesModel.Add(new Piece(Whose.players, boardModel));
            for (int i = 0; i < piecesModel.Count; i++)
                _pieces.Add(new PieceVM(piecesModel[i]));

            MainWindow win = new MainWindow(_pieces, boardVM);
            win.Show();
        }
    }
}

