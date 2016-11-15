using System;

namespace Pfz.Threading.Disposers
{
	/// <summary>
	/// Class returned by WriteLock method.
	/// </summary>
	public struct OptimisticWriteLock:
		IDisposable
	{
		private OptimisticReaderWriterLock _lock;
		internal OptimisticWriteLock(OptimisticReaderWriterLock yieldLock)
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
				yieldLock.ExitWriteLock();
			}
		}
	}
}
