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
    public class MediaFileFinderTests
    {
        //*****************IsVideoclip tests*******************************//
        [TestMethod()]
        public void IsVideoClip_TestNullString()
        {
            string filePath = null;
            try
            {
                MediaFileFinder.IsVideoClip(filePath);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, MediaFileFinder.nullValueMessage);
                return;
            }

            Assert.Fail("Expected exception not thrown");
        }

        [TestMethod()]
        public void IsVideoClip_TestEmptyString()
        {
            string filePath = string.Empty;
            try
            {
                MediaFileFinder.IsVideoClip(filePath);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, MediaFileFinder.emptyValueMessage);
                return;
            }

            Assert.Fail("Expected exception not thrown");
        }

        [TestMethod()]
        public void IsVideoClip_TestValidVideoClip()
        {
            string[] realClips = { "video.mp4", "video.mpg", "video.avi"};
            foreach(string file in realClips)
                Assert.IsTrue(MediaFileFinder.IsVideoClip(file));

            string[] NotClips = { "video.qwer", "video.asdf", "video.zxcv"};
            foreach (string file in NotClips)
                Assert.IsFalse(MediaFileFinder.IsVideoClip(file));
        }


        //*****************IsImage tests*******************************//
        [TestMethod()]
        public void IsImage_TestNullString()
        {
            string filePath = null;
            try
            {
                MediaFileFinder.IsImage(filePath);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, MediaFileFinder.nullValueMessage);
                return;
            }

            Assert.Fail("Expected exception not thrown");
        }

        [TestMethod()]
        public void IsImage_TestEmptyString()
        {
            string filePath = string.Empty;
            try
            {
                MediaFileFinder.IsImage(filePath);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, MediaFileFinder.emptyValueMessage);
                return;
            }

            Assert.Fail("Expected exception not thrown");
        }

        [TestMethod()]
        public void IsImage_TestValidImage()
        {
            string[] realImages = { "image.jpg", "image.png" };
            foreach (string file in realImages)
                Assert.IsTrue(MediaFileFinder.IsImage(file));

            string[] notImages = { "image.asf", "image.qwer" };
            foreach (string file in notImages)
                Assert.IsFalse(MediaFileFinder.IsImage(file));
        }
    }
}