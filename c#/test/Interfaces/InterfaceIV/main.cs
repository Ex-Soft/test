using System;

namespace InterfaceIV
{
    public class Info
    {
        public Info() : this(string.Empty)
        {}

        public Info(Info obj) : this(obj.Data)
        {}

        public Info(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
    }

    public interface IInfoBaseRepositary
    {
        void DoSmthFromIInfoBaseRepositary(Info info);
    }

    public interface IInfoSpecificRepositary
    {
        void DoSmthFromIInfoSpecificRepositary(Info info);
    }

    public abstract class InfoBaseRepository : IInfoBaseRepositary
    {
        public abstract string FileName { get; set; }

        public void DoSmthFromInfoBaseRepository(Info info)
        {
            Console.WriteLine(string.Format("DoSmthFromInfoBaseRepository(): FileName: {0}, Data: {1}", FileName, info.Data));
        }

        public void DoSmthFromIInfoBaseRepositary(Info info)
        {
            Console.WriteLine(string.Format("DoSmthFromIInfoBaseRepositary(): FileName: {0}, Data: {1}", FileName, info.Data));
        }

        public void DoSmthFromIInfoSpecificRepositary(Info info)
        {
            Console.WriteLine(string.Format("DoSmthFromIInfoSpecificRepositary(): FileName: {0}, Data: {1}", FileName, info.Data));
        }
    }

    public class Info1Repository : InfoBaseRepository
    {
        public Info1Repository() : this(string.Empty)
        {}

        public Info1Repository(Info1Repository obj) : this(obj.FileName)
        {}

        public Info1Repository(string fileName)
        {
            FileName = fileName;
        }

        public override string FileName { get; set; }
    }

    public class Info2Repository : InfoBaseRepository
    {
        public Info2Repository() : this(string.Empty)
        {}

        public Info2Repository(Info2Repository obj) : this(obj.FileName)
        {}

        public Info2Repository(string fileName)
        {
            FileName = fileName;
        }

        public override string FileName { get; set; }
    }

    public class Info3Repository : InfoBaseRepository, IInfoSpecificRepositary
    {
        public Info3Repository() : this(string.Empty)
        {}

        public Info3Repository(Info2Repository obj) : this(obj.FileName)
        {}

        public Info3Repository(string fileName)
        {
            FileName = fileName;
        }

        public override string FileName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Info
                info = new Info("Info");

            Info1Repository
                info1Repository = new Info1Repository("Info1Repository");

            Info2Repository
                info2Repository = new Info2Repository("Info2Repository");

            Info3Repository
                info3Repository = new Info3Repository("Info3Repository");

            info1Repository.DoSmthFromInfoBaseRepository(info);
            info1Repository.DoSmthFromIInfoBaseRepositary(info);
            Console.WriteLine();

            info2Repository.DoSmthFromInfoBaseRepository(info);
            info2Repository.DoSmthFromIInfoBaseRepositary(info);
            Console.WriteLine();
            info3Repository.DoSmthFromInfoBaseRepository(info);
            info3Repository.DoSmthFromIInfoBaseRepositary(info);
            info3Repository.DoSmthFromIInfoSpecificRepositary(info);
            Console.WriteLine();

            InfoBaseRepository
                infoBaseRepository;

            IInfoBaseRepositary
                iInfoBaseRepositary;

            IInfoSpecificRepositary
                iInfoSpecificRepositary;

            infoBaseRepository = info1Repository;
            if ((iInfoBaseRepositary = infoBaseRepository as IInfoBaseRepositary) != null)
                iInfoBaseRepositary.DoSmthFromIInfoBaseRepositary(info);
            if ((iInfoSpecificRepositary = infoBaseRepository as IInfoSpecificRepositary) != null)
                iInfoSpecificRepositary.DoSmthFromIInfoSpecificRepositary(info);
            Console.WriteLine();

            infoBaseRepository = info2Repository;
            if ((iInfoBaseRepositary = infoBaseRepository as IInfoBaseRepositary) != null)
                iInfoBaseRepositary.DoSmthFromIInfoBaseRepositary(info);
            if ((iInfoSpecificRepositary = infoBaseRepository as IInfoSpecificRepositary) != null)
                iInfoSpecificRepositary.DoSmthFromIInfoSpecificRepositary(info);
            Console.WriteLine();

            infoBaseRepository = info3Repository;
            if ((iInfoBaseRepositary = infoBaseRepository as IInfoBaseRepositary) != null)
                iInfoBaseRepositary.DoSmthFromIInfoBaseRepositary(info);
            if ((iInfoSpecificRepositary = infoBaseRepository as IInfoSpecificRepositary) != null)
                iInfoSpecificRepositary.DoSmthFromIInfoSpecificRepositary(info);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
