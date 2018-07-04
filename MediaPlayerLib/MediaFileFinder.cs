//Fredric Lagedal AH2318, 2017-09-19, Assignment 1

using System;
using System.Collections.Generic;
using System.IO;

namespace MediaPlayerLib
{
    /// <summary>
    /// Hjälpklass som bl a kan användas för att leta mediafiler
    /// </summary>
    public class MediaFileFinder
    {
        public const string emptyValueMessage = "value is empty";
        public const string nullValueMessage = "value is null";
        public static List<FileInfo> mediaFiles;

        /// <summary>
        /// Kontrollerar om det finns mediafiler som går att läsa bland en array av FileInfo filer.
        /// </summary>
        public static bool HasMediaFiles(FileInfo[] files)
        {
            if (files.Length == 0)
                return false;

            bool foundMediaFiles = false;
            mediaFiles = new List<FileInfo>();

            foreach (FileInfo file in files)
            {
                if (file.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;

                if (IsMediaFile(file))
                {
                    if (file.Length > 300000)
                    {
                        try
                        {
                            File.OpenRead(file.FullName); //Kontroll om filen går att läsa
                            mediaFiles.Add(file);
                            foundMediaFiles = true;
                        }
                        catch { }
                    }
                }
            }

            return foundMediaFiles;
        }

        /// <summary>
        /// Kontrollerar ifall en FileInfo fil är en media fil
        /// </summary>
        private static bool IsMediaFile(FileInfo file)
        {
            if (IsImage(file.FullName))
                return true;
                
            if (IsVideoClip(file.FullName))
                return true;

            return false;
        }

        /// <summary>
        /// Kontrollerar en sökväg till en fil och avgör om den är en bildfil.
        /// </summary>
        public static bool IsImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                if (filePath == null)
                    throw new ArgumentException(nullValueMessage, "filePath");
                else
                    throw new ArgumentException(emptyValueMessage, "filePath");
            }
            else
            {
                if (filePath.EndsWith(".jpg"))
                    return true;
                if (filePath.EndsWith(".png"))
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Kontrollerar en sökväg till en fil och avgör om det är ett vidoklipp.
        /// </summary>
        public static bool IsVideoClip(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                if (filePath == null)
                    throw new ArgumentException(nullValueMessage, "filePath");
                else
                    throw new ArgumentException(emptyValueMessage, "filePath");
            }
            else
            {
                if (filePath.EndsWith(".avi"))
                    return true;
                if (filePath.EndsWith(".mpg"))
                    return true;
                if (filePath.EndsWith(".mp4"))
                    return true;

                return false;
            }
        }

    }
}
