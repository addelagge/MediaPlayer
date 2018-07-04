using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaPlayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerApp;

namespace MediaPlayerLib.Tests
{
    [TestClass()]
    public class MediaPlayerTests
    {
        //********************Add Imagepath tests**********************************//
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Expected exception not thrown")]
        public void AddImagePath_TestNull()
        {
            MediaFile file = null;
            MediaPlayer player = new MediaPlayer();

            player.AddImagePath(file);
        }

        [TestMethod()]
        public void AddImagePath_TestValidMediaFile()
        {
            MediaFile file = new MediaFile() { FileName = "filename", ImagePath = "imagepath" };
            MediaPlayer player = new MediaPlayer();

            player.AddImagePath(file);

            Assert.IsTrue(player.Album.ContainsFile(file));
            
        }


        //********************Remove Imagepath tests**********************************//
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Expected exception not thrown")]
        public void RemoveImagePath_TestNull()
        {
            MediaFile file = null;
            MediaPlayer player = new MediaPlayer();

            player.RemoveImagePath(file);
        }

        [TestMethod()]
        public void RemoveImagePath_TestValidMediaFile()
        {
            MediaFile file = new MediaFile() { FileName = "filename", ImagePath = "imagepath" };
            MediaPlayer player = new MediaPlayer();

            player.AddImagePath(file);
            player.RemoveImagePath(file);

            Assert.IsFalse(player.Album.ContainsFile(file));
        }

    }
}