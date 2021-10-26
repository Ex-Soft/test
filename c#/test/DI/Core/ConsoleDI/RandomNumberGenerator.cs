namespace ConsoleDI
{
    public interface IRandomNumberGenerator
    {
        int Get();
    }

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int Get()
        {
            return 1;
        }
    }
}
