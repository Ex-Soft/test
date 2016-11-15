using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Models
{
    public interface IRepository
    {
        #region Role
        IQueryable<Role> Roles { get; }

        bool CreateRole(Role instance);

        bool UpdateRole(Role instance);

        bool RemoveRole(int idRole);

        #endregion

        #region User

        IQueryable<User> Users { get; }

        bool CreateUser(User instance);

        bool UpdateUser(User instance);

        bool RemoveUser(int idUser);

        User GetUser(string email);

        User Login(string email, string password);

        bool ChangeLanguage(User instance, string LangCode);

        #endregion 
        
        #region UserRole

        IQueryable<UserRole> UserRoles { get; }

        bool CreateUserRole(UserRole instance);

        bool UpdateUserRole(UserRole instance);

        bool RemoveUserRole(int idUserRole);

        #endregion 

        #region Language

        IQueryable<Language> Languages { get; }

        bool CreateLanguage(Language instance);

        bool UpdateLanguage(Language instance);

        bool RemoveLanguage(int idLanguage);

        #endregion 

        #region Post

        IQueryable<Post> Posts { get; }

        bool CreatePost(Post instance);

        bool UpdatePost(Post instance);

        bool RemovePost(int idPost);

        #endregion 
    }
}
