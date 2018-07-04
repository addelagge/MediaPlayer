//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System.Windows.Controls;
using MediaPlayerLib;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using BusinessDataRepository;
using System.Collections.Generic;

namespace MediaPlayerApp
{
    /// <summary>
    /// Page där man kan lägga till mediafiler till ett album
    /// </summary>
    public partial class AlbumPage : Page
    {
        /// <summary>
        /// Frame där alla pages visas.
        /// </summary>
        private Frame mainFrame;

        public AlbumPage(Frame frame)
        {
            InitializeComponent();
            ((MediaPlayer)FindResource("player")).Reset();
            mainFrame = frame;
        }

        public AlbumPage(string fileName, Frame frame)
        {
            InitializeComponent();
            mainFrame = frame;
            LoadMediaPlayer(fileName);
        }

        /// <summary>
        /// Hämtar alla mediafiler från valt album i databasen och lägger dessa i MediaPlayer
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadMediaPlayer(string fileName)
        {
            MediaPlayer player = (MediaPlayer)FindResource("player");
            player.Reset();
            player.Album.Name = fileName;

            List<MediaFile> mediaFiles = ((Repository)FindResource("repository")).GetFilesFromAlbum(fileName);
            foreach (MediaFile file in mediaFiles)
                player.AddImagePath(file);

        }

        /// <summary>
        /// Sparar det aktuella albumet i databasen
        /// </summary>
        private void Save(MediaAlbum album)
        {
            Repository repository = (Repository)FindResource("repository");

            if (repository.AlbumExists(album.Name))
            {
                if (MessageBox.Show("Do you want to overwrite it?", "Album exists in data base", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    repository.UpdateAlbum(album);
            }
            else
            {
                AddDescriptionWindow window = new AddDescriptionWindow();
                if (window.ShowDialog() == true)
                {
                    album.Name = window.ChosenText;
                    album.DateCreated = DateTime.Now;
                    repository.AddNewAlbum(album);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = (MediaPlayer)FindResource("player");
            player.AddImagePath((picsPanel.SelectedItem as MediaFile));
        }

        private void btnViewAlbum_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new ViewAlbumPage();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = (MediaPlayer)FindResource("player");
            player.RemoveImagePath(lbxAlbum.SelectedItem as MediaFile);
        }

        private void picsPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    Console.WriteLine(imgPreview.Width + " " + imgPreview.Height);
                }
                catch { MessageBox.Show("Can not show " + path); }        
            }
                
            else
                imgPreview.Source = new BitmapImage(new Uri("pack://application:,,,/MediaPlayer;component/Resources/videoclip-icon.png"));

        }

        private void btnAddDescription_Click(object sender, RoutedEventArgs e)
        {
            MediaFile file = lbxAlbum.SelectedItem as MediaFile;
            AddDescriptionWindow window = new AddDescriptionWindow(file.Description);
            if (window.ShowDialog() == true)
                file.Description = window.ChosenText;
        }

        private void mnuAddFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Media files (*.jpg, *.png, *.mp4, *.avi, *.mpg) | *.jpg; *.png; *.mp4; *.avi; *.mpg";
            if (dialog.ShowDialog() == true)
            {
                MediaPlayer player = (MediaPlayer)FindResource("player");
                player.AddImagePath(new MediaFile() { FileName = dialog.SafeFileName, ImagePath = dialog.FileName });
            }
        }

        private void mnuSave_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = (MediaPlayer)FindResource("player");
            if (!player.HasMedia)
            {
                MessageBox.Show("Media player is empty");
                return;
            }

            Save(player.Album);
        }


        private void mnuChange_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = (MediaPlayer)FindResource("player");
            Repository repository = (Repository)FindResource("repository");

            if (repository.AlbumExists(player.Album.Name))
            {
                AddDescriptionWindow window = new AddDescriptionWindow(player.Album.Name);
                if (window.ShowDialog() == true)
                {
                    if (repository.AlbumExists(window.ChosenText)){
                        MessageBox.Show(string.Format("An album with the name {0} already exists in the data base", window.ChosenText));
                        return;
                    }
                    repository.ChangeAlbumName(player.Album, window.ChosenText);
                    player.Album.Name = window.ChosenText;
                }
            }
            else
                MessageBox.Show("Album is not saved");
        }
    }//End of class

    

} //End of namespace
