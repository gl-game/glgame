using GLCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Locations
{
    public class Shop : ObjectBuilding
    {
        public bool _isDefined;
        public List<IStuff> Things { get; set; }
        public Shop()
        {
            Things = new List<IStuff>();
        }

        public void AddStuff(IStuff Stuff, int count, Decimal price = 0)
        {
            for (int i = 0; i < count; i++)
            {
                IStuff st = GameStuff.DeepClone<IStuff>(Stuff);
                st.Price = (price > 0) ? price : Stuff.Price;
                Things.Add(st);
            }
        }

        public IStuff HaveStuff(IStuff Stuff, Decimal price)
        {
            IStuff o = Things.FirstOrDefault(s => s == Stuff );
            if (o == null)
            {
                return null;
            }
            return o;
        }

        public void RemoveStaff(IStuff Stuff, Decimal price, int count)
        {
            for (int i = 0; i < count; i++)
            {
                IStuff obj = HaveStuff(Stuff, price);
                if (obj != null)
                {
                    Things.Remove(obj);
                    obj = null;
                }
            }
        }

        public IStuff GetStaff(IStuff Stuff, Decimal price)
        {
            return HaveStuff(Stuff, price); 
        }

        public IStuff GetAndRemoveStaff(IStuff Stuff, Decimal price)
        {
            IStuff obj = HaveStuff(Stuff, price);
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
