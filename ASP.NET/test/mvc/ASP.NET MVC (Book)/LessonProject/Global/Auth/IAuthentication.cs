using System.Security.Principal;
using System.Web;
using LessonProject.Models;

namespace LessonProject.Global.Auth
{
    /// <summary>
    /// Интерфейс для авторизации
    /// </summary>
    public interface IAuthentication
    {
        /// <summary>
        /// Конекст (тут мы получаем доступ к запросу и кукисам)
        /// </summary>
        HttpContext HttpContext { get; set; }

        /// <summary>
        /// Процедура входа
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <param name="isPersistent">постоянная авторизация или нет</param>
        /// <returns></returns>
        User Login(string login, string password, bool isPersistent);

        /// <summary>
        /// Входим без пароля (использовать осторожно)
        /// </summary>
        /// <param name="login">логин</param>
        /// <returns></returns>
        User Login(string login);

        /// <summary>
        /// Выход
        /// </summary>
        void LogOut();

        /// <summary>
        /// Данные о текущем пользователе
        /// </summary>
        IPrincipal CurrentUser { get; }
    }
}
