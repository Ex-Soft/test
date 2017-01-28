namespace Base
{
    public class Derived : Base
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

            System.Diagnostics.Debug.WriteLine("Base.Derived.PrivateMethod()");
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

            System.Diagnostics.Debug.WriteLine("Base.Derived.ProtectedMethod()");
        }

        protected internal override void ProtectedInternalMethod()
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

            System.Diagnostics.Debug.WriteLine("Base.Derived.ProtectedInternalMethod()");
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

            System.Diagnostics.Debug.WriteLine("Base.Derived.PublicMethod()");
        }
    }
}
