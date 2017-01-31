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
            // Error CS0122  'Base.InternalIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalIntProperty' here
            //InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            // Error CS0122  'Base.InternalVirtualIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalVirtualIntProperty' here
            //InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicVirtualIntPropertyInternalSet = 1;
            PublicVirtualIntPropertyProtectedInternalSet = 1;

            System.Diagnostics.Debug.WriteLine("Derived.Derived.PrivateMethod()");
        }

        protected override void ProtectedMethod()
        {
            // Error CS0122  'Base.PrivateIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access private property 'PrivateIntProperty' here
            //PrivateIntProperty = 1;

            ProtectedIntProperty = 1;
            // Error CS0122  'Base.InternalIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalIntProperty' here
            //InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            // Error CS0122  'Base.InternalVirtualIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalVirtualIntProperty' here
            //InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicVirtualIntPropertyInternalSet = 1;
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
            // Error CS0122  'Base.InternalIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalIntProperty' here
            //InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            // Error CS0122  'Base.InternalVirtualIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalVirtualIntProperty' here
            //InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicVirtualIntPropertyInternalSet = 1;
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
            // Error CS0122  'Base.InternalIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalIntProperty' here
            //InternalIntProperty = 1;
            ProtectedInternalIntProperty = 1;

            ProtectedVirtualIntProperty = 1;
            // Error CS0122  'Base.InternalVirtualIntProperty' is inaccessible due to its protection level ClassLibrary
            // Cannot access internal property 'InternalVirtualIntProperty' here
            //InternalVirtualIntProperty = 1;
            ProtectedInternalVirtualIntProperty = 1;

            PublicIntProperty = 1;
            PublicIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicIntPropertyInternalSet = 1;
            PublicIntPropertyProtectedInternalSet = 1;

            PublicVirtualIntProperty = 1;
            PublicVirtualIntPropertyProtectedSet = 1;
            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicVirtualIntPropertyInternalSet = 1;
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

        public void SetPublicIntPropertyInternalSet(int value)
        {
            // Error CS0272  The property or indexer 'Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicIntPropertyInternalSet = value;
        }

        public void SetPublicIntPropertyProtectedInternalSet(int value)
        {
            PublicIntPropertyProtectedInternalSet = value;
        }

        public void SetPublicVirtualIntPropertyProtectedSet(int value)
        {
            PublicVirtualIntPropertyProtectedSet = value;
        }

        public void SetPublicVirtualIntPropertyInternalSet(int value)
        {
            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicVirtualIntPropertyInternalSet' cannot be used in this context because the set accessor is inaccessible
            //PublicVirtualIntPropertyInternalSet = value;
        }

        public void SetPublicVirtualIntPropertyProtectedInternalSet(int value)
        {
            PublicVirtualIntPropertyProtectedInternalSet = value;
        }
    }
}
