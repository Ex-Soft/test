using System.Diagnostics;
using AwaitAnything;
using static System.Console;

var sw = Stopwatch.StartNew();

// await Task.Delay(2000);
//await Delay.Seconds(2);
//await TimeSpan.FromSeconds(2);
//await 2.Seconds();
await 2;

WriteLine($"Waited for {sw.ElapsedMilliseconds}ms");