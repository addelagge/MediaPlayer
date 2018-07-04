//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using MediaPlayerLib;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MediaPlayerApp
{
    /// <summary>
    /// Används för att titta visa bilderna som spelas i en slide show
    /// </summary>
    public partial class PhotoView : Window
    {
        public PhotoView()
        {
            InitializeComponent();
        }

        public void Update(MediaFile file)
        {
            imgPhoto.Source = new BitmapImage(new Uri(file.ImagePath));
            Title = file.FileName;
        }
    }
}
