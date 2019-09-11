using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GLCore.Data
{
    public class DataStuff
    {
        public static dynamic GetStuff()
        {
            var l = new ExpandoObject() as IDictionary<string, Object>;

            String[] Files = new String[] { "Stuff.json", "DynamicStuff/Alcohol.json", "DynamicStuff/Parfume.json", "DynamicStuff/Cosmetics.json", "DynamicWear/Coat.json", "DynamicWear/Dress.json", "DynamicWear/hat.json", "DynamicWear/Pants.json"
            , "DynamicWear/Shirt.json", "DynamicWear/Shoes.json", "DynamicWear/Skirt.json", "DynamicWear/Stockings.json", "DynamicWear/Bra.json", "DynamicWear/Panties.json", 
            "DynamicWear/Bag.json", "DynamicWear/SmallBag.json"};

            foreach (String f in Files)
            {
                string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"DynamicScenes\" + f);
                String contents = File.ReadAllText(path);
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(contents);
                Assembly assembly = Assembly.GetExecutingAssembly();
                foreach (dynamic array in jsonObject)
                {
                    String id = array.id;
                    dynamic actorobject = assembly.CreateInstance("GLCore.Objects." + array.classname);
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
            }
            return l;
        }
    }
}
