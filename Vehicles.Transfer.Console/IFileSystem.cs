using System.Collections.Generic;
using System.IO;

namespace Vehicles.Transfer.Console
{
    public interface IFileSystem
    {
        IEnumerable<string> GetFileNames(string directory);
        Stream GetFileStream(string fileName, FileMode mode);
    }
}
