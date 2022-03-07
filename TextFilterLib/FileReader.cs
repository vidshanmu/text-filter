using System.IO;

namespace TextFilterLib
{
    public class FileReader : IFileReader
    {
       
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public bool IsFileExists(string path)
        {
            return File.Exists(path);
        }

    }

}
