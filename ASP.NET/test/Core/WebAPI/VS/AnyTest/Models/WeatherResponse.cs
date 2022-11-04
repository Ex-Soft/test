using System.Text.Json.Serialization;

namespace AnyTest.Models;

public class WeatherResponse
{
    public Coord Coord { get; set; }
    public WeatherCondition[] Weather { get; set; }
    public string? Base { get; set; }
    public Main Main { get; set; }
    public long Visibility { get; set; }
    public Wind Wind { get; set; }
    public Clouds Clouds { get; set; }
    public Volume Rain { get; set; }
    public Volume Snow { get; set; }
    public ulong Dt { get; set; }
    public Sys Sys { get; set; }
    public long Timezone { get; set; }
    public long Id { get; set; }
    public string? Name { get; set; }
    public long Cod { get; set; }
}

public class Coord
{
    public decimal Lon { get; set; }
    public decimal Lat { get; set; }
}

public class WeatherCondition
{
    public long Id { get; set; }
    public string? Main { get; set; }
    public string? Description { get; set; }
    public string Icon { get; set; }
}

public class Main
{
    public decimal Temp { get; set; }
    [JsonPropertyName("feels_like")]
    public decimal FeelsLike { get; set; }
    public decimal Pressure { get; set; }
    public decimal Humidity { get; set; }
    [JsonPropertyName("temp_min")]
    public decimal TempMin { get; set; }
    [JsonPropertyName("temp_max")]
    public decimal TempMax { get; set; }
    [JsonPropertyName("sea_level")]
    public decimal SeaLevel { get; set; }
    [JsonPropertyName("grnd_level")]
    public decimal GrndLevel { get; set; }
}

public class Wind
{
    public decimal Speed { get; set; }
    public decimal Deg { get; set; }
    public decimal Gust { get; set; }
}

public class Volume
{
    [JsonPropertyName("1h")]
    public decimal? Last1Hour { get; set; }
    [JsonPropertyName("3h")]
    public decimal? Last3Hours { get; set; }
}

public class Clouds
{
    public decimal All { get; set; }
}

public class Sys
{
    public long? Type { get; set; }
    public long? Id { get; set; }
    public string? Message { get; set; }
    public string? Country { get; set; }
    public ulong Sunrise { get; set; }
    public ulong Sunset { get; set; }
}