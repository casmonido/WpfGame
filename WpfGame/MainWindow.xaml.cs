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
using WpfGame.viewmodels;
using WpfGame.views;

namespace WpfGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App app;
        private GameVM gameVM;

        public MainWindow(App ap)
        {
            app = ap;
            InitializeComponent();
            gameVM = new GameVM(app.createModel());
            DataContext = gameVM;
        }

        public void _SettingsView(object sender, RoutedEventArgs e)
        {
            DataContext = new SettingsVM();
        }

        public void _GameView(object sender, RoutedEventArgs e)
        {
            DataContext = gameVM;
        }

        public void _New(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to close this game and open another?";
            string caption = "New";
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption,
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                gameVM = new GameVM(app.createModel());
            if (DataContext.GetType() == typeof(GameVM))
                DataContext = gameVM;
        }

        public void _Exit(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to quit this game?";
            string caption = "Exit";
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, 
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                System.Environment.Exit(1);
        }
    }
}
