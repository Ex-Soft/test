using System;
using System.Collections.Generic;
using Pfz.Threading;

namespace DictionaryAndLocksSample
{
    class DictionaryPlusSpinReaderWriterLockSlimSample:
        IGetOrCreateValueSample
    {
        private readonly Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        private readonly Func<int, int> _createValue;
        private SpinReaderWriterLockSlim _lock = new SpinReaderWriterLockSlim();

        public DictionaryPlusSpinReaderWriterLockSlimSample(Func<int, int> createValue)
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

            bool upgraded = false;
            _lock.EnterUpgradeableLock();
            try
            {
                if (_dictionary.TryGetValue(i, out result))
                    return result;

                result = _createValue(i);
                
                _lock.UpgradeToWriteLock(ref upgraded);

                _dictionary.Add(i, result);
            }
            finally
            {
                _lock.ExitUpgradeableLock(upgraded);
            }

            return result;
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
