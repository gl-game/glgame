using GLCore.Actors;
using GLCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Locations
{
    public class Box : RoomObject
    {
        public bool _isDefined;
        public List<IStuff> Things { get; set; }
        public Box()
        {
            Things = new List<IStuff>();
        }

        public void AddStuff(IStuff Stuff, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IStuff st = GameStuff.DeepClone<IStuff>(Stuff);
                Things.Add(st);
            }
        }

        public void MoveStuff(IStuff Stuff, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Things.Add(Stuff);
            }
        }

        public IStuff HaveStuff(IStuff Stuff)
        {
            IStuff o = Things.FirstOrDefault(s => s == Stuff);
            if (o == null)
            {
                return null;
            }
            return o;
        }

        public void RemoveStaff(IStuff Stuff, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IStuff obj = HaveStuff(Stuff);
                if (obj != null)
                {
                    Things.Remove(obj);
                    obj = null;
                }
            }
        }

        public IStuff GetStaff(IStuff Stuff)
        {
            return HaveStuff(Stuff);
        }

        public IStuff GetAndRemoveStaff(IStuff Stuff)
        {
            IStuff obj = HaveStuff(Stuff);
            if (obj != null)
            {
                Things.Remove(obj);
            }
            return obj;
        }


        public void DefineStuff(Action RegisterGoods)
        {
            if (!_isDefined)
            {
                RegisterGoods();
                _isDefined = true;
            }
        }
    }
}
