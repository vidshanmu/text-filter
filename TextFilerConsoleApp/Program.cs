using System;
using System.IO;
using TextFilterLib;
using Microsoft.Extensions.DependencyInjection;

namespace TextFilerConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DI
            var serviceProvider = new ServiceCollection()
             .AddScoped<IFilterProvider, FilterProvider>()
             .AddScoped<IFileReader, FileReader>()
             .AddScoped<IOutputWriter, OutputWriter>()
             .AddScoped<ITextProcessor, TextProcessor>()
             .BuildServiceProvider();

            var textProcessor = serviceProvider.GetService<ITextProcessor>();

            //Read File
            Console.Clear();
            Console.WriteLine("Enter the full path of the file:");
            var filePath = Console.ReadLine();

            try
            {
                //Process text
                textProcessor.ProcessText(filePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
