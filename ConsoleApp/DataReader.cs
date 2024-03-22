using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    public class DataReader
    {
        public List<ImportedObject> ImportedObjects(string fileToImport)
        {
            List<ImportedObject> importedObjects = new List<ImportedObject>();
            var importedLines = new List<string>();
            try
            {
                using (var streamReader = new StreamReader(fileToImport))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        importedLines.Add(line);
                    }

                    foreach (string importedLine in importedLines)
                    {
                        var values = importedLine.Split(';');
                        if (values.Count() == 7)
                        {
                            var importedObject = new ImportedObject
                            {
                                Type = values[0].Trim().ToUpper(),
                                Name = values[1].Trim(),
                                Schema = values[2].Trim(),
                                ParentName = values[3].Trim(),
                                ParentType = values[4].Trim(),
                                DataType = values[5].Trim(),
                                IsNullable = values[6].Trim()
                            };
                            importedObjects.Add(importedObject);
                        }
                    }

                    // assign number of children
                    foreach (var importedObject in importedObjects)
                    {
                        importedObject.NumberOfChildren = importedObjects.Count(impObj =>
                            impObj.ParentType == importedObject.Type && impObj.ParentName == importedObject.Name);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            return importedObjects;

        }
    }
}
