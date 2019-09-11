using System;
namespace GLCore.SupportObjects
{
    interface IWeather
    {
        int Condition { get; set; }
        int Temperature { get; set; }
    }
}
