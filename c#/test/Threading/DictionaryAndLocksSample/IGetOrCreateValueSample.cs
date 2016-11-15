using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryAndLocksSample
{
    public interface IGetOrCreateValueSample
    {
		string Message { get; }
        int GetOrCreate(int i);
    }
}
