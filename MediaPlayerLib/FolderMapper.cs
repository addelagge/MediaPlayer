//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System.IO;
using System.Windows;

namespace MediaPlayerLib
{
    /// <summary>
    /// Klass som bygger upp en hierarkisk mappstruktur och markerar mappar som innehåller mediafiler av vissa typer. Kan tex bindas till en  WPF TreeView
    /// </summary>
    public class FolderMapper
    {
        public Node Tree { get; set; }

        public FolderMapper()
        {
            Tree = new Node();
            LoadTree();
        }

        /// <summary>
        /// Skapar ett 'root' objekt och fyller det med underliggande mappar i en hierarkisk struktur
        /// </summary>
        public void LoadTree()
        {
            try
            {
                DirectoryInfo startFolder = new DirectoryInfo("c:\\Users\\Public");
                Node parent = new Node() { Header = startFolder.Name, FullPath = startFolder.FullName };
                if (MediaFileFinder.HasMediaFiles(new DirectoryInfo(startFolder.FullName).GetFiles()))
                    parent.MarkAsContainingImages(MediaFileFinder.mediaFiles);

                Traverse(startFolder.FullName, parent);
                if (parent.Items.Count == 0)
                    MessageBox.Show(string.Format("No media files were found in {0}. Please add files from the menu.", startFolder.FullName));
                else
                    Tree.Items.Add(parent);
            }
            catch { }                          
        }

        /// <summary>
        /// Letar rekursivt igenom underliggande mappar och markerar dem ifall de innhåller mediafiler
        /// </summary>
        private void Traverse(string path, Node item)
        {
            try
            {
                foreach (DirectoryInfo subFolder in new DirectoryInfo(path).GetDirectories())
                {
                    if (subFolder.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;

                    Node subItem = new Node() { Header = subFolder.Name, FullPath = subFolder.FullName };
                    if (MediaFileFinder.HasMediaFiles(subFolder.GetFiles()))
                        subItem.MarkAsContainingImages(MediaFileFinder.mediaFiles);

                    Traverse(subFolder.FullName, subItem);
                    item.Items.Add(subItem);
                }
            }
            catch { }            
        }

    }

}
