//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System;
using UtilitiesLib;

namespace MediaPlayerLib
{
    /// <summary>
    /// Klass som representerar en mediafil.
    /// </summary>
    public class MediaFile : PropertyNotifyer
    {
        public int MediaFileId { get; set; }

        /// <summary>
        /// Namnet på filen
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Sökvägen till filen
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Beksrivningen av filen
        /// </summary>
        private string description;

        public int MediaAlbumId { get; set; }
        public virtual MediaAlbum Album { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MediaFile()
        {
            description = string.Empty;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        public MediaFile(MediaFile fileToCopy)
        {
            FileName = fileToCopy.FileName;
            ImagePath = fileToCopy.ImagePath;
            Description = fileToCopy.Description;
        }

        public override string ToString()
        {
            return FileName + " " + ImagePath;
        }

        public bool Matches(MediaFile file)
        {
            if(file == null)
            {
                throw new ArgumentNullException("file", "Mediafile is null");
            }
            else
            {
                if (ImagePath.Equals(file.ImagePath))
                    return true;

                return false;
            }
        }


        //Properties
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
    }
}
