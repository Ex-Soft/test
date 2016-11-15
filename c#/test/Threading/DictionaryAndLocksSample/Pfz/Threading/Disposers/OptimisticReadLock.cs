using System;

namespace Pfz.Threading.Disposers
{
	/// <summary>
	/// Class returned by ReadLock method.
	/// </summary>
	public struct OptimisticReadLock:
		IDisposable
	{
		private OptimisticReaderWriterLock _lock;
		internal OptimisticReadLock(OptimisticReaderWriterLock yieldLock)
		{
			_lock = yieldLock;
		}

		/// <summary>
		/// Releases the lock.
		/// </summary>
		public void Dispose()
		{
			var yieldLock = _lock;

			if (yieldLock != null)
			{
				_lock = null;
				yieldLock.ExitReadLock();
			}
		}
	}
}
