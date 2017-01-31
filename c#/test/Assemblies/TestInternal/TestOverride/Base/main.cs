using System.Diagnostics;

namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {
            var derived = new Derived();

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

            derived.InternalIntProperty = 1;
            Debug.WriteLine($"InternalIntProperty = {derived.InternalIntProperty}");

            derived.ProtectedInternalIntProperty = 1;
            Debug.WriteLine($"ProtectedInternalIntProperty = {derived.ProtectedInternalIntProperty}");

            // Error CS0122  'Base.ProtectedVirtualIntProperty' is inaccessible due to its protection level Base
            // Cannot access protected property 'ProtectedVirtualIntProperty' here
            //derived.ProtectedVirtualIntProperty = 1;
            // Error CS0122  'Base.ProtectedVirtualIntProperty' is inaccessible due to its protection level Base
            // Cannot access protected property 'ProtectedVirtualIntProperty' here
            //Debug.WriteLine($"ProtectedVirtualIntProperty = {derived.ProtectedVirtualIntProperty}");

            derived.InternalVirtualIntProperty = 1;
            Debug.WriteLine($"InternalVirtualIntProperty = {derived.InternalVirtualIntProperty}");

            derived.ProtectedInternalVirtualIntProperty = 1;
            Debug.WriteLine($"ProtectedInternalVirtualIntProperty = {derived.ProtectedInternalVirtualIntProperty}");

            derived.PublicIntProperty = 1;
            Debug.WriteLine($"PublicIntProperty = {derived.PublicIntProperty}");

            // Error CS0272  The property or indexer 'Base.PublicIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            //derived.PublicIntPropertyProtectedSet = 1;
            Debug.WriteLine($"PublicIntPropertyProtectedSet = {derived.PublicIntPropertyProtectedSet}");

            derived.PublicIntPropertyInternalSet = 1;
            Debug.WriteLine($"PublicIntPropertyInternalSet = {derived.PublicIntPropertyInternalSet}");

            derived.PublicIntPropertyProtectedInternalSet = 1;
            Debug.WriteLine($"PublicIntPropertyProtectedInternalSet = {derived.PublicIntPropertyProtectedInternalSet}");

            derived.PublicVirtualIntProperty = 1;
            Debug.WriteLine($"PublicVirtualIntProperty = {derived.PublicVirtualIntProperty}");

            // Error CS0272  The property or indexer 'Base.PublicVirtualIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            // The property 'Base.PublicVirtualIntPropertyProtectedSet' cannot be used in this context because the set accessor is inaccessible
            //derived.PublicVirtualIntPropertyProtectedSet = 1;
            Debug.WriteLine($"PublicVirtualIntPropertyProtectedSet = {derived.PublicVirtualIntPropertyProtectedSet}");

            derived.PublicVirtualIntPropertyInternalSet = 1;
            Debug.WriteLine($"PublicVirtualIntPropertyInternalSet = {derived.PublicVirtualIntPropertyInternalSet}");

            derived.PublicVirtualIntPropertyProtectedInternalSet = 1;
            Debug.WriteLine($"PublicVirtualIntPropertyProtectedInternalSet = {derived.PublicVirtualIntPropertyProtectedInternalSet}");

            derived.PublicMethod();
        }
    }
}
