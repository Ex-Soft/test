namespace TestTemplate
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }

#if (EnableType)
        public TestType Type { get; set; }
#endif

        public override string ToString()
        {
#if (EnableType)
            return $"{{Id:{Id}, Type:{Type.ToString()}, Name:\"{Name}\"}}";
#else
            return $"{{Id:{Id}, Name:\"{Name}\"}}";
#endif
        }
    }
}
