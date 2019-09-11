using GLCore.Actors;
using GLCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Locations
{
    public class Room : ObjectBuilding
    {
        public Bag Bag { get; set; }
        public SmallBag SmallBag { get; set; }
        public Hat Hat { get; set; } //1
        public ITopDress TopDress { get; set; }  //2
        public IBottomDress BottomDress { get; set; } //3
        public Shoes Shoes { get; set; } //4
        public Stockings Stockings { get; set; } //5
        public Coat Coat { get; set; } //6
        public Bra Bra { get; set; } //7
        public Panties Panties { get; set; } //8


        public void Undress(Female f)
        {
            Bag = f.Bag;
            SmallBag = f.SmallBag;
            Hat = f.Hat;
            TopDress = f.TopDress;
            BottomDress = f.BottomDress;
            Shoes = f.Shoes;
            Stockings = f.Stockings;
            Coat = f.Coat;
            Bra = f.Bra;
            Panties = f.Panties;
            f.Bag = null;
            f.SmallBag = null;
            f.Hat = null;
            f.TopDress = null;
            f.BottomDress = null;
            f.Shoes = null;
            f.Stockings = null;
            f.Coat = null;
            f.Bra = null;
            f.Panties = null;
        }

        public void Dress(Female f)
        {
            f.Bag = Bag;
            f.SmallBag = SmallBag;
            f.Hat = Hat;
            f.TopDress = TopDress;
            f.BottomDress = BottomDress;
            f.Shoes = Shoes;
            f.Stockings = Stockings;
            f.Coat = Coat;
            f.Bra = Bra;
            f.Panties = Panties;
            Bag = null;
            SmallBag = null;
            Hat = null;
            TopDress = null;
            BottomDress = null;
            Shoes = null;
            Stockings = null;
            Coat = null;
            Bra = null;
            Panties = null;
        } 

        public Room()
        {
            LocationBags = new List<IBagObject>();
        }
        public void DropBag(Player player, IBagObject bagObject) {
            LocationBags.Add(bagObject);
            if (bagObject.GetType() == typeof(Bag))
            {
                player.Bag = null;
            }
            if (bagObject.GetType() == typeof(SmallBag))
            {
                player.SmallBag = null;
            }
        }

        public void GetLocationBags()
        {

        }

        public void GetBag(Player player, IBagObject bagObject)
        {
            if (bagObject.GetType() == typeof(Bag))
            {
                if (player.Bag != null)
                {
                    return;
                }
                player.Bag = (Bag)bagObject;
            }
            if (bagObject.GetType() == typeof(SmallBag))
            {
                if (player.SmallBag != null)
                {
                    return;
                }
                player.SmallBag = (SmallBag)bagObject;
            }
            LocationBags.Remove(bagObject);
        }
    }
}
