//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using WMPLib;
using System.Windows;

namespace MediaPlayerLib
{
    /// <summary>
    /// Klass som representerar en slide show av mediafiler. Bilder visas med ett angivet intervall och videklipp spelas från start till slut.
    /// </summary>
    public class SlideShow
    {
        /// <summary>
        /// Mediafiler som ska spelas upp
        /// </summary>
        private ObservableCollection<MediaFile> media;

        /// <summary>
        /// Event handler som används för att skicka information om en mediafil till den som prenumererar.
        /// </summary>
        private event EventHandler events;

        /// <summary>
        /// Intervallet mellan bilderna i slide showen
        /// </summary>
        private int updateInterval;

        public SlideShow(int interval, ObservableCollection<MediaFile> files)
        {
            updateInterval = interval;
            media = files;
        }

        //public bool eventIsNull= true;

        /// <summary>
        /// Startar slide showen
        /// </summary>
        public async void Start()
        {
            foreach (MediaFile file in media)
                await Show(file);

            MessageBox.Show("Slide show finished");   
        }


        /// <summary>
        /// Visar bilden ifall det är en bild, alternativt visar videoklipp ifall det är ett sådant.
        /// </summary>
        private async Task Show(MediaFile file)
        {
            if (MediaFileFinder.IsVideoClip(file.ImagePath))
                await PlayClip(file.ImagePath);
            else
                await ShowImage(file);
        }

        /// <summary>
        /// Visar en bild i angivet antal sekunder
        /// </summary>
        private async Task ShowImage(MediaFile file)
        {
            events.Invoke(this, new MediaEventArg() { MediaFile = file });
            await Task.Delay(new TimeSpan(0,0,updateInterval));
        }

        /// <summary>
        /// Spelar upp ett videoklipp
        /// </summary>
        private async Task PlayClip(string fileName)
        {
            var clip = new WindowsMediaPlayer().newMedia(fileName);
            Process.Start(fileName);
            int startUpDelay = 3;
            await Task.Delay(new TimeSpan(0, 0, (int)clip.duration + startUpDelay));
        }

        public void AddSubscriber(Action<object, EventArgs> action)
        {
           events += action.Invoke;
        }

        public bool EventhandlerIsNull
        {
            get { return events == null; }
        }
    }

}
