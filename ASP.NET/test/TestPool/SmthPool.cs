using System.Collections;

namespace TestPool
{
    class SmthPool
    {
        int
            poolSize;

        ArrayList
            pool;

        public SmthPool(int size)
        {
            poolSize = size;
            pool = ArrayList.Synchronized(new ArrayList(poolSize));
        }

        public bool AddPoolPosition()
        {
            return AddPoolPosition(null);
        }

        public bool AddPoolPosition(string positionId)
        {
            bool
                result = false;

            lock (pool.SyncRoot)
            {
                bool
                    isPositionIdDefined = !string.IsNullOrEmpty(positionId),
                    isExist = isPositionIdDefined ? pool.IndexOf(positionId) >= 0 : false;

                if (!isExist && (result = pool.Count < poolSize))
                    pool.Add(isPositionIdDefined ? positionId : string.Empty);
            }

            return result;
        }

        public void RemovePoolPosition()
        {
            RemovePoolPosition(null);
        }

        public void RemovePoolPosition(string positionId)
        {
            if (pool.Count == 0)
                return;

            string
                searchStr = !string.IsNullOrEmpty(positionId) ? positionId : string.Empty;

            lock (pool.SyncRoot)
            {
                int
                    idx;

                if ((idx = pool.IndexOf(searchStr)) >= 0)
                    pool.RemoveAt(idx);
            }
        }
    }
}
