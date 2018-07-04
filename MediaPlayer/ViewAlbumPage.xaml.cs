//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using MediaPlayerLib;
using System.Windows.Controls;
using System;
using System.Windows.Media.Imaging;
using System.Windows;
using Microsoft.Win32;

namespace MediaPlayerApp
{
    /// <summary>
    /// Page där användaren kan lägga till mediafiler till ett album som går att spara. Det går även att lägga till beskrivningar av mediafilerna.
    /// </summary>
    public partial class ViewAlbumPage : Page
    {
        private PhotoView photoWindow;

        public ViewAlbumPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sakapar en ny instans av PhotoView och "prenumererar" på events från ett SlideShow objekt
        /// </summary>
        private void btnCreateSlideShow_Click(object sender, RoutedEventArgs e)
        {
            photoWindow = new PhotoView();            
            MediaPlayer player = (MediaPlayer)FindResource("player");
            player.CreateSlideShow(int.Parse(txtUpdateInterval.Text));
            Action<object, EventArgs> method = (object s, EventArgs ea) =>
            {
                MediaFile file = (ea as MediaEventArg).MediaFile;
                photoWindow.Update(file);
            };

            player.NewSlideShow.AddSubscriber(method);
            photoWindow.Show();
            player.NewSlideShow.Start();
        }


        private void lbxAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxAlbum.SelectedIndex == -1)
            {
                imgPreview.Source = new BitmapImage();
                return;
            }

            string path = (lbxAlbum.SelectedItem as MediaFile).ImagePath;
            if (MediaFileFinder.IsImage(path))
            {
                try
                {
                    imgPreview.Source = new BitmapImage(new Uri(path));
                }
                catch { MessageBox.Show("Can not show " + path); }
            }
                
            else
                imgPreview.Source = new BitmapImage(new Uri("pack://application:,,,/MediaPlayer;component/Resources/videoclip-icon.png"));
        }

        //private void mnuSave_Click(object sender, RoutedEventArgs e)
        //{
        //    MediaPlayer player = (MediaPlayer)FindResource("player");
        //    if (!player.HasMedia)
        //    {
        //        MessageBox.Show("Media player is empty");
        //        return;
        //    }

        //    SaveFileDialog dialog = new SaveFileDialog();
        //    dialog.Filter = "Text files (*.txt) | *.txt";
        //    if (dialog.ShowDialog() == true)
        //        player.Serialize(dialog.FileName);
        //}

    }
}
