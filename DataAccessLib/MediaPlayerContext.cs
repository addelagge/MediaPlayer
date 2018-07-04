//Fredric Lagedal AH2318, 2017-10-05, Assignment 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MediaPlayerLib;

namespace DataAccessLib
{
    /// <summary>
    /// Klass som används för att kommunicera med databaser
    /// </summary>
    public class MediaPlayerContext : DbContext
    {
        public MediaPlayerContext() : base()
        {

        }

        public DbSet<MediaAlbum> MediaAlbums { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
    }
}
