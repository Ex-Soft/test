namespace ClassLibrary2
{
    public sealed class Singleton
    {
        static Singleton()
        {}

        private Singleton()
        {}

        public static Singleton Instance { get; } = new Singleton();

        public ISmthInterface SmthExecutor { get; set; }
    }
}
