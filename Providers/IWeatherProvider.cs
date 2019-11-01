using System.Collections.Generic;
using contacts_list.Models;

namespace contacts_list.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
