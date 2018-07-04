//Fredric Lagedal AH2318, 2017-10-05, Assignment 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerLib;
using DataAccessLib;

namespace BusinessDataRepository
{
    /// <summary>
    /// Klass som fungerar som mellanlagring av metoder för att kommunicera med databasen
    /// </summary>
    public class Repository
    {
        private DataAccessHandler dbHandler = new DataAccessHandler();

        public bool AlbumExists(string albumName)
        {
            return dbHandler.AlbumExists(albumName);
        }

        public void AddNewAlbum(MediaAlbum album)
        {
            dbHandler.AddNewAlbum(album);
        }

        public void UpdateAlbum(MediaAlbum album)
        {
            dbHandler.UpdateAlbum(album);
        }

        public void DeleteAlbum(string albumName)
        {
            dbHandler.DeleteAlbum(albumName);
        }

        public void ChangeAlbumName(MediaAlbum album, string newName)
        {
            dbHandler.ChangeAlbumName(album, newName);
        }

        public List<string> GetAlbumNames()
        {
            return dbHandler.GetAlbumNames();
        }

        public List<MediaFile> GetFilesFromAlbum(string fileName)
        {
            return dbHandler.GetFilesFromAlbum(fileName);
        }
    }
}
