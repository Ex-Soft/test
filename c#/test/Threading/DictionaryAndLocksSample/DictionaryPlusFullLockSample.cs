using System;
using System.Collections.Generic;

namespace DictionaryAndLocksSample
{
    class DictionaryPlusFullLockSample:
        IGetOrCreateValueSample
    {
        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private readonly Func<int, int> _createValue;

        public DictionaryPlusFullLockSample(Func<int, int> createValue)
        {
            _createValue = createValue;
        }

        public int GetOrCreate(int i)
        {
            int result;
            lock(_dictionary)
            {
                if (_dictionary.TryGetValue(i, out result))
                    return result;

                result = _createValue(i);
                _dictionary.Add(i, result);
                return result;
            }
        }

		public string Message
		{
			get
			{
				return "Dictionary+FullLock\t\t\t";
			}
		}
    }
}
