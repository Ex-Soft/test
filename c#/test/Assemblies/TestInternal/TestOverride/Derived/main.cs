using System.Diagnostics;

namespace Derived
{
    class Program
    {
        static void Main(string[] args)
        {
            var derived = new Base.Derived();

            // Error CS0122  'Base.PrivateIntProperty' is inaccessible due to its protection level Base
            // Cannot access private property 'PrivateIntProperty' here
            //derived.PrivateIntProperty = 1;
            // Error CS0122  'Base.PrivateIntProperty' is inaccessible due to its protection level Base
            // Cannot access private property 'PrivateIntProperty' here
            //Debug.WriteLine($"PrivateIntProperty = {derived.PrivateIntProperty}");

            // Error CS0122  'Base.ProtectedIntProperty' is inaccessible due to its protection level Base
            // Cannot access protected property 'ProtectedIntProperty' here
            //derived.ProtectedIntProperty = 1;
            // Error CS0122  'Base.ProtectedIntProperty' is inaccessible due to its protection level Base
            // Cannot access protected property 'ProtectedIntProperty' here
            //Debug.WriteLine($"ProtectedIntProperty = {derived.ProtectedIntProperty}");

            // Error CS0122  'Base.ProtectedVirtualIntProperty' is inaccessible due to its protection level Base
            // Cannot access protected property 'ProtectedVirtualIntProperty' here
            //derived.ProtectedVirtualIntProperty = 1;
            // Error CS0122  'Base.ProtectedVirtualIntProperty' is inaccessible due to its protection level Base
            // Cannot access protected property 'ProtectedVirtualIntProperty' here
            //Debug.WriteLine($"ProtectedVirtualIntProperty = {derived.ProtectedVirtualIntProperty}");

            // Error CS0122  'Base.ProtectedInternalIntProperty' is inaccessible due to its protection level
            // Cannot access protected internal property 'ProtectedInternalIntProperty' here
            //derived.ProtectedInternalIntProperty = 1;
            // Error CS0122  'Base.ProtectedInternalIntProperty' is inaccessible due to its protection level
            // Cannot access protected internal property 'ProtectedInternalIntProperty' here
            //Debug.WriteLine($"ProtectedInternalIntProperty = {derived.ProtectedInternalIntProperty}");

            // Error CS0122  'Base.ProtectedInternalVirtualIntProperty' is inaccessible due to its protection level
            // Cannot access protected internal property 'ProtectedInternalVirtualIntProperty' here
            //derived.ProtectedInternalVirtualIntProperty = 1;
            // Error CS0122  'Base.ProtectedInternalVirtualIntProperty' is inaccessible due to its protection level
            // Cannot access protected internal property 'ProtectedInternalVirtualIntProperty' here
            //Debug.WriteLine($"ProtectedInternalVirtualIntProperty = {derived.ProtectedInternalVirtualIntProperty}");

            derived.PublicIntProperty = 1;
            Debug.WriteLine($"PublicIntProperty = {derived.PublicIntProperty}");

            // Error CS0272  The property or indexer 'Base.PublicIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            //derived.PublicIntPropertyProtectedSet = 1;
            Debug.WriteLine($"PublicIntPropertyProtectedSet = {derived.PublicIntPropertyProtectedSet}");

            // Error CS0272  The property or indexer 'Base.PublicIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            //derived.PublicIntPropertyProtectedInternalSet = 1;
            Debug.WriteLine($"PublicIntPropertyProtectedInternalSet = {derived.PublicIntPropertyProtectedInternalSet}");

            derived.PublicVirtualIntProperty = 1;
            Debug.WriteLine($"PublicVirtualIntProperty = {derived.PublicVirtualIntProperty}");

            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicVirtualIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            //derived.PublicVirtualIntPropertyProtectedSet = 1;
            Debug.WriteLine($"PublicVirtualIntPropertyProtectedSet = {derived.PublicVirtualIntPropertyProtectedSet}");

            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicVirtualIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            //derived.PublicVirtualIntPropertyProtectedInternalSet = 1;
            Debug.WriteLine($"PublicVirtualIntPropertyProtectedInternalSet = {derived.PublicVirtualIntPropertyProtectedInternalSet}");

            derived.PublicMethod();

            var derived2 = new Derived();

            derived2.PublicIntProperty = 1;
            Debug.WriteLine($"PublicIntProperty = {derived2.PublicIntProperty}");

            // Error CS0272  The property or indexer 'Base.PublicIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            //derived2.PublicIntPropertyProtectedSet = 1;
            derived2.SetPublicIntPropertyProtectedSet(int.MaxValue);
            Debug.WriteLine($"PublicIntPropertyProtectedSet = {derived2.PublicIntPropertyProtectedSet}");

            // Error CS0272  The property or indexer 'Base.PublicIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            //derived2.PublicIntPropertyProtectedInternalSet = 1;
            derived2.SetPublicIntPropertyProtectedInternalSet(int.MaxValue);
            Debug.WriteLine($"PublicIntPropertyProtectedInternalSet = {derived2.PublicIntPropertyProtectedInternalSet}");

            derived2.PublicVirtualIntProperty = 1;
            Debug.WriteLine($"PublicVirtualIntProperty = {derived2.PublicVirtualIntProperty}");

            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.Base.PublicVirtualIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            //derived2.PublicVirtualIntPropertyProtectedSet = 1;
            derived2.SetPublicVirtualIntPropertyProtectedSet(int.MaxValue);
            Debug.WriteLine($"PublicVirtualIntPropertyProtectedSet = {derived2.PublicVirtualIntPropertyProtectedSet}");

            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicVirtualIntPropertyProtectedInternalSet' cannot be used in this context because the set accessor is inaccessible
            //derived2.PublicVirtualIntPropertyProtectedInternalSet = 1;
            derived2.SetPublicVirtualIntPropertyProtectedInternalSet(int.MaxValue);
            Debug.WriteLine($"PublicVirtualIntPropertyProtectedInternalSet = {derived2.PublicVirtualIntPropertyProtectedInternalSet}");
            
            derived2.PublicMethod();
        }
    }
}
