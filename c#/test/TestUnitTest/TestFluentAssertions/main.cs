using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;

namespace TestFluentAssertions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[]
                arrayOfInt1 = {1, 2, 3, 4, 5},
                arrayOfInt2 = {5, 4, 3, 2, 1};

            List<int>
                listOfInt1 = new List<int> {1, 2, 3, 4, 5},
                listOfInt2 = new List<int> {5, 4, 3, 2, 1};

            try
            {
                arrayOfInt1.Should().BeEquivalentTo(arrayOfInt2);
                listOfInt1.Should().BeEquivalentTo(listOfInt2);
            }
            catch (AssertionFailedException eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
