using System;

using DatabaseAssignment.Core;

namespace DatabaseAssignment.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file path of the regions file:");
            string filePath = Console.ReadLine();

            var regionDbHandler = new RegionDbHandler();
            regionDbHandler.TransferRegionsFromFileToDb(filePath);
        }
    }
}
