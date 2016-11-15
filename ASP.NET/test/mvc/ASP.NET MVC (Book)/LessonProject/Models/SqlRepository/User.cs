using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Models
{
    public partial class SqlRepository 
    {
        

        public IQueryable<User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.ID == 0)
            {
                instance.AddedDate = DateTime.Now;
                instance.ActivatedLink = User.GetActivateUrl();
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = Db.Users.Where(p => p.ID == instance.ID).FirstOrDefault();
            if (cache != null)
            {
                cache.Birthdate = instance.Birthdate;
                cache.AvatarPath = instance.AvatarPath;
                cache.Email = instance.Email;
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveUser(int idUser)
        {
            User instance = Db.Users.Where(p => p.ID == idUser).FirstOrDefault();
            if (instance != null)
            {
                Db.Users.DeleteOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public User GetUser(string email)
        {
            return Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0);
        }

        public User Login(string email, string password)
        {
            return Db.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password);
        }

        public bool ChangeLanguage(User instance, string LangCode)
        {
            var cache = Db.Users.FirstOrDefault(p => p.ID == instance.ID);
            var newLang = Db.Languages.FirstOrDefault(p => p.Code == LangCode);
            if (cache != null && newLang != null)
            {
                cache.Language = newLang;
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
