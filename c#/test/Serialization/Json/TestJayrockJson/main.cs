//#define TEST_TO_STRING
//#define TEST_CONSTRUCTOR_COLLECTION
#define TEST_TYPES
//#define TEST_EMPTY_CONSTRUCTOR
//#define TEST_CONSTRUCTOR_DICTIONARY
//#define TEST_CONSTRUCTOR_STRING_OBJECT

using System;
using System.Collections.Generic;
using System.IO;
using Jayrock.Json;

namespace TestJayrockJson
{
	class Program
	{
		public enum TestEnum
		{
			Unknown = 0,
			First,
			Second,
			Third
		}

		static void Main(string[] args)
		{
			string
				FileName="log.log";

			if (File.Exists(FileName))
				File.Delete(FileName);

			StreamWriter
				file = new StreamWriter(FileName, true, System.Text.Encoding.GetEncoding(1251));

			JsonTextWriter
				tmpJsonTextWriter = new JsonTextWriter(file);

			JsonObject
				tmpJsonObject=null;

			JsonArray
				tmpJsonArray = null;

			#if TEST_TO_STRING
				tmpJsonObject = new JsonObject(new Dictionary<string, object> {
					{ "FInt", 1 },
					{ "FFloatF", 1.3 },
					{ "FFloatD", 1.3m },
					{ "FDate", DateTime.Now.Date },
					{ "FDateTime", DateTime.Now.Date },
					{ "FString", "\"as'df\\/ghj'kl\"" },
					{ "FBoolean", true }
				});

				Console.WriteLine(tmpJsonObject.ToString());
				tmpJsonObject = null;

				Console.WriteLine();

				tmpJsonArray = new JsonArray(new JsonArray[]{
					new JsonArray(new object[] { 1, 1.3, 1.3m, DateTime.Now.Date, DateTime.Now, "\"as'df\\/ghj'kl\"", true }),
					new JsonArray(new object[] { 1, 1.3, 1.3m, DateTime.Now.Date, DateTime.Now, "\"as'df\\/ghj'kl\"", true }),
					new JsonArray(new object[] { 1, 1.3, 1.3m, DateTime.Now.Date, DateTime.Now, "\"as'df\\/ghj'kl\"", true })
				});

				Console.WriteLine(tmpJsonArray.ToString());
				tmpJsonArray = null;
			#endif

			#if TEST_TYPES
				tmpJsonObject = new JsonObject();
				//tmpJsonObject = new JsonObject(new Dictionary<string, object> { { "LongValue", 13L }, { "ULongValue", 13UL } });

				tmpJsonObject.Put("LongValue", 13L);
				tmpJsonObject.Put("ULongValue", 13UL);
				tmpJsonObject.Accumulate("EnumValueFirst", TestEnum.First);
				tmpJsonObject.Accumulate("EnumValueSecond", TestEnum.Second);
				tmpJsonObject.Accumulate("EnumValueFirstInt", (int)TestEnum.First);
				tmpJsonObject.Accumulate("EnumValueSecondInt", (int)TestEnum.Second);

				decimal?
					DecimalWithNull = null,
					DecimalWithValue = 13;

				tmpJsonObject.Accumulate("DecimalWithNull", DecimalWithNull);
				tmpJsonObject.Accumulate("DecimalWithValue", DecimalWithValue);

				tmpJsonObject.Accumulate("DBNullValue", DBNull.Value);
			#endif

			#if TEST_EMPTY_CONSTRUCTOR
				tmpJsonObject = new JsonObject();

				tmpJsonObject.Accumulate("id","id");
				tmpJsonObject.Accumulate("text", "text");

				JsonArray
					tmpJsonArray = new JsonArray();

				for (int i = 0; i < 5; ++i)
				{
					JsonObject
						tmpTmpJsonObject = new JsonObject();

					tmpTmpJsonObject.Accumulate("id", "id" + i);
					tmpTmpJsonObject.Accumulate("text", i);
					tmpTmpJsonObject.Accumulate("Today",DateTime.Today);
					tmpTmpJsonObject.Accumulate("Now", DateTime.Now);
					tmpJsonArray.Add(tmpTmpJsonObject);
				}
				tmpJsonObject.Accumulate("children", tmpJsonArray);
			#endif

			#if TEST_CONSTRUCTOR_DICTIONARY
				tmpJsonObject = new JsonObject(new Dictionary<string, object> { { "success", true }, { "errors", new JsonObject(new Dictionary<string, object> { { "title", "Sounds like a Chick Flick" } }) }, { "errormsg", "That movie title sounds like a chick flick." } });
			#endif

			#if TEST_CONSTRUCTOR_STRING_OBJECT
				tmpJsonObject = new JsonObject(new string[] { "success", "errors", "errormsg" }, new object[] { true, new JsonObject(new string[] { "title" }, new object[] { "Sounds like a Chick Flick" }), "That movie title sounds like a chick flick." });
			#endif

			#if TEST_CONSTRUCTOR_COLLECTION
				tmpJsonArray = new JsonArray(new object[] { "1st", "2nd", "3rd" });
			#endif

			if (tmpJsonObject!=null)
				tmpJsonObject.Export(tmpJsonTextWriter);
			if (tmpJsonArray != null)
				tmpJsonArray.Export(tmpJsonTextWriter);

			tmpJsonTextWriter.Flush();
			tmpJsonTextWriter.Close();

			file.Flush();
			file.Close();
		}
	}
}
