//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System.Collections.ObjectModel;
using UtilitiesLib;
using System;

namespace MediaPlayerLib
{
    /// <summary>
    /// Klass som används för att skapa fotoalbum och slide shows
    /// </summary>
    public class MediaPlayer : PropertyNotifyer, Serializes
    {
        public SlideShow NewSlideShow { get; private set; }
        public MediaAlbum Album { get; set; }

        /// <summary>
        /// Blir true ifall några mediafiler lagts till
        /// </summary>
        private bool hasMedia = false;

        public MediaPlayer()
        {
            Album = new MediaAlbum();
        }

        /// <summary>
        /// Lägger till en sökväg till en mediafil. Kontroll görs att inga dubbletter läggs till.
        /// </summary>
        public void AddImagePath(MediaFile imageToAdd)
        {
            if (imageToAdd == null)
                throw new ArgumentNullException("imageToAdd", "MediaFile is null");
            else
            {
                MediaFile copy = new MediaFile(imageToAdd);
                foreach (MediaFile image in Album.MediaFiles)
                {
                    if (image.ImagePath.Equals(copy.ImagePath))
                        return;
                }

                Album.MediaFiles.Add(copy);
                HasMedia = Album.MediaFiles.Count > 0;
            }
        }

        /// <summary>
        /// Rensar sökvägarna till mediafilerna
        /// </summary>
        public void Reset()
        {
            Album.MediaFiles.Clear();
            Album.Name = string.Empty;
            HasMedia = Album.MediaFiles.Count > 0;
        }

        /// <summary>
        /// Tar bort en sökväg till en mediafil
        /// </summary>
        public void RemoveImagePath(MediaFile imageToRemove)
        {
            if (imageToRemove == null)
                throw new ArgumentNullException("imageToAdd", "MediaFile is null");
            else
            {
                foreach (MediaFile mediafile in Album.MediaFiles)
                {
                    if (mediafile.Matches(imageToRemove))
                    {
                        Album.MediaFiles.Remove(mediafile);
                        break;
                    }
                }

                HasMedia = Album.MediaFiles.Count > 0;
            }
        }

        /// <summary>
        /// Sparar sökvägarna till fil
        /// </summary>
        public void Serialize(string fileName)
        {
            Serializer.XmlFileSerialize<ObservableCollection<MediaFile>>(fileName, Album.MediaFiles);
        }

        /// <summary>
        /// Laddar sökvägar från fil
        /// </summary>
        public void DeSerialize(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                ObservableCollection<MediaFile> temp = Serializer.XmlFileDeserialize<ObservableCollection<MediaFile>>(fileName);
                foreach (MediaFile image in temp)
                    Album.MediaFiles.Add(image);
            }

            HasMedia = Album.MediaFiles.Count > 0;
        }

        /// <summary>
        /// Skapar en ny slide show
        /// </summary>
        public void CreateSlideShow(int updateInterval)
        {
            NewSlideShow = new SlideShow(updateInterval, Album.MediaFiles);
        }

        public bool HasMedia
        {
            get { return hasMedia; }
            set
            {
                hasMedia = value;
                OnPropertyChanged();
            }
        }

    }
}
