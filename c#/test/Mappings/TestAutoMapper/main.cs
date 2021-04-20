using System;
using AutoMapper;
using static System.Console;

namespace TestAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(typeof(AutoMapping));
                });
                var mapper = new Mapper(config);

                var class1src = new Class1Src { PInt = 1, PString = "Class1Src.PString", PDateTime = DateTime.Now };
                var class1dest = mapper.Map<Class1Dest>(class1src);

                var dateTime19700101 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                var dateTime = DateTime.UtcNow;
                var diff = dateTime - dateTime19700101;
                var class2src = new Class2Src { PInt = 1, PString = "Class1Src.PString", PDateTime = diff.TotalMilliseconds / 1000 };
                class1dest = mapper.Map<Class1Dest>(class2src);
                WriteLine($"{dateTime} {(dateTime.Equals(class1dest.PDateTime) ? "=" : "!")}= {class1dest.PDateTime}");

                var class3dest = mapper.Map<Class3Dest>(class1src);
                class3dest = mapper.Map<Class3Dest>(class2src);
            }
            catch (Exception eException)
            {
                WriteLine($"{eException.GetType().FullName}{Environment.NewLine}Message: {eException.Message}{Environment.NewLine}{(eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? $"InnerException.Message {eException.InnerException.Message}{Environment.NewLine}" : string.Empty)}StackTrace:{Environment.NewLine}{eException.StackTrace}");
            }
        }
    }
}
