using System;
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
            var type = o.GetType();
            var myType = Type.GetType("MyDynamicType");
            myType = Type.GetType("MyDynamicType.MyDynamicType");
            var o2 = MyTypeBuilder.CreateNewObject(listOfFields);
        }
    }
}
