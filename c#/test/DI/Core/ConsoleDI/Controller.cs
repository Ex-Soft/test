using System;

namespace ConsoleDI
{
    public interface IController
    {
        int Get();
    }

    public class Controller : IController
    {
        private readonly Func<IRandomNumberGenerator> _numberGeneratorFactory;

        public Controller(Func<IRandomNumberGenerator> numberGeneratorFactory)
        {
            _numberGeneratorFactory = numberGeneratorFactory;
        }

        public int Get()
        {
            IRandomNumberGenerator generator = _numberGeneratorFactory();
            return generator.Get();
        }
    }
}
