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
    public class MediaFileTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Expected exception not thrown")]
        public void Matches_TestNull()
        {
            MediaFile file = null;
            MediaFile file2 = new MediaFile() { FileName = "filename", ImagePath = "imagepath" };
            file2.Matches(file);
        }

        [TestMethod()]
        public void Matches_TestMatch()
        {
            MediaFile file = new MediaFile() { FileName = "filename", ImagePath = "Imagepath" };
            MediaFile file2 = new MediaFile() { FileName = "filename", ImagePath = "Imagepath" };
            MediaFile file3 = new MediaFile() { FileName = "filename3", ImagePath = "imagepath3" };

            Assert.IsTrue(file.Matches(file2));
            Assert.IsFalse(file2.Matches(file3));
        }
    }
}