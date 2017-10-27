using System.Collections.Generic;

namespace DynamicClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfFields = new List<Field>
            {
                new Field { FieldName = "FInt", FieldType = typeof(int) }
            };

            var o = MyTypeBuilder.CreateNewObject(listOfFields);
        }
    }
}
