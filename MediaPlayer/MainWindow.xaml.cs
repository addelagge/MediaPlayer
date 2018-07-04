//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System.Windows;

namespace MediaPlayerApp
{
    /// <summary>
    /// Window som innehåller en huvud Frame som används för att visa alla olika pages
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Content = new StartPage(mainFrame);            
        }
    }
}
