#define TEST_SERIALIZE
#define TEST_DESERIALIZE

using System;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace TestSerializationI
{
	class Program
	{
		static void Main(string[] args)
		{
			string
                currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
				fileName;

		    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal));

			TestClass
				TestClass = null;

			TestClassesList
				TestClassesList = null;

			XmlSerializer
				x = null;

			#if TEST_SERIALIZE
                var tmpQuickBaseEditRecord = new QuickBaseEditRecord
                {
                    apptoken = "apptoken",
                    ticket = "ticket",
                    rid = 13,
                    udata = "udata",
                    fields = new[]
                    {
                        new QuickBaseEditRecordField { name ="field1", Value = "field1value" }, 
                        new QuickBaseEditRecordField { name ="field1", Value = "field1value" },
                        new QuickBaseEditRecordField { name ="field1", Value = "field1value" }
                    }
                };

                x = new XmlSerializer(tmpQuickBaseEditRecord.GetType());
                x.Serialize(Console.Out, tmpQuickBaseEditRecord);
                Console.WriteLine();
                Console.WriteLine();

                TestClass = new TestClass("Field1Value", "Field2Value", "Field3Value", "Field4Value", null, true);

				TestClass.Ints.Add(1);
				TestClass.Ints.Add(2);
				TestClass.Ints.Add(3);

				x = new XmlSerializer(TestClass.GetType());

				x.Serialize(Console.Out, TestClass);
				Console.WriteLine();
                Console.WriteLine();

				TestClassesList = new TestClassesList();

				TestClassesList.Add(TestClass);
		        TestClassesList.Add(TestClass);
                TestClassesList.Add(TestClass);
				x = new XmlSerializer(TestClassesList.GetType());
				x.Serialize(Console.Out, TestClassesList);
                Console.WriteLine();
                Console.WriteLine();

				if(File.Exists(fileName = Path.Combine(currentDirectory, "TestClassesList.out.xml")))
					File.Delete(fileName);

				StreamWriter
					sw = new StreamWriter(fileName, false, Encoding.UTF8);

				x.Serialize(sw, TestClassesList);

				sw.Close();

                TestClassWithCollection
                    TestClassWithCollection = new TestClassWithCollection();

                TestClassWithCollection.Collection.Add(TestClass);
                TestClassWithCollection.Collection.Add(TestClass);
                TestClassWithCollection.Collection.Add(TestClass);
                x = new XmlSerializer(TestClassWithCollection.GetType());
                x.Serialize(Console.Out, TestClassWithCollection);
                Console.WriteLine();
                Console.WriteLine();

            
                TestClassWithCollectionAndAttribute
                    TestClassWithCollectionAndAttribute = new TestClassWithCollectionAndAttribute();

                TestClassWithCollectionAndAttribute.Collection.Add(TestClass);
                TestClassWithCollectionAndAttribute.Collection.Add(TestClass);
                TestClassWithCollectionAndAttribute.Collection.Add(TestClass);
                x = new XmlSerializer(TestClassWithCollectionAndAttribute.GetType());
                x.Serialize(Console.Out, TestClassWithCollectionAndAttribute);
                Console.WriteLine();
                Console.WriteLine();
            #endif

			#if TEST_DESERIALIZE
                StreamReader
                    sr;

                fileName = Path.Combine(currentDirectory, "QuickBaseEditRecord.xml");
                sr = new StreamReader(fileName, Encoding.UTF8);
                x = new XmlSerializer(typeof(QuickBaseEditRecord));
		        var quickBaseEditRecord = (QuickBaseEditRecord)x.Deserialize(sr);

		        fileName = "Test.xml";
				sr = new StreamReader(fileName, Encoding.UTF8);
				x = new XmlSerializer(typeof(TestClassesList));

				TestClassesList = (TestClassesList)x.Deserialize(sr);

				TestClassesList.ForEach((item) => {
					Console.WriteLine(item.Field1);
					Console.WriteLine(item.Field2);
					item.Ints.ForEach((_item_) => {
						Console.WriteLine("\t"+_item_);
					});
                    Console.WriteLine();
				});
                Console.WriteLine();
			#endif

		    Console.ReadLine();
		}
	}
}
