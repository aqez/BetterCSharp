using System.Collections.Generic;
using System.IO;

namespace Vehicles.Transfer.Console
{
    public interface IFileSystem
    {
        IEnumerable<string> GetFileNames(string directory);
        Stream GetFileStream(string fileName);
    }

    public class FileSystem : IFileSystem
    {
        public IEnumerable<string> GetFileNames(string directory)
        {
            return Directory.EnumerateFiles(directory);
        }

        public Stream GetFileStream(string fileName)
        {
            return new FileStream(fileName, FileMode.Open);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFileSystem provider = new FileSystem();

            foreach (var fileName in provider.GetFileNames("input"))
            {
                System.Console.WriteLine(fileName);
            }
        }
    }
}
