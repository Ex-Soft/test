using System;
using System.Linq.Expressions;

namespace Pfz.Collections
{
    /// <summary>
    /// Class that holds a delegate to construct dictionary values (a Func&lt;TKey, TValue&gt;)
    /// using the default TValue constructor.
    /// </summary>
	public static class ValueConstructorDelegate<TKey, TValue>
	{
        /// <summary>
        /// Initializes the delegate.
        /// </summary>
		static ValueConstructorDelegate()
		{
			var constructor = typeof(TValue).GetConstructor(Type.EmptyTypes);
			if (constructor == null)
				return;

			var newExpression = Expression.New(constructor);
			var keyParameterExpression = Expression.Parameter(typeof(TKey), "key");
			var lamdaExpression = Expression.Lambda<Func<TKey, TValue>>(newExpression, keyParameterExpression);
			_default = lamdaExpression.Compile();
		}

		private static readonly Func<TKey, TValue> _default;
        /// <summary>
        /// Tries to get a default constructor delegate or returns null.
        /// </summary>
		public static Func<TKey, TValue> TryGetDefault()
		{
			return _default;
		}

        /// <summary>
        /// Gets the constructor delegate or throws an InvalidOperationException.
        /// </summary>
		public static Func<TKey, TValue> GetDefault()
		{
			if (_default == null)
				throw new InvalidOperationException("Type " + typeof(TValue).FullName + " does not have a public default constructor.");

			return _default;
		}
	}
}
