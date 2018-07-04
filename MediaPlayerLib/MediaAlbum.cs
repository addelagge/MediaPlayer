//Fredric Lagedal AH2318, 2017-10-05, Assignment 2

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesLib;

namespace MediaPlayerLib
{
    /// <summary>
    /// Klass som representerar ett media album
    /// </summary>
    public class MediaAlbum : PropertyNotifyer
    {
        //Id
        public int MediaAlbumId { get; set; }
        private string name;
        public DateTime DateCreated { get; set; }
        
        //Navigational property
        public virtual ObservableCollection<MediaFile> MediaFiles { get; set; }

        public MediaAlbum()
        {
            MediaFiles = new ObservableCollection<MediaFile>();
            Name = string.Empty;
        }


        public bool ContainsFile(MediaFile file)
        {
            if (file == null)
                throw new ArgumentNullException("file", "Mediafile is null");
            else
            {
                foreach (MediaFile mediaFile in MediaFiles)
                {
                    if (mediaFile.Matches(file))
                        return true;
                }

                return false;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }
}
