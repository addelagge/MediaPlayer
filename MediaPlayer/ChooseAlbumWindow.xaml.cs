//Fredric Lagedal AH2318, 2017-10-05, Assignment 2

using System.Collections.Generic;
using System.Windows;
using BusinessDataRepository;

namespace MediaPlayerApp
{
    /// <summary>
    /// Interaction logic for ChooseAlbumWindow.xaml
    /// </summary>
    public partial class ChooseAlbumWindow : Window
    {
        public string AlbumName { get; set; }
        private List<string> names;

        public ChooseAlbumWindow()
        {
            InitializeComponent();
            names = new Repository().GetAlbumNames();
            albums.ItemsSource = names;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            AlbumName = albums.SelectedItem.ToString();
            DialogResult = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Repository repository = (Repository)FindResource("repository");

            if (repository.AlbumExists(albums.SelectedItem.ToString()))
            {
                if (MessageBox.Show("Are you sure?", "Delete album", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    repository.DeleteAlbum(albums.SelectedItem.ToString());
                    albums.ItemsSource = repository.GetAlbumNames();
                }
                    
            }
        }
    }
}
