
namespace Pfz.Collections
{
	internal static class _DictionaryHelper
	{
        internal static int _AdaptLength(int newLength)
        {
            if (newLength <= 31)
                newLength = 31;

            if (newLength % 2 == 0)
                newLength--;
            else
                newLength -= 2;

            while (true)
            {
                newLength += 2;

                if (newLength % 3 == 0)
                    continue;

                if (newLength % 5 == 0)
                    continue;

                if (newLength % 7 == 0)
                    continue;

                if (newLength % 11 == 0)
                    continue;

                if (newLength % 13 == 0)
                    continue;

                if (newLength % 17 == 0)
                    continue;

                if (newLength % 19 == 0)
                    continue;

                if (newLength % 29 == 0)
                    continue;

                if (newLength % 31 == 0)
                    continue;

                return newLength;
            }
        }
    }
}
