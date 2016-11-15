using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using LessonProject.Models;

namespace LessonProject.Global.Auth
{
    /// <summary>
    /// Реализация интерфейса для идентификации пользователя
    /// </summary>
    public class UserIndentity : IIdentity, IUserProvider
    {
        /// <summary>
        /// Текщий пользователь
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Тип класса для пользователя
        /// </summary>
        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        /// <summary>
        /// Авторизован или нет
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        /// <summary>
        /// Имя пользователя (уникальное) [у нас это счас Email]
        /// </summary>
        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        /// <summary>
        /// Инициализация по имени
        /// </summary>
        /// <param name="email">имя пользователя [email]</param>
        public void Init(string email, IRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.GetUser(email);
            }
        }
    }
}