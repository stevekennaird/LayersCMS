using System.IO;

namespace LayersCMS.Util.FileSystem
{
    /// <summary>
    /// A medium for storing and retrieving files
    /// </summary>
    public interface IFileStore
    {
        /// <summary>
        /// Save a file down
        /// </summary>
        /// <param name="fileStream">The file stream to save</param>
        /// <param name="originalFilename">The original filename</param>
        /// <returns>A string containing the new (unique) filename</returns>
        string SaveFile(Stream fileStream, string originalFilename);
        
        /// <summary>
        /// Retrieve a file from the file store
        /// </summary>
        /// <param name="filename">The filename to load the file for</param>
        /// <returns>A stream containing the file (if found, else null)</returns>
        Stream RetrieveFile(string filename);
    }
}