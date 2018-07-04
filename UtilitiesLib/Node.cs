using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerLib
{
    public class Node
    {
        public ObservableCollection<Node> Items { get; set; }

        public ObservableCollection<ImagePreview> ImagePaths { get; private set; }

        public string Header { get; set; }
        public string FullPath { get; set; }

        public string Icon { get; private set; }

        public Node()
        {
            Items = new ObservableCollection<Node>();
            
        }

        public void MarkAsContainingImages(FileInfo[] files)
        {
            Icon = "C:\\Testmapp\\camera-icon.png";
            AddImagePaths(files);
        }

        private void AddImagePaths(FileInfo[] files)
        {
            ImagePaths = new ObservableCollection<ImagePreview>();

            foreach (FileInfo file in files)
            {
                ImagePreview img = new ImagePreview() { FileName = file.Name, ImagePath = file.FullName };
                ImagePaths.Add(img);
            }
                
        }

    }
}
