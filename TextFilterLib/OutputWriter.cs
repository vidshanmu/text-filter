using System;

namespace TextFilterLib
{
    public class OutputWriter : IOutputWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
