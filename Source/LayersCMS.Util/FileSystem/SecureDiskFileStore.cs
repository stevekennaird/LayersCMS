using System;
using System.Configuration;
using System.IO;

namespace LayersCMS.Util.FileSystem
{
    /// <summary>
    /// A file store that stores files away from the website folder (for security)
    /// </summary>
    public class SecureDiskFileStore : IFileStore
    {
        #region Constructor

        public SecureDiskFileStore()
        {
            _folderLocation = ConfigurationManager.AppSettings["SecureDiskFileStoreLocalPath"];
            if (string.IsNullOrWhiteSpace(_folderLocation))
            {
                throw new Exception("AppSetting missing for SecureDiskFileStoreLocalPath");
            }
        }

        private readonly string _folderLocation;

        #endregion

        #region Saving

        public string SaveFile(Stream fileStream, string originalFilename)
        {
            if (fileStream == null) throw new ArgumentNullException("fileStream");
            if (originalFilename == null) throw new ArgumentNullException("originalFilename");

            // Get a unique filename
            string newFilePath = GetUniqueFilePath(originalFilename);

            // Save the file to the disk with the unique filename
            SaveToDisk(fileStream, newFilePath);

            //Return the new unique filename
            return Path.GetFileName(newFilePath);
        }

        private string GetUniqueFilePath(string filename)
        {
            string filePath = Path.Combine(_folderLocation, filename);
            var fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {
                for (int i = 1; i < 10001; i++)
                {
                    string newFilename = string.Format("{0}-{1}{2}", Path.GetFileNameWithoutExtension(filename), i, Path.GetExtension(filename));
                    filePath = Path.Combine(_folderLocation, newFilename);
                    fileInfo = new FileInfo(filePath);

                    if (!fileInfo.Exists)
                    {
                        break;
                    }

                    if (i == 10000)
                    {
                        throw new Exception("Possible recursion error when attempting to create a unique filename");
                    }
                }    
            }

            return filePath;
        }

        private void SaveToDisk(Stream stream, string filePath)
        {
            // Create the file
            using (var fileStream = File.Create(filePath, (int) stream.Length))
            {
                // Initialize the bytes array with the stream length and then fill it with data
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);
                // Use write method to write to the specified file
                fileStream.Write(bytesInStream, 0, (int)bytesInStream.Length);    
            }
        }

        #endregion

        #region Loading/Retrieval

        public Stream RetrieveFile(string filename)
        {
            if (filename == null) throw new ArgumentNullException("filename");

            string filePath = Path.Combine(_folderLocation, filename);

            if (File.Exists(filePath))
            {
                return new FileStream(filePath, FileMode.Open, FileAccess.Read);
            }

            return null;
        }

        #endregion
    }
}
