using System;
using System.Collections.Generic;
using Pfz.Threading;

namespace DictionaryAndLocksSample
{
    class DictionaryPlusSpinReaderWriterLockSlimAllowingDuplicatesSample:
        IGetOrCreateValueSample
    {
        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private readonly Func<int, int> _createValue;
        private SpinReaderWriterLockSlim _lock = new SpinReaderWriterLockSlim();

        public DictionaryPlusSpinReaderWriterLockSlimAllowingDuplicatesSample(Func<int, int> createValue)
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

            var createdResult = _createValue(i);

            _lock.EnterWriteLock();
            try
            {
                if (_dictionary.TryGetValue(i, out result))
                    return result;

                _dictionary.Add(i, createdResult);
            }
            finally
            {
                _lock.ExitWriteLock();
            }

            return createdResult;
        }


		public string Message
		{
			get
			{
				return "Dictionary+SpinReaderWriterLockSlim\t";
			}
		}
    }
}
