//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace MediaPlayerApp
{
    /// <summary>
    /// Startsidan där användaren får välja om vad den vill göra
    /// </summary>
    public partial class StartPage : Page
    {
        /// <summary>
        /// Frame där alla pages visas.
        /// </summary>
        Frame mainFrame;

        public StartPage(Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new AlbumPage(mainFrame);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            ChooseAlbumWindow window = new ChooseAlbumWindow();
            if(window.ShowDialog() == true)
                mainFrame.Content = new AlbumPage(window.AlbumName, mainFrame);
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Text files (*.txt) | *.txt";
            //if (dialog.ShowDialog() == true)
            //    mainFrame.Content = new AlbumPage(dialog.FileName, mainFrame);
        }

        //private void btnSlideShow_Click(object sender, RoutedEventArgs e)
        //{
        //    mainFrame.Content = new SlideShowPage();
        //}
    }
}
