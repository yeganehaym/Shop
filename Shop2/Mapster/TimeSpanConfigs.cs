using Mapster;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Mapster;

public class TimeSpanConfigs
{
    public static void AddConfigs()
    {
        TypeAdapterConfig<TimeSpan, string>
            .NewConfig()
            .MapWith(timespan => timespan.TotalHours.ToString() +":"+ timespan.TotalMinutes);

        TypeAdapterConfig<string, TimeSpan>
            .NewConfig()
            .MapWith(s => TimeSpan.Parse(s));


    }
}