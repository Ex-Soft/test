namespace TestAsyncAwait
{
    public class Runner
    {
        public static async Task Run()
        {
            int value = 13;
            int? result = await FooAsync(value++);
            result = FooAsync(value++).Result;
            result = FooAsync(value++).GetAwaiter().GetResult();

            value = 169;
            result = await Foo(value++);
            result = Foo(value++).Result;
            result = Foo(value++).GetAwaiter().GetResult();
        }

        public static async Task<int?> FooAsync(int value)
        {
            await Task.CompletedTask;
            return value % 2 == 0 ? value : null;
        }

        public static Task<int?> Foo(int value)
        {
            return value % 2 == 0 ? Task.FromResult<int?>(value) : Task.FromResult<int?>(null);
        }
    }
}
