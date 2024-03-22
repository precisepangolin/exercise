using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Display
    {
        public void PrintDatabase(List<ImportedObject> ImportedObjects)
        {
            foreach (var database in ImportedObjects.Where(obj => obj.Type == "DATABASE"))
            {
                Console.WriteLine($"Database '{database.Name}' ({database.NumberOfChildren} tables)");
                // print all database's tables
                foreach (var table in ImportedObjects.Where(table => table.ParentType.ToUpper() == database.Type && table.ParentName == database.Name))
                {
                    Console.WriteLine($"\tTable '{table.Schema}.{table.Name}' ({table.NumberOfChildren} columns)");
                    // print all table's columns
                    foreach (var column in ImportedObjects.Where(col => col.ParentType.ToUpper() == table.Type && col.ParentName == table.Name))
                    {
                        Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
