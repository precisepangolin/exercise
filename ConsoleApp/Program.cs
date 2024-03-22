using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new DataReader();
            Display display = new Display();
            List<ImportedObject> importedObjects = reader.ImportedObjects("data.csv");
            display.PrintDatabase(importedObjects);
        }
    }
}
