using System.Collections.Generic;

namespace WinFormsApp.Domain
{
    public class SmthEntities : ISmthEntities
    {
        IEnumerable<SmthEntity> _entities;

        public SmthEntities(IEnumerable<SmthEntity> entities)
        {
            SetEntities(entities);
        }

        public IEnumerable<SmthEntity> GetEntities()
        {
            return _entities;
        }

        public void SetEntities(IEnumerable<SmthEntity> entities)
        {
            _entities = entities != null ? new List<SmthEntity>(entities) : new List<SmthEntity>();
        }
    }
}
