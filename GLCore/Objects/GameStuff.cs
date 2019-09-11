using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace GLCore.Objects
{
    [Serializable]
    public class GameStuff : IStuff
    {
        public GameStuff()
        {
            Nobag = false;
        }
        public String id { get; set; }
        public String Image { get; set; }
        private String _classname;
        public String classname
        {
            get { return _classname;  }
            set { _classname = value;
                Type x = Type.GetType("GLCore.Objects." + _classname);
                if (x != null && x.GetInterfaces().Contains(typeof(IWear)))
                {
                    classtype = "IWear";
                }
                else
                {
                    classtype = "GameStuff";
                }
            
            }
        }
        public String classtype { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public int Weight { get; set; }
        public int UseCount { get; set; }
        public bool Nobag { get; set; }
        /* 0 - ALL, 1 - smallbag, 2 - bag */
        public int BagType { get; set; }
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
