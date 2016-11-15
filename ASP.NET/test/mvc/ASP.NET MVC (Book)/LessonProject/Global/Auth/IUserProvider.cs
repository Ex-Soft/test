using LessonProject.Models;

namespace LessonProject.Global.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
