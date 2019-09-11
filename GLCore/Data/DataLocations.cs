using GLCore.Locations;
using GLCore.SupportObjects;
using GLHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Data
{
    class DataLocations
    {
        /*
         * 
         * 
         * 
         * 
         */
        public static Weather CreateWeather(GameTime time, ICity location)
        {
            Weather w = new Weather();
            Rand r = new Rand();
            if (location.TimeZone == 1)
            {
                switch (time.GetMonth())
                {
                    case 1:
                        w.Temperature = r.Next(-30, 8);
                        break;
                    case 2:
                        w.Temperature = r.Next(-35, 8);
                        break;
                    case 3:
                        w.Temperature = r.Next(-20, 17);
                        break;
                    case 4:
                        w.Temperature = r.Next(2, 20);
                        break;
                    case 5:
                        w.Temperature = r.Next(7, 25);
                        break;
                    case 6:
                        w.Temperature = r.Next(15, 35);
                        break;
                    case 7:
                        w.Temperature = r.Next(20, 40);
                        break;
                    case 8:
                        w.Temperature = r.Next(20, 35);
                        break;
                    case 9:
                        w.Temperature = r.Next(10, 30);
                        break;
                    case 10:
                        w.Temperature = r.Next(2, 20);
                        break;
                    case 11:
                        w.Temperature = r.Next(-20, 10);
                        break;
                    case 12:
                        w.Temperature = r.Next(-30, 8);
                        break;
                    default:
                        w.Temperature = 0;
                        break;
                }
                w.MonthId = time.GetMonth();
                w.Condition = r.Next(0, 1);
            }
            return w;
        }

        public static dynamic GetLocations()
        {
            string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"DynamicScenes\Locations.json");
            String contents = File.ReadAllText(path);
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(contents);
            var l = new ExpandoObject() as IDictionary<string, Object>;
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (dynamic array in jsonObject)
            {
                String id = array.id;
                dynamic actorobject = assembly.CreateInstance("GLCore.Locations." + array.classname);
                var properties = actorobject.GetType().GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    if (array[p.Name] != null)
                    {
                        if (p.Name == "DateOfBirth")
                        {
                            actorobject.GetType().GetProperty(p.Name).SetValue(actorobject, Convert.ToDateTime(((Newtonsoft.Json.Linq.JValue)array[p.Name]).Value), null);
                        }
                        else
                        {
                            String unknownType = (String)array[p.Name].Type.ToString();
                            switch (unknownType)
                            {
                                case "Array":
                                    actorobject.GetType().GetProperty(p.Name).SetValue(actorobject, ((JArray)array[p.Name]).Select(t => (string)t).ToArray(), null);
                                    break;
                                case "Integer":
                                    actorobject.GetType().GetProperty(p.Name).SetValue(actorobject, Convert.ToInt32(((JValue)array[p.Name]).Value), null);
                                    break;
                                case "Double":
                                case "Float":
                                    actorobject.GetType().GetProperty(p.Name).SetValue(actorobject, Convert.ToDecimal(((JValue)array[p.Name]).Value), null);
                                    break;
                                default:
                                    actorobject.GetType().GetProperty(p.Name).SetValue(actorobject, ((Newtonsoft.Json.Linq.JValue)array[p.Name]).Value, null);
                                    break;
                            }
                        }

                    }
                }
                l.Add(id, actorobject);
            }
            return l;
        }
    }
}
