using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaPlayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MediaPlayerLib.Tests
{
    [TestClass()]
    public class SlideShowTests
    {
        [TestMethod()]
        public void Start_TestEventhandler()
        {
            SlideShow s = new SlideShow(3, new ObservableCollection<MediaFile>());
            s.AddSubscriber((object sender, EventArgs e) =>
            {
                Console.WriteLine("testing");
            });
            Assert.IsFalse(s.EventhandlerIsNull);
        }

        [TestMethod()]
        public void Start_TestEventhandlerWhenNull()
        {
            SlideShow s = new SlideShow(3, new ObservableCollection<MediaFile>());
            Assert.IsTrue(s.EventhandlerIsNull);
        }


    }
}