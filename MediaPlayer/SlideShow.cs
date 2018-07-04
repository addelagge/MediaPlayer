using MediaPlayerLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Diagnostics;

namespace MediaPlayerApp
{
    class SlideShow
    {
        private ObservableCollection<ImagePreview> media;
        private DispatcherTimer timer = new DispatcherTimer();
        private int imageIndex = 0;

        public SlideShow()
        {
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {  
            imageIndex++;
            ShowFile(imageIndex);
        }

        public void Start()
        {
            if (media.Count == 0)
                return;

            photoWindow.Show();
            ShowFile(imageIndex);
            timer.Start();
        }

        private void ShowFile(int imageIndex)
        {
            if (imageIndex < media.Count)
            {
                ImagePreview file = media.ElementAt(imageIndex);
                photoWindow.Update(file.ImagePath);
            }

            
        }
    }
}
