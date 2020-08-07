using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Client
{
    [Headers("Env: Test Refit")]
    public interface IWeatherForecast
    {
        [Get("/weatherforecast")]
        Task<IEnumerable<WeatherForecast>> GetAsync();

        [Headers("Code: CodeValue", "X-Extra: X-Extra-Value")]
        [Get("/group/{id}/users")]
        Task<string> GroupList([AliasAs("id")] int groupId);

        [Get("/group/{request.groupId}/users/{request.userId}")]
        Task<string> GroupList(UserGroupRequest request);

        [Headers("Code: CodeValue", "X-Extra: X-Extra-Value")]
        [Get("/group/{id}/users")]
        Task<string> GroupList([AliasAs("id")] int groupId, [AliasAs("sort")] string sortOrder);
    }
}
