using System;

namespace Pfz.Threading.Disposers
{
	/// <summary>
	/// Interface implemented by ReaderWriterLocks' result to the
	/// UpgradeableLock method.
	/// </summary>
	public interface IUpgradeableLock:
		IDisposable
	{
		/// <summary>
		/// Upgrades this lock to a write-lock, returning an object
		/// so you can return to the upgradeable lock mode.
		/// </summary>
		IDisposable DisposableUpgrade();

		/// <summary>
		/// Upgrades this lock to an write lock, but it is
		/// not possible to return to the upgradeable lock any more.
		/// At the end, both the upgradeable and the write-lock
		/// will be released.
		/// </summary>
		bool Upgrade();
	}
}
