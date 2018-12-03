using System.Collections.Generic;
using System.Data.Entity;
using DbView.Domain.Models;

namespace DbView.Domain.Interfaces
{
    public interface ITable
    {
        ICollection<Field> GetFields(string tableName);
        ICollection<Field> GetFieldsWithDescriptions(string tableName, ICollection<Field> dbFields = null);
        DbSet GetDbSet(string tableName);
    }
}
