namespace ConsoleDI
{
    public interface ICallerWithSmthClass
    {
        SmthClass SmthClass { get; }
    }

    public class CallerWithSmthClass : ICallerWithSmthClass
    {
        private readonly SmthClass _smthClass;

        public CallerWithSmthClass(SmthClass smthClass)
        {
            _smthClass = smthClass;
        }

        public SmthClass SmthClass => _smthClass;
    }
}
