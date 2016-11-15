using System;
using Pfz.Collections;

namespace DictionaryAndLocksSample
{
    class ThreadSafeDictionarySample:
        IGetOrCreateValueSample
    {
        private readonly ThreadSafeDictionary<int, int> _dictionary = new ThreadSafeDictionary<int, int>();
        private readonly Func<int, int> _createValue;

        public ThreadSafeDictionarySample(Func<int, int> createValue)
        {
            _createValue = createValue;
        }

        public int GetOrCreate(int i)
        {
            return _dictionary.GetOrCreateValue(i, _createValue);
        }


		public string Message
		{
			get
			{
				return "ThreadSafeDictionary\t\t\t";
			}
		}
    }
}
