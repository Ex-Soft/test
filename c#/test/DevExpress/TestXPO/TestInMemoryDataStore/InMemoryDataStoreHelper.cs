using System;
using System.Linq;
using System.Reflection;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

namespace TestInMemoryDataStore
{
    public class InMemoryDataStoreHelper
    {
        public static object CreateSimpleEntity(Type type, object data, Session session)
        {
            var entity = Activator.CreateInstance(type, session);
            var dataType = data.GetType();
            var dataProperties = dataType.GetMembers(BindingFlags.Public | BindingFlags.Instance);

            foreach (var entityPropertyMemberInfo in session.GetClassInfo(type).PersistentProperties.OfType<XPMemberInfo>())
            {
                PropertyInfo dataPropertyMemberInfo;
                if ((dataPropertyMemberInfo = dataProperties.FirstOrDefault(p => p.MemberType == MemberTypes.Property && p.Name == entityPropertyMemberInfo.Name) as PropertyInfo) == null)
                    continue;

                entityPropertyMemberInfo.SetValue(entity, dataPropertyMemberInfo.GetValue(data));
            }

            return entity;
        }

        public static void ShowExistingData(Type entityType, Func<object, string> formatter)
        {
            UnitOfWork session = null;

            try
            {
                session = new UnitOfWork();

                var separator = $"{entityType.Name} {new string('-', 60)}";
                System.Diagnostics.Debug.WriteLine(separator);
                var items = session.GetObjects(session.GetClassInfo(entityType), null, new SortingCollection(new SortProperty("Id", SortingDirection.Ascending)), 0, true, false);
                foreach (var item in items)
                    System.Diagnostics.Debug.WriteLine(formatter(item));
                System.Diagnostics.Debug.WriteLine(separator);
            }
            finally
            {
                session?.Dispose();
            }
        }
    }
}
