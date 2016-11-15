using System;
using System.Collections.Concurrent;

namespace TestII
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resBool;
            int resInt;
            ConcurrentDictionary<string, int> con = new ConcurrentDictionary<string, int>();
            resBool = con.TryAdd("cat", 1);
            resBool = con.TryAdd("dog", 2);

            // Try to update if value is 4 (this fails).
            resBool = con.TryUpdate("cat", 200, 4);

            // Try to update if value is 1 (this works).
            resBool = con.TryUpdate("cat", 100, 1);

            // Write new value.
            Console.WriteLine(con["cat"]);
            
            // New instance.
            con = new ConcurrentDictionary<string, int>();
            resBool = con.TryAdd("cat", 1);
            resBool = con.TryAdd("dog", 2);

            // Add dog with value of 5 if it does NOT exist.
            // ... Otherwise, add one to its value.
            resInt = con.AddOrUpdate("dog", 5, (k, v) => v + 1);

            // Display dog value.
            Console.WriteLine(con["dog"]);

            // Get mouse or add it with value of 4.
            int mouse = con.GetOrAdd("mouse", 4);
            Console.WriteLine(mouse);

            // Get mouse or add it with value of 660.
            mouse = con.GetOrAdd("mouse", 660);
            Console.WriteLine(mouse);

            #region Demonstrates: ConcurrentDictionary<TKey, TValue>.TryAdd()/ConcurrentDictionary<TKey, TValue>.TryUpdate()/ConcurrentDictionary<TKey, TValue>.TryRemove() https://msdn.microsoft.com/en-us/library/dd267291.aspx

            int numFailures = 0; // for bookkeeping

            // Construct an empty dictionary
            ConcurrentDictionary<int, String> cd = new ConcurrentDictionary<int, string>();

            // This should work
            if (!cd.TryAdd(1, "one"))
            {
                Console.WriteLine("CD.TryAdd() failed when it should have succeeded");
                numFailures++;
            }

            // This shouldn't work -- key 1 is already in use
            if (cd.TryAdd(1, "uno"))
            {
                Console.WriteLine("CD.TryAdd() succeeded when it should have failed");
                numFailures++;
            }

            // Now change the value for key 1 from "one" to "uno" -- should work
            if (!cd.TryUpdate(1, "uno", "one"))
            {
                Console.WriteLine("CD.TryUpdate() failed when it should have succeeded");
                numFailures++;
            }

            // Try to change the value for key 1 from "eine" to "one" 
            //    -- this shouldn't work, because the current value isn't "eine"
            if (cd.TryUpdate(1, "one", "eine"))
            {
                Console.WriteLine("CD.TryUpdate() succeeded when it should have failed");
                numFailures++;
            }

            // Remove key/value for key 1.  Should work.
            string value1;
            if (!cd.TryRemove(1, out value1))
            {
                Console.WriteLine("CD.TryRemove() failed when it should have succeeded");
                numFailures++;
            }

            // Remove key/value for key 1.  Shouldn't work, because I already removed it
            string value2;
            if (cd.TryRemove(1, out value2))
            {
                Console.WriteLine("CD.TryRemove() succeeded when it should have failed");
                numFailures++;
            }

            // If nothing went wrong, say so
            if (numFailures == 0) Console.WriteLine("  OK!");
            #endregion
        }
    }
}
