using System;
using System.Collections.Generic;

namespace DictionaryAndLocksSample
{
    class DictionaryPlusFullLockSampleAllowingDuplicates:
        IGetOrCreateValueSample
    {
        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private readonly Func<int, int> _createValue;

        public DictionaryPlusFullLockSampleAllowingDuplicates(Func<int, int> createValue)
        {
            _createValue = createValue;
        }

        public int GetOrCreate(int i)
        {
            int result;
            lock(_dictionary)
                if (_dictionary.TryGetValue(i, out result))
                    return result;

			int createdResult = _createValue(i);
			lock(_dictionary)
			{
				if (_dictionary.TryGetValue(i, out result))
					return result;

				_dictionary.Add(i, createdResult);
			}
			return createdResult;
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
