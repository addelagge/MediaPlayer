//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System.Windows;
using System.Windows.Controls;
using MediaPlayerLib;
using System;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace MediaPlayerApp
{
    /// <summary>
    /// Page där användaren kan lägga till mediafiler till en slide show
    /// </summary>
    public partial class SlideShowPage : Page
    {
        /// <summary>
        /// Används för att visa de bilder som ska visas i en slide show
        /// </summary>
        private PhotoView photoWindow;

        public SlideShowPage()
        {
            InitializeComponent();
            ((MediaPlayer)FindResource("player")).Reset();
        }

        private void btnAddMedia_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = (MediaPlayer)FindResource("player");
            player.AddImagePath((picsPanel.SelectedItem as MediaFile));
        }

        /// <summary>
        /// Sakapar en ny instans av PhotoView och "prenumererar" på events från ett SlideShow objekt
        /// </summary>
        private void btnCreateSlideShow_Click(object sender, RoutedEventArgs e)
        {
            photoWindow = new PhotoView();
            MediaPlayer player = (MediaPlayer)FindResource("player");
            player.CreateSlideShow(int.Parse(txtUpdateInterval.Text));
            player.NewSlideShow.events += NewSlideShow_events;
            photoWindow.Show();
            player.NewSlideShow.Start(); 
        }

        private void NewSlideShow_events(object sender, EventArgs e)
        {
            MediaFile file = (e as MediaEventArg).MediaFile;
            photoWindow.Update(file);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = (MediaPlayer)FindResource("player");
            player.RemoveImagePath((lbxAlbum.SelectedItem as MediaFile));
        }


        private void picsPanel_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (picsPanel.SelectedIndex == -1)
            {
                imgPreview.Source = new BitmapImage();
                return;
            }

            string path = (picsPanel.SelectedItem as MediaFile).ImagePath;
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

        private void mnuAddFileToSlideShow_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Media files (*.jpg, *.png, *.mp4, *.avi, *.mpg) | *.jpg; *.png; *.mp4; *.avi; *.mpg" ;
            if (dialog.ShowDialog() == true)
            {
                MediaPlayer player = (MediaPlayer)FindResource("player");
                player.AddImagePath(new MediaFile() { FileName = dialog.SafeFileName, ImagePath = dialog.FileName });
            }
        }
    }
}
