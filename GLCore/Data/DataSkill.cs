using GLCore.Extensions;
using GLCore.GameSkills;
using GLCore.WorkAndStudy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GLCore.Data
{
    public class DataSkill
    {

        public static List<ISkill> GetSkills()
        {
            var l = new List<ISkill>();

            String[] Files = new String[] { "Skills.json" };

            foreach (String f in Files)
            {
                string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"DynamicScenes\" + f);
                String contents = File.ReadAllText(path);
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(contents);
                Assembly assembly = Assembly.GetExecutingAssembly();
                foreach (dynamic array in jsonObject)
                {
                    String id = array.id;
                    dynamic skillobject = assembly.CreateInstance("GLCore.GameSkills.Skill");
                    var properties = skillobject.GetType().GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        if (array[p.Name] != null)
                        {
                            if (p.Name == "DateOfBirth")
                            {
                                skillobject.GetType().GetProperty(p.Name).SetValue(skillobject, Convert.ToDateTime(((Newtonsoft.Json.Linq.JValue)array[p.Name]).Value), null);
                            }
                            else
                            {
                                String unknownType = (String)array[p.Name].Type.ToString();
                                switch (unknownType)
                                {
                                    case "Array":
                                        skillobject.GetType().GetProperty(p.Name).SetValue(skillobject, ((JArray)array[p.Name]).Select(t => (string)t).ToArray(), null);
                                        break;
                                    case "Integer":
                                        skillobject.GetType().GetProperty(p.Name).SetValue(skillobject, Convert.ToInt32(((JValue)array[p.Name]).Value), null);
                                        break;
                                    case "Double":
                                    case "Float":
                                        skillobject.GetType().GetProperty(p.Name).SetValue(skillobject, Convert.ToDecimal(((JValue)array[p.Name]).Value), null);
                                        break;
                                    default:
                                        skillobject.GetType().GetProperty(p.Name).SetValue(skillobject, ((Newtonsoft.Json.Linq.JValue)array[p.Name]).Value, null);
                                        break;
                                }
                            }

                        }
                    }
                    l.Add(skillobject);
                }
            }
            return l;
        }
    }
}
