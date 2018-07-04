//Fredric Lagedal AH2318, 2017-10-05, Assignment 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaPlayerLib;
using System.Collections.ObjectModel;

namespace DataAccessLib
{
    /// <summary>
    /// Klass som hanterar kommunikation med databasen
    /// </summary>
    public class DataAccessHandler
    {
        /// <summary>
        /// Uppdaterar det aktuella albument i databasen
        /// </summary>
        public void UpdateAlbum(MediaAlbum updatedAlbum)
        {
            using (var db = new MediaPlayerContext())
            {
                MediaAlbum existingAlbum = GetPointerToAlbum(updatedAlbum.Name, db);
                if (existingAlbum != null)
                {
                    MatchExistingAlbumToUpdated(existingAlbum, updatedAlbum, db);
                    CopyFileDescriptions(existingAlbum, updatedAlbum, db);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Tar bort och lägger till filer från albument i databasen så att det matchar albumet som ska sparas
        /// </summary>
        /// <param name="Albumet som finns lagrat i databasen"></param>
        /// <param name="Albumet som ska sparas"></param>
        private void MatchExistingAlbumToUpdated(MediaAlbum existingAlbum, MediaAlbum updatedAlbum, MediaPlayerContext db)
        {
            foreach (MediaFile file in updatedAlbum.MediaFiles)
            {
                if (!IsInList(file, existingAlbum.MediaFiles))
                    existingAlbum.MediaFiles.Add(file);
            }

            foreach (MediaFile file in existingAlbum.MediaFiles)
            {
                if (!IsInList(file, updatedAlbum.MediaFiles))
                {
                    RemoveMediaFile(file, db);
                    break;
                }
            }
        }

        /// <summary>
        /// Kopierar mediafilernas Description från albumet som ska sparas till det som finns lagrat i databasen
        /// </summary>
        /// <param name="existingAlbum"></param>
        /// <param name="updatedAlbum"></param>
        private void CopyFileDescriptions(MediaAlbum existingAlbum, MediaAlbum updatedAlbum, MediaPlayerContext db)
        {
            foreach(MediaFile updatedFile in updatedAlbum.MediaFiles)
            {
                foreach(MediaFile oldFile in existingAlbum.MediaFiles)
                {
                    if(oldFile.Matches(updatedFile))
                    {
                        oldFile.Description = updatedFile.Description;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Tar bort en MediaFile från databasen
        /// </summary>
        private void RemoveMediaFile(MediaFile file, MediaPlayerContext db)
        {
            var query = db.MediaFiles.Where(x => x.FileName.ToLower().Equals(file.FileName.ToLower())).Where(x => x.Album.Name.ToLower().Equals(file.Album.Name.ToLower()));
            //var query = from mediaFile in db.MediaFiles
            //            where mediaFile.FileName.ToLower().Equals(file.FileName.ToLower())
            //            where mediaFile.Album.Name.ToLower().Equals(file.Album.Name.ToLower())
            //            select mediaFile;

            if (query.ToArray().Length == 1)
            {
                MediaFile fileToRemove = (MediaFile)query.ToArray()[0];
                db.MediaFiles.Remove(fileToRemove);
            }
        }

        /// <summary>
        /// Kontrollerar om en MediaFile finns i en samling MediaFiles
        /// </summary>
        private bool IsInList(MediaFile file, ICollection<MediaFile> mediaFiles)
        {
            foreach(MediaFile mediaFile in mediaFiles)
            {
                if (mediaFile.Matches(file))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returnerar namnen på de album som finns lagrade i databasen
        /// </summary>
        public List<string> GetAlbumNames()
        {
            List<string> names = new List<string>();
            using(var db = new MediaPlayerContext())
            {
                foreach(MediaAlbum album in db.MediaAlbums.ToArray())
                    names.Add(album.Name);

                return names;
            }
        }

        /// <summary>
        /// Returnerar en lista med kopior av alla MediaFiles som finns i ett album i databasen
        /// </summary>
        public List<MediaFile> GetFilesFromAlbum(string albumName)
        {
            List<MediaFile> files = new List<MediaFile>();
            using (var db = new MediaPlayerContext())
            {
                MediaAlbum album = GetPointerToAlbum(albumName, db);
                if(album != null)
                {
                    foreach (MediaFile file in album.MediaFiles)
                        files.Add(new MediaFile(file));
                }
            }

            return files;
        }

        /// <summary>
        /// Lägger till ett nytt album till databasen
        /// </summary>
        public void AddNewAlbum(MediaAlbum album)
        {
            using (var db = new MediaPlayerContext())
            {
                db.MediaAlbums.Add(album);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Kontrollerar om det finns ett album med samma namn som metodparametern i databasen
        /// </summary>
        public bool AlbumExists(string albumName)
        {
            using(var db = new MediaPlayerContext())
            {
                MediaAlbum album = GetPointerToAlbum(albumName, db);
                if (album != null)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Retunererar en pekare till ett album i databasen
        /// </summary>
        private MediaAlbum GetPointerToAlbum(string albumName, MediaPlayerContext db)
        {
            var query = db.MediaAlbums.Where(album => album.Name.ToLower().Equals(albumName.ToLower()));

            if (query.ToArray().Length == 1)
                return query.ToArray()[0];

            return null;
        }

        /// <summary>
        /// Tar bort ett album ur databasen
        /// </summary>
        public void DeleteAlbum(string albumName)
        {
            using (var db = new MediaPlayerContext())
            {
                MediaAlbum albumToRemove = GetPointerToAlbum(albumName, db);
                if(albumToRemove != null)
                {
                    db.MediaAlbums.Remove(albumToRemove);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Ändrar namnet på ett album i databasen
        /// </summary>
        public void ChangeAlbumName(MediaAlbum album, string newName)
        {
            using (var db = new MediaPlayerContext())
            {
                album = GetPointerToAlbum(album.Name, db);
                if (album != null)
                {
                    album.Name = newName;
                    db.SaveChanges();
                }
            }
        }
    }
}
