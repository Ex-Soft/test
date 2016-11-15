using System;
using System.Collections.Concurrent;

namespace DictionaryAndLocksSample
{
    class ConcurrentDictionarySample:
        IGetOrCreateValueSample
    {
        private readonly ConcurrentDictionary<int, int> _dictionary = new ConcurrentDictionary<int, int>();
        private readonly Func<int, int> _createValue;

        public ConcurrentDictionarySample(Func<int, int> createValue)
        {
            _createValue = createValue;
        }

        public int GetOrCreate(int i)
        {
            return _dictionary.GetOrAdd(i, _createValue);
        }


		public string Message
		{
			get
			{
				return "ConcurrentDictionary\t\t\t";
			}
		}
    }
}
