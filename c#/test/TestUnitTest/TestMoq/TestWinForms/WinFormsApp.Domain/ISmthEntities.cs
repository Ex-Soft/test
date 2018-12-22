using System.Collections.Generic;

namespace WinFormsApp.Domain
{
    public interface ISmthEntities
    {
        IEnumerable<SmthEntity> GetEntities();
        void SetEntities(IEnumerable<SmthEntity> entities);
    }
}
