using System;
using Ninject;
using Ninject.Modules;

namespace TestSimple
{
    public interface IWeapon
    {
        void Kill();
    }

    public class Bazuka : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("BIG BADABUM!");
        }
    }

    public class Sword : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Chuk-chuck");
        }
    }
    
    public class Warrior
    {
        readonly IWeapon Weapon;

        public Warrior(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }

    public class OtherWarrior
    {
        private IWeapon _weapon;

        public IWeapon Weapon
        {
            get
            {
                if (_weapon == null)
                {
                    _weapon = Program.AppKernel.Get<IWeapon>();
                }
                
                return _weapon;
            }
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }

    public class AnotherWarrior
    {
        [Inject]
        public IWeapon Weapon { get; set; }

        public void Kill()
        {
            Weapon.Kill();
        }
    }

    public class WeaponNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWeapon>().To<Sword>();
        }
    }

    class Program
    {
        public static IKernel AppKernel;

        static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new WeaponNinjectModule());

            var warrior = AppKernel.Get<Warrior>();
            
            warrior.Kill();

            var otherWarrior = new OtherWarrior();
            otherWarrior.Kill();

            var anotherWarrior = AppKernel.Get<AnotherWarrior>();
            anotherWarrior.Kill();

            Console.ReadLine();
        }
    }
}
