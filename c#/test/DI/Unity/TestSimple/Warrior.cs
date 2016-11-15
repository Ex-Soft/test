namespace TestSimple
{
    public class Warrior
    {
        readonly IWeapon Weapon;

        public Warrior(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }
}
