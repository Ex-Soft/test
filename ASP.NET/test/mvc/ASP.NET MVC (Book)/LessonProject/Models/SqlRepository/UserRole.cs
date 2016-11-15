using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Models
{
    public partial class SqlRepository 
    {
        public IQueryable<UserRole> UserRoles
        {
            get
            {
                return Db.UserRoles;
            }
        }

        public bool CreateUserRole(UserRole instance)
        {
            if (instance.ID == 0)
            {
                Db.UserRoles.InsertOnSubmit(instance);
                Db.UserRoles.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUserRole(UserRole instance)
        {
            UserRole cache = Db.UserRoles.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                //TODO : Update fields for UserRole
                Db.UserRoles.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool RemoveUserRole(int idUserRole)
        {
            UserRole instance = Db.UserRoles.Where(p => p.ID == idUserRole).FirstOrDefault();
            if (instance != null)
            {
                Db.UserRoles.DeleteOnSubmit(instance);
                Db.UserRoles.Context.SubmitChanges();
                return true;
            }

            return false;
        }
        
    }
}
