using GLCore.Actors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Data
{
    class DataActors
    {
        public static dynamic GetActors()
        {
            string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"DynamicScenes\Actors.json");
            String contents = File.ReadAllText(path);
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(contents);
            var a = new ExpandoObject() as IDictionary<string, Object>;
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (dynamic array in jsonObject)
            {
                String id = array.id;
                dynamic actorobject = assembly.CreateInstance("GLCore.Actors." + array.classname);
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
                a.Add(id, actorobject);
            }
            /*
            a.Add("sister",  new FamilyFemale()
            {
                Name = "Сестра",
                Age = 19
            });
            /*
            a.sister = new FamilyFemale()
            {
                Name = "Сестра",
                Age = 19
            };
            a.brother = new FamilyMale()
            {
                Name = "Брат",
                Age = 15
            };
            a.mother = new FamilyFemale()
            {
                Name = "Мама",
                Age = 38
            };
            a.stepfather = new FamilyMale()
            {
                Name = "Отчим",
                Age = 40
            };
            a.father = new FamilyMale()
            {
                Name = "Отец",
                Age = 41
            };*/
            return a;
        }
    }
}
