﻿namespace ConsoleApp
{
    public class ImportedObject : ImportedObjectBaseClass
    {
        public string Schema;
        public string ParentName;
        public string ParentType { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }

        public double NumberOfChildren;
    }
}
