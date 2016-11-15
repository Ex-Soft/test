
namespace Pfz.Collections
{
	/// <summary>
	/// Holds an immutable empty array that you can use everywhere if you
	/// need an empty array (so you avoid instantiating a new one everytime).
	/// </summary>
	/// <typeparam name="T">The type of the empty array this class holds.</typeparam>
    public static class EmptyArray<T>
    {
        private static readonly T[] _instance = new T[0];

		/// <summary>
		/// Gets the empty array of type T.
		/// </summary>
        public static T[] Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
