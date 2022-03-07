namespace TextFilterLib
{
    public interface IFileReader
    {
        string Read(string path);
        bool IsFileExists(string path);

    }
}
