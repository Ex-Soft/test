using System;

namespace TestSimple
{
    public class SingletonDemo : ISingletonDemo
    {
        public SingletonDemo()
        {
            ObjectId = Guid.NewGuid();
        }

        public Guid ObjectId { get; }
    }
}
