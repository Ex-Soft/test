// https://makolyte.com/csharp-how-to-use-polly-to-do-retries/
// https://makolyte.com/csharp-circuit-breaker-with-polly/

using static System.Console;

namespace ConsoleAppPure
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var valuesClient = new ValuesClient(new RetryDelayCalculator());

                WriteLine($"values={await valuesClient.GetValues()}");
            }
            catch (Exception ex)
            {
                WriteLine($"Request failed. {ex.Message}");
            }

            ReadLine();
        }
    }
}
