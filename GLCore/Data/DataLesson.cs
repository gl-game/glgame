using GLCore.Extensions;
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
    public class DataLesson
    {

        public static List<ILesson> GetLessons()
        {
            var l = new List<ILesson>();

            String[] Files = new String[] { "Lessons.json" };

            foreach (String f in Files)
            {
                string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"DynamicScenes\" + f);
                String contents = File.ReadAllText(path);
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(contents);
                Assembly assembly = Assembly.GetExecutingAssembly();
                foreach (dynamic array in jsonObject)
                {
                    String id = array.id;
                    dynamic lessonobject = assembly.CreateInstance("GLCore.WorkAndStudy.Lesson");
                    var properties = lessonobject.GetType().GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        if (array[p.Name] != null)
                        {
                            if (p.Name == "DateOfBirth")
                            {
                                lessonobject.GetType().GetProperty(p.Name).SetValue(lessonobject, Convert.ToDateTime(((Newtonsoft.Json.Linq.JValue)array[p.Name]).Value), null);
                            }
                            else
                            {
                                String unknownType = (String)array[p.Name].Type.ToString();
                                switch (unknownType)
                                {
                                    case "Array":
                                        lessonobject.GetType().GetProperty(p.Name).SetValue(lessonobject, ((JArray)array[p.Name]).Select(t => (string)t).ToArray(), null);
                                        break;
                                    case "Integer":
                                        lessonobject.GetType().GetProperty(p.Name).SetValue(lessonobject, Convert.ToInt32(((JValue)array[p.Name]).Value), null);
                                        break;
                                    case "Double":
                                    case "Float":
                                        lessonobject.GetType().GetProperty(p.Name).SetValue(lessonobject, Convert.ToDecimal(((JValue)array[p.Name]).Value), null);
                                        break;
                                    default:
                                        lessonobject.GetType().GetProperty(p.Name).SetValue(lessonobject, ((Newtonsoft.Json.Linq.JValue)array[p.Name]).Value, null);
                                        break;
                                }
                            }

                        }
                    }
                    l.Add(lessonobject);
                }
            }
            return l;
        }
    }
}
