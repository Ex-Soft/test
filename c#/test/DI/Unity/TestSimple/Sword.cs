using System;

namespace TestSimple
{
    public class Sword : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Chuk-chuck");
        }
    }
}