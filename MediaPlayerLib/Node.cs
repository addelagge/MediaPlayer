//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace MediaPlayerLib
{
    /// <summary>
    /// Klass som representerar en Nod som innehåller sökvägar till eventuella mediafiler, samt subnoder. Är tänkt att användas tillsammans med ett WPF TreeView.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Subnoder
        /// </summary>
        public ObservableCollection<Node> Items { get; set; }

        /// <summary>
        /// Sökvägar till mediafiler som finns i noden
        /// </summary>
        public ObservableCollection<MediaFile> ImagePaths { get; private set; }

        /// <summary>
        /// Rubriken på noden
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Sökvägen till noden
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Sökväg till en ikon som ska visa ifall noden innehåller mediafiler
        /// </summary>
        public string Icon { get; private set; }

        public Node()
        {
            Items = new ObservableCollection<Node>();
        }

        /// <summary>
        /// Lägger till sökvägar till funna mediafiler, och sätter en bildkälla till nodens ikon
        /// </summary>
        public void MarkAsContainingImages(List<FileInfo> files)
        {
            Icon = "pack://application:,,,/MediaPlayerLib;component/Resources/camera-icon.png";
            AddImagePaths(files);
        }

        /// <summary>
        /// Lägger till sökvägar till funna mediafiler
        /// </summary>
        public void AddImagePaths(List<FileInfo> files)
        {
            ImagePaths = new ObservableCollection<MediaFile>();

            foreach (FileInfo file in files)
            {
                MediaFile img = new MediaFile() { FileName = file.Name, ImagePath = file.FullName };                
                ImagePaths.Add(img);
            }
                
        }

    }
}
