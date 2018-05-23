using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WpfGame.Square;

namespace WpfGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int UNIT = 100;
        public static int NUM_PIECES = 7;
        private ObservableCollection<Piece> piecesModel = new ObservableCollection<Piece>();
        private ObservableCollection<PieceVM> _pieces = new ObservableCollection<PieceVM>();

        public MainWindow()
        {
            InitializeComponent();

            Board boardModel = new Board();
            BoardVM boardVM = new BoardVM(boardModel);
            board.ItemsSource = boardVM._board;

            for (int i=0; i < NUM_PIECES; i++)
                piecesModel.Add(new Piece(Whose.players, boardModel));
            for (int i = 0; i < piecesModel.Count; i++)
                _pieces.Add(new PieceVM(piecesModel[i]));
            pieces.ItemsSource = _pieces;
        }



        public void _Open(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Open new game";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
