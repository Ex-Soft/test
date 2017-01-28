namespace Derived
{
    public class Derived : Base.Base
    {
        private void PrivateMethod()
        {
            // Error CS0122  'Base.PrivateIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access private property 'PrivateIntProperty' here
            //PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            ProtectedVirtualIntProperty = 1;
            ProtectedInternalIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;
            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;
            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            System.Diagnostics.Debug.WriteLine("Derived.Derived.PrivateMethod()");
        }

        protected override void ProtectedMethod()
        {
            // Error CS0122  'Base.PrivateIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access private property 'PrivateIntProperty' here
            //PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            ProtectedVirtualIntProperty = 1;
            ProtectedInternalIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;
            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;
            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            base.ProtectedMethod();
            System.Diagnostics.Debug.WriteLine("Derived.Derived.ProtectedMethod()");
        }

        protected override void ProtectedInternalMethod()
        {
            // Error CS0122  'Base.PrivateIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access private property 'PrivateIntProperty' here
            //PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            ProtectedVirtualIntProperty = 1;
            ProtectedInternalIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;
            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;
            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            base.ProtectedInternalMethod();
            System.Diagnostics.Debug.WriteLine("Derived.Derived.ProtectedInternalMethod()");
        }

        public override void PublicMethod()
        {
            // Error CS0122  'Base.PrivateIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access private property 'PrivateIntProperty' here
            //PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            ProtectedVirtualIntProperty = 1;
            ProtectedInternalIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;
            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;
            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            ProtectedMethod();
            ProtectedInternalMethod();

            base.PublicMethod();
            System.Diagnostics.Debug.WriteLine("Derived.Derived.PublicMethod()");
        }

        public void SetPublicIntPropertyProtectedSet(int value)
        {
            PublicIntPropertyProtectedSet = value;
        }

        public void SetPublicIntPropertyProtectedInternalSet(int value)
        {
            PublicIntPropertyProtectedInternalSet = value;
        }

        public void SetPublicVirtualIntPropertyProtectedSet(int value)
        {
            PublicVirtualIntPropertyProtectedSet = value;
        }

        public void SetPublicVirtualIntPropertyProtectedInternalSet(int value)
        {
            PublicVirtualIntPropertyProtectedInternalSet = value;
        }
    }
}
