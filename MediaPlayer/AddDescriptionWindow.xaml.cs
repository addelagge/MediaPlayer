//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using MediaPlayerLib;
using System;
using System.Windows;

namespace MediaPlayerApp
{
    /// <summary>
    /// Window som används för att ange en beskrivning av en mediafil
    /// </summary>
    public partial class AddDescriptionWindow : Window
    {
        //private MediaFile currentFile;
        public string ChosenText { get; set; }

        public AddDescriptionWindow(string text)
        {
            InitializeComponent();
            //currentFile = file;
            txtDescription.Text = text;
            Title = "Add description";
        }

        public AddDescriptionWindow()
        {
            InitializeComponent();
            Title = "Album name";
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //currentFile.Description = txtDescription.Text;
            ChosenText = txtDescription.Text;
            DialogResult = true;
        }

    }
}
