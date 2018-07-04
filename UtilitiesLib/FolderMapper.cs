using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerLib
{
    public class FolderMapper
    {
        public Node Tree { get; set; }

        public FolderMapper()
        {
            Tree = new Node();
            LoadTree();
        }

        public void LoadTree()
        {

            foreach (string drive in Directory.GetLogicalDrives())
            {
                if (drive.ToLower().StartsWith("c"))
                {
                    Node parent = new Node() { Header = drive, FullPath = drive };

                    if (new DirectoryInfo(drive).GetFiles("*.jpg").Length > 0)
                        parent.MarkAsContainingImages(new DirectoryInfo(drive).GetFiles("*.jpg"));

                    foreach (DirectoryInfo folder in new DirectoryInfo(drive).GetDirectories())
                    {
                        if (folder.Name.Contains("Testm"))
                        {
                            Node child = new Node() { Header = folder.Name, FullPath = folder.FullName };
                            if (folder.GetFiles("*.jpg").Length > 0)
                                child.MarkAsContainingImages(folder.GetFiles("*.jpg"));

                            Traverse(folder.FullName, child);
                            parent.Items.Add(child);
                        }
                    }
                    Tree.Items.Add(parent);
                }
            }
        }
        
        

        private void Traverse(string path, Node item)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(path);
            DirectoryInfo[] folders = currentDirectory.GetDirectories();

            foreach (DirectoryInfo subFolder in folders)
            {
                Node subItem = new Node() { Header = subFolder.Name, FullPath = subFolder.FullName };

                if (subFolder.GetFiles("*.jpg").Length > 0)
                    subItem.MarkAsContainingImages(subFolder.GetFiles("*.jpg"));

                Traverse(subFolder.FullName, subItem);
                item.Items.Add(subItem);
            }
        }


        //public static Node LoadTree()
        //{
        //    Node tree = new Node();
        //    foreach (string drive in Directory.GetLogicalDrives())
        //    {
        //        if (drive.ToLower().StartsWith("c"))
        //        {
        //            Node parent = new Node() { Header = drive, FullPath = drive };

        //            if (new DirectoryInfo(drive).GetFiles("*.jpg").Length > 0)
        //                parent.MarkAsContainingImages(new DirectoryInfo(drive).GetFiles("*.jpg"));

        //            foreach (DirectoryInfo folder in new DirectoryInfo(drive).GetDirectories())
        //            {
        //                if (folder.Name.Contains("Testm"))
        //                {
        //                    Node child = new Node() { Header = folder.Name, FullPath = folder.FullName };
        //                    if (folder.GetFiles("*.jpg").Length > 0)
        //                        child.MarkAsContainingImages(folder.GetFiles("*.jpg"));

        //                    Traverse(folder.FullName, child);
        //                    parent.Items.Add(child);
        //                }
        //            }
        //            tree.Items.Add(parent);
        //        }
        //    }

        //    return tree;
        //}

        //private static void Traverse(string path, Node item)
        //{
        //    DirectoryInfo currentDirectory = new DirectoryInfo(path);
        //    DirectoryInfo[] folders = currentDirectory.GetDirectories();

        //    foreach (DirectoryInfo subFolder in folders)
        //    {
        //        Node subItem = new Node() { Header = subFolder.Name, FullPath = subFolder.FullName };

        //        if (subFolder.GetFiles("*.jpg").Length > 0)
        //            subItem.MarkAsContainingImages(subFolder.GetFiles("*.jpg"));

        //        Traverse(subFolder.FullName, subItem);
        //        item.Items.Add(subItem);
        //    }
        //}
    }
}
