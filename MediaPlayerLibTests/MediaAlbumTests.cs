using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaPlayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerLib.Tests
{
    [TestClass()]
    public class MediaAlbumTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Expected exception not thrown")]
        public void ContainsFile_TestNullFile()
        {
            MediaFile file = null;
            MediaAlbum album = new MediaAlbum();
            album.ContainsFile(file);
        }

        [TestMethod()]
        public void ContainsFile_TestContainsFile()
        {
            MediaFile file = new MediaFile() { FileName = "filename", ImagePath = "imagepath" };
            MediaAlbum album = new MediaAlbum();
            album.MediaFiles.Add(file);
            Assert.IsTrue(album.ContainsFile(file));
        }


    }
}