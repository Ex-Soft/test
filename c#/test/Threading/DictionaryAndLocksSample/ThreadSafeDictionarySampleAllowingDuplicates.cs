using System;
using Pfz.Collections;

namespace DictionaryAndLocksSample
{
    class ThreadSafeDictionarySampleAllowingDuplicates:
        IGetOrCreateValueSample
    {
        private readonly ThreadSafeDictionary<int, int> _dictionary = new ThreadSafeDictionary<int, int>();
        private readonly Func<int, int> _createValue;

        public ThreadSafeDictionarySampleAllowingDuplicates(Func<int, int> createValue)
        {
            _createValue = createValue;
        }

        public int GetOrCreate(int i)
        {
            return _dictionary.GetOrCreateDiscardableValue(i, _createValue);
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
