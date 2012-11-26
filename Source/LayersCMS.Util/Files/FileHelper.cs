using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LayersCMS.Util.Files
{

    /// <summary>
    /// A collection of helpful utility methods for dealing with files
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Remove invalid characters from the given filename and replace them with dashes
        /// to return a standardised filename.
        /// </summary>
        public virtual String StandardiseFilename(String filename)
        {
            if (String.IsNullOrWhiteSpace(filename)) throw new ArgumentNullException("filename");

            String fileNameOnly = Path.GetFileNameWithoutExtension(filename);
            String extension = Path.GetExtension(filename);

            // Get the collection of invalid filename characters
            char[] invalidCharacters = Path.GetInvalidFileNameChars();
            
            if (fileNameOnly != null)
            {
                var sb = new StringBuilder();

                // Loop through each character in the filename, and replace any
                // invalid characters with a single dash character
                foreach (char c in fileNameOnly)
                {
                    if (invalidCharacters.Contains(c) || c == ' ')
                    {
                        sb.Append("-");
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }

                return String.Format("{0}{1}", sb, extension);
            }
            else
            {
                throw new Exception("The filename parameter is not a valid filename, in the name.ext format");
            }
        }

        /// <summary>
        /// Returns a valid, unique filename for the given folder
        /// </summary>
        /// <param name="filename">The desired filename</param>
        /// <param name="folderPath">The folder to search in to determine the uniqueness of the filename</param>
        /// <param name="standardiseFilename">Whether or not to standardise the filename (remove invalid characters and replace whitespace with dashes)</param>
        public virtual String GenerateUniqueFilename(String filename, String folderPath, Boolean standardiseFilename = true)
        {
            if (filename == null) throw new ArgumentNullException("filename");
            if (folderPath == null) throw new ArgumentNullException("folderPath");

            // Standardise the filename, if required
            if (standardiseFilename)
                filename = StandardiseFilename(filename);

            // Get the filename parts
            String fileNameNoExt = Path.GetFileNameWithoutExtension(filename);
            String fileExt = Path.GetExtension(filename);

            // Set the start values for the while loop
            String loopFilename = filename;
            Int32 loopCount = 1;

            // While a filename match is found for the constructed filename,
            // append an incrementing integer value until no match can be found
            try
            {
                while (File.Exists(Path.Combine(folderPath, loopFilename)))
                {
                    loopFilename = String.Format("{0}-{1}{2}", fileNameNoExt, loopCount, fileExt);
                    loopCount++;

                    // Should be unnecessary, but safety first to prevent an infinite loop!
                    if (loopCount > 10000)
                        throw new Exception("More than 10000 iterations in an attempt to find an unique filename.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to create an unique filename for the given folder.", e);
            }

            return loopFilename;
        }
    }
}
