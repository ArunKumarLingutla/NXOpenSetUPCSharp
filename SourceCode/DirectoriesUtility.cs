using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXOpenSetUPCSharp
{
    public class DirectoriesUtility
    {
        /// <summary>
        /// Deletes all files in the specified directory.
        /// </summary>
        /// <param name="directory">Directory whose files are to be deleted.</param>
        public static void DeleteFilesInDirectory(string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                // You can optionally log or rethrow depending on your handling policy
                NXLogger.Instance?.Log($"Error deleting files: {ex.Message}");
            }
        }
    }
}
