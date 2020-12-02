using System.Collections.Generic;
using System.IO;

namespace Vehicles.Transfer.Console
{
    public class FileSystem : IFileSystem
    {
        public IEnumerable<string> GetFileNames(string directory)
        {
            return Directory.EnumerateFiles(directory);
        }

        public Stream GetFileStream(string fileName, FileMode mode)
        {
            return new FileStream(fileName, mode);
        }
    }
}
