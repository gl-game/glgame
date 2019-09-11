using GLCore.SupportObjects;
using System;
namespace GLCore.Locations
{
    public interface ICity
    {
        int TimeZone { get; set; }
        Weather weather { get; set; }
    }
}
