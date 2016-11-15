using System;

namespace Pfz.Threading.Disposers
{
	/// <summary>
	/// Class returned by UpgradeableLock method.
	/// </summary>
	public struct OptimisticUpgradeableLock:
		IUpgradeableLock
	{
		private OptimisticReaderWriterLock _lock;
		private bool _upgraded;

		internal OptimisticUpgradeableLock(OptimisticReaderWriterLock yieldLock)
		{
			_lock = yieldLock;
			_upgraded = false;
		}

		/// <summary>
		/// Upgrades this lock to a write-lock.
		/// </summary>
		public OptimisticWriteLock DisposableUpgrade()
		{
			var yieldLock = _lock;
			if (yieldLock == null)
				throw new ObjectDisposedException(GetType().FullName);

			yieldLock.UncheckedUpgradeToWriteLock();
			return new OptimisticWriteLock(yieldLock);
		}

		/// <summary>
		/// Upgrades the lock to a write-lock.
		/// Returns true if the lock was upgraded, false if it was
		/// already upgraded before.
		/// </summary>
		public bool Upgrade()
		{
			var yieldLock = _lock;
			if (yieldLock == null)
				throw new ObjectDisposedException(GetType().FullName);

			if (_upgraded)
				return false;

			yieldLock.UncheckedUpgradeToWriteLock();
			_upgraded = true;
			return true;
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

			    yieldLock.ExitUpgradeableLock(_upgraded);
			}
		}

		IDisposable IUpgradeableLock.DisposableUpgrade()
		{
			return DisposableUpgrade();
		}
	}
}
