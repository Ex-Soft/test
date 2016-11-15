using System;

namespace TestSimple
{
    public class Bazuka : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("BIG BADABUM!");
        }
    }
}