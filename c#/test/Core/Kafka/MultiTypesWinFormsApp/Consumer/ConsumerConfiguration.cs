using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiTypesWinFormsApp.Consumer
{
    public class ConsumerConfiguration
    {
        public CancellationToken CancellationToken { get; set; }
        public IEnumerable<Type> SpecificTypes { get; set; }
    }
}
