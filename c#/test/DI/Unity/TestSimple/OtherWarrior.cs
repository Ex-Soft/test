using Microsoft.Practices.ServiceLocation;

namespace TestSimple
{
    public class OtherWarrior
    {
        private IWeapon _weapon;

        public IWeapon Weapon
        {
            get
            {
                if (_weapon == null)
                {
                    _weapon = ServiceLocator.Current.GetInstance<IWeapon>();
                }

                return _weapon;
            }
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }
}