using System;
using Pfz.Threading.Disposers;

namespace Pfz.Threading
{
	/// <summary>
	/// Defines the contract that ReaderWriterLocks must follow.
	/// Note that if you want an Enter/Exit pair, you should
	/// use the IReaderWriterLockSlim.
	/// </summary>
	public interface IReaderWriterLock
	{
		/// <summary>
		/// Obtains a read lock. You should use it in a using clause
		/// so at the end the lock is released.
		/// </summary>
		IDisposable ReadLock();

		/// <summary>
		/// Obtains an upgradeable lock. You can use the returned
		/// value to upgrade the lock. Also, you should dispose
		/// the returned object (an using block is preferreable) to
		/// release the lock.
		/// </summary>
		IUpgradeableLock UpgradeableLock();

		/// <summary>
		/// Obtains an write lock. Call this method in a using clause
		/// so the lock is released at the end.
		/// </summary>
		IDisposable WriteLock();
	}
}
