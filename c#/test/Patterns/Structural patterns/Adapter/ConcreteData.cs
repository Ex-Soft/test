namespace Adapter
{
    public interface ISourceData { string Message { get; set; } }
    public class SourceData : ISourceData { public string Message { get; set; } }

    public interface ISource { ISourceData Fetch(); }
    
    public interface IConcreteData1 { string PString1 { get; set; } }
    public class ConcreteData1 : IConcreteData1 { public string PString1 { get; set; } }
    public interface IConcreteData2 { string PString2 { get; set; } }
    public class ConcreteData2 : IConcreteData2 { public string PString2 { get; set; } }

    public class Source1 : ISource
    {
        private readonly AdapterSource1 _adapter;

        public Source1(AdapterSource1 adapter)
        {
            _adapter = adapter;
        }

        public ISourceData Fetch()
        {
            IConcreteData1 concreteData1 = new ConcreteData1();
            return _adapter.Convert(concreteData1);
        }
    }

    public class AdapterSource1
    {
        public ISourceData Convert(IConcreteData1 concreteData1)
        {
            return new SourceData { Message = concreteData1.PString1 };
        }
    }

    public class Source2 : ISource
    {
        private readonly AdapterSource2 _adapter;

        public Source2(AdapterSource2 adapter)
        {
            _adapter = adapter;
        }

        public ISourceData Fetch()
        {
            IConcreteData2 concreteData2 = new ConcreteData2();
            return _adapter.Convert(concreteData2);
        }
    }

    public class AdapterSource2
    {
        public ISourceData Convert(IConcreteData2 concreteData2)
        {
            return new SourceData { Message = concreteData2.PString2 };
        }
    }

    public class ConcreteData
    {
        public static void Run()
        {
            ISource source = new Source1(new AdapterSource1());
            ISourceData data = source.Fetch();

            source = new Source2(new AdapterSource2());
            data = source.Fetch();
        }
    }
}
