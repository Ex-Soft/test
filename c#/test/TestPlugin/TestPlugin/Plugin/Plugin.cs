namespace Plugin
{
    public class Plugin_A : IPlugin.IPlugin
    {
        public string DoSomething(int x)
        {
            return string.Format("Plugin_A: {0}", x);
        }
    }

    public class Plugin_B : IPlugin.IPlugin
    {
        public string DoSomething(int x)
        {
            return string.Format("Plugin_B: {0}", x*2);
        }
    }
}
