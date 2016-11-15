using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryAndLocksSample
{
    class AllSamples
    {
		private IGetOrCreateValueSample[] _dictionariesNoDuplicates;
		private IGetOrCreateValueSample[] _dictionariesDuplicates;


        private readonly bool _singleUse;
        internal AllSamples(bool singleUse, Func<int, int> createValue)
        {
            _singleUse = singleUse;

			_dictionariesNoDuplicates = 
				new IGetOrCreateValueSample[]
				{
					new DictionaryPlusFullLockSample(createValue),
					new DictionaryPlusReaderWriterLockSlimSample(createValue),
					new DictionaryPlusSpinReaderWriterLockSlimSample(createValue),
					new ThreadSafeDictionarySample(createValue)
				};

			_dictionariesDuplicates = 
				new IGetOrCreateValueSample[]
				{
					new DictionaryPlusFullLockSampleAllowingDuplicates(createValue),
					new DictionaryPlusReaderWriterLockSlimSampleAllowingDuplicates(createValue),
					new DictionaryPlusSpinReaderWriterLockSlimAllowingDuplicatesSample(createValue),
					new ThreadSafeDictionarySampleAllowingDuplicates(createValue),
					new ConcurrentDictionarySample(createValue)
				};
        }

        internal void Run(int threadCount, ForEachDelegate forEachDelegate)
        {
			Console.WriteLine();
			Console.WriteLine("Testing dictionaries with locks that don't allow duplicate values to be created");
			int count = _dictionariesNoDuplicates.Length;
			for(int i=0; i<count; i++)
			{
				Program._Measure(threadCount, forEachDelegate, _dictionariesNoDuplicates[i]);
	            if (_singleUse)
					_dictionariesNoDuplicates[i] = null;
			}

			Console.WriteLine();
			Console.WriteLine("Testing dictionaries with locks that allow duplicate values to be created");
			count = _dictionariesDuplicates.Length;
			for(int i=0; i<count; i++)
			{
				Program._Measure(threadCount, forEachDelegate, _dictionariesDuplicates[i]);
	            if (_singleUse)
					_dictionariesDuplicates[i] = null;
			}
        }
    }
}
