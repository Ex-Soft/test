using System;
using System.Collections.Generic;
using System.Threading;

namespace DictionaryAndLocksSample
{
    class DictionaryPlusReaderWriterLockSlimSample:
        IGetOrCreateValueSample
    {
        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private readonly Func<int, int> _createValue;

        public DictionaryPlusReaderWriterLockSlimSample(Func<int, int> createValue)
        {
            _createValue = createValue;
        }

        public int GetOrCreate(int i)
        {
            int result;
            _lock.EnterReadLock();
            try
            {
                if (_dictionary.TryGetValue(i, out result))
                    return result;
            }
            finally
            {
                _lock.ExitReadLock();
            }

            _lock.EnterUpgradeableReadLock();
            try
            {
                if (_dictionary.TryGetValue(i, out result))
                    return result;

                result = _createValue(i);
                _lock.EnterWriteLock();
                try
                {
                    _dictionary.Add(i, result);
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }

            return result;
        }


		public string Message
		{
			get
			{
				return "Dictionary+ReaderWriterLockSlim\t\t";
			}
		}
    }
}
