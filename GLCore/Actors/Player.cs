using GLCore.DTO;
using GLCore.Extensions;
using GLCore.Objects;
using GLCore.WorkAndStudy;
using GLHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actors
{
    public class Player : Female
    {
        public int Hungry { get; set; }
        public Dictionary<String, List<IStuff>> Things { get; set; }
        public Lessons Lessons { get; set; }
        public Skills Skills { get; set; }   

        public Player()
            : base()
        {
            Things = new Dictionary<String, List<IStuff>>();
            Lessons = new Lessons();
            Skills = new Skills();
            Things["None"] = new List<IStuff>();
        }

        public Player GetPlayer()
        {            		
            return this;
        }

        public bool Eat(int quantity = 0)
        {
            if (Energy > 25)
            {
                return false;
            }
            Rand r = new Rand(); 
            if (quantity == 0)
            {
                if (Energy < 18)
                {
                    Energy += r.Next(2, 5);
                    Drink += r.Next(5, 7);
                    Fat += 5;
                }
                else
                {
                    Energy += r.Next(1, 2);
                    Drink += r.Next(2, 4);
                    Fat += 2;
                }
            }
            if (quantity == 1)
            {
                if (Energy < 18)
                {
                    Energy += r.Next(4, 7);
                    Drink += r.Next(6, 9);
                    Fat += 4;
                }
                else
                {
                    Energy += r.Next(2, 3);
                    Drink += r.Next(3, 5);
                    Fat += 2;
                }
            }
            if (quantity == 2)
            {
                if (Energy < 18)
                {
                    Energy += r.Next(7, 10);
                    Drink += r.Next(10, 12); 
                    Fat += 6;

                }
                else
                {
                    Energy += r.Next(2, 4);
                    Drink += r.Next(3, 6);
                    Fat += 1;
                }
            }
            if (Drink > 26)
            {
                Drink = 26;
            }
            return true;
        }

        public bool WearStuff(IWear wear)
        {
            switch (wear.WearSlot)
            {
                case 1:
                    Hat = (Hat)wear;
                    break;
                case 2:
                    TopDress = (ITopDress)wear;
                    break;
                case 3:
                    BottomDress = (IBottomDress)wear;
                    break;
                case 4:
                    Shoes = (Shoes)wear;
                    break;
                case 5:
                    Stockings = (Stockings)wear;
                    break;
                case 6:
                    Coat = (Coat)wear;
                    break;
                case 7:
                    Bra = (Bra)wear;
                    break;
                case 8:
                    Panties = (Panties)wear;
                    break;
                case 9:
                    SmallBag = (SmallBag)wear;
                    break;
                case 10:
                    Bag = (Bag)wear;
                    break;
            }
            return true;
        }

        public int GetBagWeight(IBagObject bagObject)
        {
            int x = Convert.ToInt32(bagObject.Things.Select(t => t.Weight).Sum());
            return x;
        }

        public void AddSmallBagMe(SmallBag sb)
        {
            SmallBag = sb;
        }

        public void RemoveSmallBagMe(SmallBag sb)
        {
            SmallBag = null;
        }

        public void AddBagMe(Bag sb)
        {
            Bag = sb;
        }

        public void RemoveBagMe(SmallBag sb)
        {
            SmallBag = null;
        }

        public void AddThnig(IStuff Stuff)
        {
            AddStuff(GameStuff.DeepClone<IStuff>(Stuff));
        }

        public bool DrinkAlcohol(Alcohol Stuff, int time = 0)
        {
            if (Drunk > 40)
            {
                return false;
            }
            Decimal P = (Decimal)Weight;
            Decimal A = (((Decimal)Stuff.Alc / 100) * (Decimal)Stuff.Cl) * 0.79384m;
            Decimal r = 0.55m;
            Decimal b60 = 0.13m;
            Decimal T = (Decimal)time / 60;
            Decimal R = (Decimal)A / ((Decimal)P * (Decimal)r) - b60 * T;
            if (R < 0) R = 0;
            Drunk = Drunk + Convert.ToInt32(R * 10);
            return true;
        }

        public bool UseCondom(Condom Stuff)
        {
            Stuff.UseCount--;
            if (Stuff.UseCount == 0)
            {
                return false;
            }
            return true;
        }

        public bool UseParfume(Parfume Stuff)
        {
            switch (Stuff.Type)
            {
                case 0:
                    Parfume = 1;
                    break;
                case 1:
                    Parfume = 2;
                    break;
                case 2:
                    Parfume = 3;
                    break;
                case 3:
                    Parfume = 4;
                    break;
            }
            ParfumeExpire = CurrentTime.time.AddHours(8);
            Stuff.UseCount--;
            if (Stuff.UseCount == 0)
            {
                return false;
            }
            return true;
        }

        public bool UsePomade(Pomade Stuff)
        {
            switch (Stuff.Type)
            {
                case 0:
                    Pomade = 1;
                    break;
                case 1:
                    Pomade = 2;
                    break;
                case 2:
                    Pomade = 3;
                    break;
                case 3:
                    Pomade = 4;
                    break;
            }
            PomadeExpire = CurrentTime.time.AddHours(8);
            Stuff.UseCount--;
            if (Stuff.UseCount == 0)
            {
                return false;
            }
            return true;
        }

        public bool UseHairBrush(HairBrush Stuff)
        {
            HairBrush = 1;
            return true;
        }

        public void WakeUp()
        {
            if (Parfume > 0 || Pomade > 0 || EyeShadow > 0)
            {
                CosmeticsBreak = 1;
            }
            HairBrush = 0;
            HairStyle = 0;
        }

        public void Wash()
        {
            Sweat = 0;
            ClearCosmetics();
        }

        public void ClearCosmetics()
        {
            Parfume = 0;
            Pomade = 0; 
            EyeShadow = 0;
            CosmeticsBreak = 0;
        }

        public bool UseEyeShadow(EyeShadow Stuff)
        {
            switch (Stuff.Type)
            {
                case 0:
                    EyeShadow = 1;
                    break;
                case 1:
                    EyeShadow = 2;
                    break;
                case 2:
                    EyeShadow = 3;
                    break;
                case 3:
                    EyeShadow = 4;
                    break;
            }
            EyeShadowExpire = CurrentTime.time.AddHours(8);
            Stuff.UseCount--;
            if (Stuff.UseCount == 0)
            {
                return false;
            }
            return true;
        }

        public bool WashMySelf(WashSoap Soap)
        {
            Sweat = 0;
            Soap.UseCount--;
            if (Soap.UseCount == 0)
            {
                return false;
            }
            return true;
        }

        public bool ShavePussy(Shaver shaver, int type)
        {
            PussyShaveStyle = 0;
            PussyShaveСount = 0;
            if (type == 0) {
                PussyShave = 1;
            }
            else
            {
                if (PussyShave != 2 && PussyShave != 1)
                {
                    PussyShave = 3;
                }
            }
            shaver.UseCount--;
            if (shaver.UseCount == 0)
            {
                return false;
            }
            return true;
        }

        public bool ShaveLegs(Shaver shaver)
        {
            LegsShaveStyle = 0;
            LegsShaveСount = 0;
            LegsShave = 1;
            shaver.UseCount--;
            if (shaver.UseCount == 0)
            {
                return false;
            }
            return true;
        }

        public bool ShaveHands(Shaver shaver)
        {
            HandsShaveStyle = 0;
            HandsShaveСount = 0;
            HandsShave = 1;
            shaver.UseCount--;
            if (shaver.UseCount == 0)
            {
                return false;
            }
            return true;
        } 

        public bool AddStuff(IStuff Stuff, bool ForceNone = false)
        {
            if (Stuff.Nobag == true || ForceNone)
            {
                AddNone(Stuff);
                return true;

            }
            else if (Stuff.BagType == 0)
            {
                if (Bag != null && Bag.MaxWeight - GetBagWeight(Bag) > Stuff.Weight)
                {
                    AddBag(Stuff);
                    return true;
                }
                else if (SmallBag != null && SmallBag.MaxWeight - GetBagWeight(SmallBag) > Stuff.Weight)
                {
                    AddSmallBag(Stuff);
                    return true;
                }
            }
            else if (Stuff.BagType == 1 && SmallBag != null)
            {
                if (SmallBag.MaxWeight - GetBagWeight(SmallBag) > Stuff.Weight)
                {
                    AddSmallBag(Stuff);
                    return true;
                }
            }
            else if (Stuff.BagType == 2 && Bag != null)
            {
                if (Bag.MaxWeight - GetBagWeight(Bag) > Stuff.Weight)
                {
                    AddBag(Stuff);
                    return true;
                }
            }
            return false;

        }
        public bool AddStuffToBag(IStuff Stuff, IBagObject bagObject)
        {
            if (bagObject.classname == "SmallBag" && Stuff.BagType == 2)
            {
                return false;
            }
            if (bagObject != null &&
                bagObject.MaxWeight - GetBagWeight(bagObject) > Stuff.Weight)
            {
                AddToBag(Stuff, bagObject);
                return true;
            }
            return false;
        }

        public void AddToBag(IStuff Stuff, IBagObject bagObject)
        {
            bagObject.Things.Add(Stuff);
        }

        public void AddBag(IStuff Stuff)
        {
            Bag.Things.Add(Stuff);
        }
        public void AddSmallBag(IStuff Stuff)
        {
            SmallBag.Things.Add(Stuff);
        }
        public void AddNone(IStuff Stuff)
        {
            Things["None"].Add(Stuff);
        }

        public IStuff GetStuffByIdSmallBag(IStuff Stuff)
        {
            if (SmallBag != null)
            {
                foreach (IStuff key in SmallBag.Things)
                {
                    if (key.id == Stuff.id)
                    {
                        return key;
                    }

                }
            }
            return null;
        }

        public IStuff HaveStuff(IStuff Stuff)
        {
            if (SmallBag != null)
            {
                foreach (IStuff key in SmallBag.Things)
                {
                    if (key == Stuff)
                    {
                        return key;
                    }

                }
            }
            if (Bag != null)
            {
                foreach (IStuff key in Bag.Things)
                {
                    if (key == Stuff)
                    {
                        return key;
                    }
                }
            }
            return null;
        }

        public IStuff HaveStuffInBox(IStuff Stuff, IBagObject bagObject)
        {

            IStuff o = bagObject.Things.FirstOrDefault(s => s == Stuff);
            if (o != null)
            {
                return o;
            }
            return null;
        }

        public void RemoveStaff(IStuff Stuff, IBagObject bagObject)
        {
            IStuff obj = HaveStuff(Stuff);
            if (obj != null)
            {
                bagObject.Things.Remove(obj);
            }

        }

        public TextDTO GetMana()
        {
            var t = new TextDTO();
            if (Mana >= maxMana)
            {
                t.color = "green";
                t.Font = 12;
                t.Name = "Я в прекрасном настроении.";
            } //return "<font color='green' style='font-size:11px'>Вы в прекрасном настроении.</font><br />";
            if (Mana < maxMana && Mana >= (Double)maxMana * 75 / 100)
            {
                t.color = "green";
                t.Font = 12;
                t.Name = "У меня нормальное настроение";
            } //return "<font color='blue' style='font-size:11px'>У вас нормальное настроение.</font><br />";
            if (Mana < (Double)maxMana * 75 / 100 && Mana >= (Double)maxMana * 50 / 100)
            {
                t.color = "blue";
                t.Font = 12;
                t.Name = "Я в скверном настроении.";

            } //return "<font color='blue' style='font-size:11px'>Вы в скверном настроении.</font><br />";
            if (Mana < (Double)maxMana * 50 / 100 && Mana >= (Double)maxMana * 25 / 100)
            {
                t.color = "blue";
                t.Font = 12;
                t.Name = "Я в ужасном настроении..";

            } //return "<font color='blue' style='font-size:11px'>Вы в ужасном настроении.</font><br />";
            if (Mana < (Double)maxMana * 25 / 100)
            {
                t.color = "red";
                t.Font = 15;
                t.Name = "Мое настроение ниже любого плинтуса и городской канализации.";

            } //return "<font color='red' style='font-size:15px'>Ваше настроение ниже любого плинтуса и городской канализации.</font><br />";
            return t;
        }

        public TextDTO GetWillPower()
        {
            var t = new TextDTO();
            if (Mind >= maxMind)
            {
                t.color = "green";
                t.Font = 12;
                t.Name = "У меня кристально чистый разум.";

            } // return "<font color = green style='font-size:11px'>У вас кристально чистый разум.</font><br />";
            if (Mind < maxMind && Mind >= (Double)maxMind * 75 / 100)
            {
                t.color = "green";
                t.Font = 12;
                t.Name = "Я большей частью пребываею в задумчивости..";
            }// return "<font color = blue style='font-size:11px'>Вы большей частью пребываете в задумчивости.</font><br />";
            if (Mind < (Double)maxMind * 75 / 100 && Mind >= (Double)maxMind * 50 / 100)
            {
                t.color = "blue";
                t.Font = 12;
                t.Name = "Вы подавленны.";
            } // return "<font color = blue style='font-size:11px'>Вы подавленны.</font><br />";
            if (Mind < (Double)maxMind * 50 / 100 && Mind >= (Double)maxMind * 25 / 100)
            {
                t.color = "blue";
                t.Font = 12;
                t.Name = "Я в депрессии.";
            } // return "<font color = blue style='font-size:11px'>Вы в депрессии.</font><br />";
            if (Mind < (Double)maxMind * 25 / 100)
            {
                t.color = "red";
                t.Font = 15;
                t.Name = "Я на грани сумашествия.";
            }// return "<font color = red style='font-size:11px'>Вы на грани сумашествия.</font><br />";
            return t;

        }
        public TextDTO GetHealth()
        {
            var t = new TextDTO();
            if (Health >= maxHealth)
            {
                t.color = "green";
                t.Font = 12;
                t.Name = "Я полностью здорова и сияею здоровым румянцем.";
            }// return "<font color = green style='font-size:11px'>Вы полностью здоровы и сияете здоровым румянцем.</font><br />";
            if (Health < maxHealth && Health >= (Double)maxHealth * 75 / 100)
            {
                t.color = "green";
                t.Font = 12;
                t.Name = "Я здорова, но самочувствие как то не очень.";
            }// return "<font color = blue style='font-size:11px'>Вы здоровы, но самочувствие как то не очень.</font><br />";
            if (Health < (Double)maxHealth * 75 / 100 && Health >= (Double)maxHealth * 50 / 100)
            {
                t.color = "blue";
                t.Font = 12;
                t.Name = "Мне нездоровиться.";
            }// return "<font color = blue style='font-size:11px'>Вам нездоровиться.</font><br />";
            if (Health < (Double)maxHealth * 50 / 100 && Health >= (Double)maxHealth * 25 / 100)
            {
                t.color = "blue";
                t.Font = 12;
                t.Name = "Я болеетю.";
            }// return "<font color = blue style='font-size:11px'>Вы болеете.</font><br />";
            if (Health < (Double)maxHealth * 25 / 100)
            {
                t.color = "red";
                t.Font = 15;
                t.Name = "Я на пороге смерти.";
            }// return "<font color = red style='font-size:11px'>Вы на пороге смерти.</font><br />";
            return t;
        }
        public String GetFantasy()
        {
            return "Я погружены в свои фантазии после прочтения книги.";
        }
        public String IndicatorColor(int value, int max)
        {
            String s = "";
            Double p = Math.Ceiling(Convert.ToDouble(((Double)value / max) * 100));
            if (p > 60)
            {
                s = "green";
            }
            else if (p > 25)
            {
                s = "blue";
            }
            else
            {
                s = "red";
            }
            return s;
        }

        public String IndicatorReverseColor(int value, int max)
        {
            String s = "";
            Double p = Math.Ceiling(Convert.ToDouble(((Double)value / max) * 100));
            if (p > 60)
            {
                s = "red";
            }
            else if (p > 25)
            {
                s = "blue";
            }
            else
            {
                s = "green";
            }
            return s;
        }

        public TextDTO GetBodyDescription()
        {
            var t = new TextDTO();
            int musle = Strength + Vitality;

            if (musle >= Fat)
            {
                if (Bedra < 60)
                    t.Name = "Я очень худа, жира на теле практически нет, через кожу выступают мышцы.";
                else if (Bedra >= 60 && Bedra < 70)
                    t.Name = "я очень худа, жира на теле практически нет, через кожу выступают мышцы.";
                else if (Bedra >= 70 && Bedra < 80)
                    t.Name = "я худа, жира на теле практически нет, через кожу выступают мышцы.";
                else if (Bedra >= 80 && Bedra < 90)
                    t.Name = "Я худа, жира на теле практически нет, через кожу выступают мышцы.";
                else if (Bedra >= 90 && Bedra < 100)
                    t.Name = "Я худа, жира на теле практически нет, через кожу выступают крупные мышцы.";
                else if (Bedra >= 100 && Bedra < 110)
                    t.Name = "Жира на теле практически нет, через кожу выступают крупные мышцы.";
                else if (Bedra >= 110 && Bedra < 120)
                    t.Name = "Жира на теле практически нет, через кожу выступают массивные мышцы.";
                else if (Bedra >= 120)
                    t.Name = "Жира на теле практически нет, через кожу выступают массивные мышцы.";
            }
            else
            {
                if (Bedra < 60)
                    t.Name = "Я очень худа и у меня практически полностью отсутствуют мышцы.";
                else if (Bedra >= 60 && Bedra < 70)
                    t.Name = "Я очень тонкая девушка, с маленькой мягкой попой и у меня практически полностью отсутствуют мышцы.";
                else if (Bedra >= 70 && Bedra < 80)
                    t.Name = "Я очень стройная девушка.";
                else if (Bedra >= 80 && Bedra < 90)
                    t.Name = "Я стройная девушка.";
                else if (Bedra >= 90 && Bedra < 100)
                    t.Name = "Я фигуристая девушка.";
                else if (Bedra >= 100 && Bedra < 110)
                    t.Name = "Я формастая девушка.";
                else if (Bedra >= 110 && Bedra < 120)
                    t.Name = "Я жирноватая девушка.";
                else if (Bedra >= 120)
                    t.Name = "Я жирная свинья.";

            }

            return t;
        }

        public TextDTO GetParfumeInfo()
        {
            var t = new TextDTO();
            switch (Parfume)
            {
                case 1:
                    t.Name = "От меня пахнет дешевым парфюмом";
                    break;
                case 2:
                    t.Name = "От меня пахнет простым парфюмом";
                    break;
                case 3:
                    t.Name = "От меня пахнет дорогим парфюмом";
                    break;
                case 4:
                    t.Name = "От меня пахнет изысканым парфюмом";
                    break;
            }
            return t;
        }

        public TextDTO GetVisualView()
        {
            var t = new TextDTO();
            if (Beauty < -10) { t.Name += "У меня заметны признаки венерического заболевания. Поэтому парни разбегаются в ужасе."; }
            if (Beauty < 5 && Beauty >= -10) { t.Name += "У меня страшная внешность. Парни от меня шарахаются."; }
            if (Beauty >= 5 && Beauty < 15) { t.Name += "У меня серенькая внешность. Парни практически меня не замечают."; }
            if (Beauty >= 15 && Beauty < 30) { t.Name += "У меня симпатичная внешность. Парни частенько обращают на меня внимание."; }
            if (Beauty >= 30 && Beauty < 50) { t.Name += "У меня сногсшибательная внешность. Парни постоянно оборачиваются видя меня."; }
            if (Beauty >= 50) { t.Name += "У меня просто божественная внешность. Парни сами падают к моим ногам."; }
            return t;
        }

        public TextDTO GetVisualDressView()
        {
            var t = new TextDTO();
            if (DressBeauty < 5) { t.Name += "Моя одежа как у зачуханой колхозницы"; }
            if (DressBeauty >= 5 && DressBeauty < 15) { t.Name += "У меня базарный вариант одежды"; }
            if (DressBeauty >= 15 && DressBeauty < 30) { t.Name += "Моя одежда ничем не отдичается от всех"; }
            if (DressBeauty >= 30 && DressBeauty < 50) { t.Name += "Моя одежа покупалась в дорогих магазинах и выглядит отлично"; }
            if (DressBeauty >= 50) { t.Name += "Я просто королева в этом наряде. У парней встает при виде меня а девченоки злобно завидуют."; }

            if (FullNude == 1) { t.Name = ""; }
            return t;
        }

        public TextDTO GetHairStyle()
        {
            String hapri = (HairBrush == 1) ? "аккуратно уложеные" : "cпутавшиеся";
            var t = new TextDTO();

            if (ShortHair == 0)
            {
                if (HairColor == 0 && HairStyle <= 0) t.Name = "У меня " + hapri + " прямые, черные волосы."; //& $hair2 = 'черные волосы' & $hair3 = 'черными волосами'
                if (HairColor == 1 && HairStyle <= 0) t.Name = "У меня " + hapri + " прямые, русые волосы."; //& $hair2 = 'русые волосы' & $hair3 = 'русыми волосами'
                if (HairColor == 2 && HairStyle <= 0) t.Name = "У меня " + hapri + " прямые, рыжие волосы."; //& $hair2 = 'рыжие волосы' & $hair3 = 'рыжими волосами'
                if (HairColor == 3 && HairStyle <= 0) t.Name = "У меня " + hapri + " прямые, светлые волосы."; //& $hair2 = 'светлые волосы' & $hair3 = 'светлыми волосами'
                if (HairColor == 0 && HairStyle > 0) t.Name = "У меня " + hapri + " кудрявые, черные волосы."; //& $hair2 = 'кудри' & $hair3 = 'черными кудрями'
                if (HairColor == 1 && HairStyle > 0) t.Name = "У меня " + hapri + " кудрявые, русые волосы."; //& $hair2 = 'кудри' & $hair3 = 'русыми кудрями'
                if (HairColor == 2 && HairStyle > 0) t.Name = "У меня " + hapri + " кудрявые, рыжие волосы."; //& $hair2 = 'кудри' & $hair3 = 'рыжими кудрями'
                if (HairColor == 3 && HairStyle > 0) t.Name = "У меня " + hapri + " кудрявые, светлые волосы."; // &$hair2 = 'кудри' & $hair3 = 'светлыми кудрями'
            }
            else if (ShortHair == 1)
            {
                if (HairColor == 0) t.Name = "У меня короткие черные волосы."; //& $hair2 = 'черные волосы' & $hair3 = 'черными волосами'
                if (HairColor == 1) t.Name = "У меня короткие русые волосы."; //$hair2 = 'русые волосы' & $hair3 = 'русыми волосами'
                if (HairColor == 2) t.Name = "У меня короткие рыжие волосы."; //$hair2 = 'рыжие волосы' & $hair3 = 'рыжими волосами'
                if (HairColor == 3) t.Name = "У меня короткие светлые волосы."; //$hair2 = 'светлые волосы' & $hair3 = 'светлыми волосами'
            }

            return t;
        }

        public TextDTO GetEyeBrowsStyle()
        {
            
            var t = new TextDTO();
            if (EyeBrows == 0 && EyeBrowsPermanent == 0) t.Name = "немного не аккуратные брови";
            if (EyeBrows > 0 && EyeBrowsPermanent == 0) t.Name = "ухоженные брови";
            if (EyeBrowsPermanent > 0) t.Name = "перманентный татуаж бровей";

            return t;
        }

        public TextDTO GetLipsStyle()
        {
            var t = new TextDTO();
            if (LipSize == 0) t.Name = "У меня тонкие губы";
            if (LipSize == 1) t.Name = "У меня нормальные губы";
            if (LipSize == 2) t.Name = "У меня пухленькие губы";
            if (LipSize == 3) t.Name = "У меня крупные губы";
            if (LipSize >= 4) t.Name = "У меня толстые и огромные губы";
            return t;
        }

        public TextDTO GetEarningStyle()
        {
            var t = new TextDTO();
            if (Earrings == 1) t.Name = "В ушах болтаются сережки.";
            return t;
        }

        public TextDTO GetBellyPiercingStyle()
        {
            var t = new TextDTO();
            if (BellyPiercing == 1) t.Name = "В пупке вставлен пирсинг.";
            return t;
        }

        public TextDTO GetVaginaPiercingStyle()
        {
            var t = new TextDTO();
            if (VaginaPiercing == 1) t.Name = "В клиторе пирсинг.";
            return t;
        }
        
        public TextDTO GetTanStyle()
        {
            var t = new TextDTO();
            if (SkinTone == 0) t.Name = "У меня бледная кожа.";
            if (SkinTone == 1) t.Name = "У меня загорелая кожа.";
            if (SkinTone == -1) t.Name = "У меня обгоревшая кожа.";
            return t;
        }

        public TextDTO GetSkinStyle()
        {
            var t = new TextDTO();
            if (SkinStatus == 0) t.Name = "У меня не ровная и покрыта прыщами и черными точками кожа.";
            if (SkinStatus == 1) t.Name = "У меня не ровная кожа и кое где видно прыщики.";
            if (SkinStatus == 2) t.Name = "У меня кожа не ровная, но прыщей не видно.";
            if (SkinStatus == 3) t.Name = "У меня гладкая и ухоженная кожа.";
            if (SkinStatus == 4) t.Name = "У меня  гладкая как стекло и шелковистая на ощупь кожа.";
            return t;
        }

        public TextDTO GetMakeupStyle()
        {
            if (Cosmetics < 0)
            {
                return new TextDTO()
                {
                    Name = "У меня потек макияж"
                };
            }

            var t = new TextDTO();
            if (Pomade == 0) t.Name = "Губы не накрашены помадой.";
            if (Pomade == 1) t.Name = "Губы накрашены помадой.";
            if (Pomade == 2) t.Name = "Губы накрашены помадой с блестками.";
            if (Pomade == 3) t.Name = "Губы накрашены хорошей помадой.";
            if (Pomade == 4) t.Name = "Губы накрашены дорогой помадой с блестками.";

            if (EyeShadow == 0) t.Name += " Глаза не накрашены.";
            if (EyeShadow == 1) t.Name += " Глаза накрашены дешевыми тенянми.";
            if (EyeShadow == 2) t.Name += " Глаза накрашены тенянми.";
            if (EyeShadow == 3) t.Name += " Глаза накрашены тенянми со стрелками.";
            if (EyeShadow == 4) t.Name += " Глаза накрашены дорогой косметикой";

            return t;
        }


        public int EyelashsSize { get; set; }
        public int EyeSize { get; set; }

        public TextDTO GetEyeStyle()
        {
            String resinc = "";
            String glaza = "";
            if (EyelashsSize == 0) resinc = "с короткими ресницами";
            if (EyelashsSize == 1) resinc = "с нормальной длинны ресницами";
            if (EyelashsSize == 2) resinc = "с длинными ресницами";

            if (EyeSize == 0) glaza = "У меня маленькие глаза, " + resinc;
            if (EyeSize == 1) glaza = "У меня выразительные глаза, " + resinc;
            if (EyeSize == 2) glaza = "У меня большие глаза, " + resinc;
            if (EyeSize == 3) glaza = "У меня огромные глаза, " + resinc;

            return new TextDTO()
            {
                Name = glaza
            };

        }

        public TextDTO GetVaginaStatusStyle()
        {
            var t = new TextDTO();
            if (IsVirgin == 1)
            {
                t.Name = "Я девственница";
                return t;
            }
            if (VaginaWidth > 0) t.Name = "Ваша киска киска имеет крохотную дырочку";
            if (VaginaWidth > 10) t.Name = "У вас тесная, похожая на щель вагина";
            if (VaginaWidth > 20) t.Name = "У вас слегка растянутая эластичная вагина";
            if (VaginaWidth > 30) t.Name = "У вас хорошо разработанная вагина";
            if (VaginaWidth > 40) t.Name = "Между ног у вас не закрывается здоровенная дыра";
            if (VaginaWidth > 50) t.Name = "То что у вас на месте киски, больше похоже на скважину глубиной с марианскую впадину";
            return t;
        }

        public TextDTO GetPussyStyle()
        {
            var t = new TextDTO();
            if (PussyShave == 0) t.Name = "У меня волосатая киска";
            if (PussyShave == 1) t.Name = "У меня наголо выбритая киска бритвой";
            if (PussyShave == 2) t.Name = "У меня ваксация глубокого бикини без единого волоска";
            if (PussyShave == 3) t.Name = "У меня бритая киска с полоской";
            if (PussyShave == 4) t.Name = "У меня ваксация глубокого бикини с полоской";
            if (PussyShave == 5) t.Name = "На киске появилась щетина после бритвы";
            if (PussyShave == 6) t.Name = "На моей киске появились волосики после ваксации";
            return t;
        }

        public TextDTO GetLegsStyle()
        {
            var t = new TextDTO();
            if (LegsShave == 0) t.Name = "У меня волосатые ноги";
            if (LegsShave == 1) t.Name = "У меня наголо выбритые ноги бритвой";
            if (LegsShave == 2) t.Name = "У меня ваксация ног без единого волоска";
            if (LegsShave == 3) t.Name = "На ногах появилась щетина после бритвы";
            if (LegsShave == 4) t.Name = "На ногах появились волосики после ваксации";
            return t;
        }

        public TextDTO GetHandsStyle()
        {
            var t = new TextDTO();
            if (HandsShave == 0) t.Name = "У меня волосатые подмышки";
            if (HandsShave == 1) t.Name = "У меня наголо выбритые подмышки бритвой";
            if (HandsShave == 2) t.Name = "У меня ваксация подмышек без единого волоска";
            if (HandsShave == 3) t.Name = "На подмышках появилась щетина после бритвы";
            if (HandsShave == 4) t.Name = "На подмышках появились волосики после ваксации";
            return t;
        }

        public TextDTO GetAnusSize()
        {

            var t = new TextDTO();
            if (AnusPlug == 0)
            {
                if (AnusLength == 0) t.Name = "У меня девственный анус";// & $anustipe = 'девственный' & $anustipe2 = 'девственную'
                if (AnusLength > 0 && AnusLength <= 5) t.Name = "Мой ануc выглядит как крохотная щелочка.";// & $anustipe = 'крошечный' & $anustipe2 = 'крошечную'
                if (AnusLength > 5 && AnusLength <= 10) t.Name = "Мой анус имеет форму звездочки.";// & $anustipe = 'тугой' & $anustipe2 = 'тугую'
                if (AnusLength > 10 && AnusLength <= 15) t.Name = "Мой анус выглядит как щель.";//& $anustipe = 'слегка растянутый' & $anustipe2 = 'слегка растянутую'
                if (AnusLength > 15 && AnusLength <= 25) t.Name = "Мой анус выглядит как дупло.";// & $anustipe = 'растянутый' & $anustipe2 = 'растянутую'
                if (AnusLength > 25 && AnusLength <= 35) t.Name = "Мой анус не закрывается и выглядит как красное раздолбанное дупло из которого регулярно вылетают ветры.";// & $anustipe = 'раздолбанный' & $anustipe2 = 'раздолбанную'
                if (AnusLength > 35) t.Name = "Мой анус практически полностью уничтожен и представляет из себя бесформенную дыру.";// & $anustipe = 'разрушенный' & $anustipe2 = 'разрушенную'
            }
            else
            {
                t.Name = "В моей попке вставлена анальная пробка.";
            }
            return t;
        }

        public TextDTO GetSexualView()
        {
            var t = new TextDTO();
            if (SexualView < 0) { t.Name = "Подчиненность. "; }
            if (SexualView < 0 && SexualView > -25) { t.Name += "Текущий статус - склонная к подчинению"; }
            if (SexualView <= -25 && SexualView < 50) { t.Name += "Текущий статус  - покорная"; }
            if (SexualView <= -50 && SexualView < 75) { t.Name += "Текущий статус  - рабыня"; }
            if (SexualView <= -75) { t.Name += "Текущий статус  - на все готовая рабыня"; }

            if (SexualView > 0) { t.Name = "Доминантность. "; }
            if (SexualView > 0 && SexualView < 25) { t.Name += "Текущий статус - склонная к доминированию"; }
            if (SexualView >= 25 && SexualView < 50) { t.Name += "Текущий статус - домина"; }
            if (SexualView >= 25 && SexualView < 50) { t.Name += "Строгая - домина"; }
            if (SexualView >= 75) { t.Name += "Текущий статус - строгая госпожа"; }

            return t;
        }

        public TextDTO GetDrunk()
        {
            var t = new TextDTO();
            switch (DrunkStatus)
            {
                case 1:
                    t.color = "green";
                    t.Font = 15;
                    t.Name = "Я немного выпивши.";
                    break;
                case 2:
                    t.color = "blue";
                    t.Font = 15;
                    t.Name = "Я хорошо выпила.";
                    break;
                case 3:
                    t.color = "red";
                    t.Font = 15;
                    t.Name = "Я пьяная.";
                    break;
                case 4:
                    t.color = "red";
                    t.Font = 15;
                    t.Name = "Я в стельку пьяная.";
                    break;
                default:
                    t.color = "white";
                    t.Font = 1;
                    t.Name = "";
                    break;
            }
            return t;
        }

        public String Indicator(int value, int max)
        {
            String s = "";
            Double p = Math.Ceiling(Convert.ToDouble(((Double)value / max) * 100));
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 && p < 10)
                {
                    if (p >= 6)
                    {
                        s += "&#9619;";
                    }
                    else if (p >= 3)
                    {
                        s += "&#9618;";
                    }
                    else if (p > 0)
                    {
                        s += "&#9617;";
                    }
                    else
                    {
                        s += "<span style='color: #777777; text-decoration: underline'><span style='color: #FFFFFF;>&#9617;</span></span>";
                    }
                }
                else
                {
                    if (p >= i * 10)
                    {
                        s += "&#9608;";
                    }
                    else
                    {
                        s += "<span style='color: #777777; text-decoration: underline'><span style='color: #FFFFFF;'>&#9617;</span></span>";
                    }
                }
            }
            if (p > 60)
            {
                s = "<span style='color: green'>" + s + "</span>";
            }
            else if (p > 25)
            {
                s = "<span style='color: blue'>" + s + "</span>";
            }
            else
            {
                s = "<span style='color: red'>" + s + "</span>";
            }
            return s;
        }

        public TextDTO GetDressType()
        {
            var t = new TextDTO();
            if (FullNude == 1)
            {
                t.Name = "Я полностью голая.";
                return t;
            }
            if (NudeTop == 1)
            {
                t.Name = "Мои сисечки видны всем.";
                return t;
            }
            if (NudeTop == 2)
            {
                t.Name = "Я в лифчике.";
                return t;
            }
            if (NudePussy == 1)
            {
                t.Name = "Моя киска голая.";
                return t;
            }
            if (NudePussy == 2)
            {
                t.Name = "Я в трусиках.";
                return t;
            }
            switch (DressType)
            {
                case 0:
                    t.Name = "Я выгляжу обычно. На мне Повседневная одежда.";
                    break;
                case 1:
                    t.Name = "Я выгляжу как школьница. На мне Школьная одежда.";
                    break;
                case 2:
                    t.Name = "Я выгляжу привлекательно. На мне Клубная одежда.";
                    break;
                case 3:
                    t.Name = "Я выгляжу по деловому. На мне Офисная одежда.";
                    break;
                case 4:
                    t.Name = "Я готова к спорту. На мне Спортивная одежда.";
                    break;
                case 5:
                    t.Name = "Я выгляжу сексуально. На мне Вызвающая одежда.";
                    break;
                case 6:
                    t.Name = "Я выгляжу как Шлюха. На мне Одежда проститутки.";
                    break;
                case 7:
                    t.Name = "Я выгляжу как работница. На мне Рабочая одежда.";
                    break;
            }
            return t;
        }

        public TextDTO GetDressStatus()
        {
            var t = new TextDTO();
            switch (DressedComplitely)
            {
                case 0:
                    t.Name = "Я не одета по уличному.";
                    break;
                case 1:
                    t.Name = "Я готова идти на улицу.";
                    break;
            }
            return t;
        }

        public TextDTO GetPantiesStatus()
        {
            var t = new TextDTO();
            switch (WearPanties)
            {
                case 0:
                    t.Name = "На мне не одеты трусики.";
                    if (WearPantiesSkirt == 0)
                    {
                        t.Name += " Надо быть осторожной я в юбке.";
                    }
                    break;
                case 1:
                    t.Name = "";
                    break;
            }
            return t;
        }

        public String GetActorMirror()
        {
            return GetPlayer().GetHairStyle().Name + @"<br>
" + GetPlayer().GetMakeupStyle().Name + @" " + GetPlayer().GetTanStyle().Name + @" " + GetPlayer().GetSkinStyle().Name + @"<br>    
" + GetPlayer().GetVisualView().Name + @"<br>
" + GetPlayer().GetVisualDressView().Name + @"<br>
" + GetPlayer().GetLipsStyle().Name + @"<br>
" + GetPlayer().GetEyeStyle().Name + @" " + GetPlayer().GetEyeBrowsStyle().Name + @".";

        }

        public TextDTO GetBraStatus()
        {
            var t = new TextDTO();
            switch (WearBra)
            {
                case 0:
                    t.Name = "На мне не одет лифчик.";
                    break;
                case 1:
                    t.Name = "";
                    break;
            }
            return t;
        }



        /*
if energy >= 20:$energy = '<font color = green>Вы наелись до отвала.</font>'
if energy < 20 and energy >= 10:$energy = '<font color = blue>Вы сыты.</font>'
if energy < 10 and energy >= 2:$energy = '<font color = brown>Вы слегка голодны.</font>'
if energy < 2:$energy = '<font color = red>Вы очень голодны.</font>'

if water >= 20:$water = '<font color = green>Вы напились и больше не хотите пить.</font>'
if water < 20 and water >= 10:$water = '<font color = blue>Вы не хотите пить.</font>'
if water < 10 and water >= 2:$water = '<font color = brown>Вы хотите пить.</font>'
if water < 2:$water = '<font color = red>У вас сушняк.</font>'

if son >= 20:$son = '<font color = green>Вы выспались и больше не хотите спать.</font>'
if son < 20 and son >= 10:$son = '<font color = blue>Вы не хотите спать.</font>'
if son < 10 and son >= 2:$son = '<font color = brown>Вы хотите спать.</font>'
if son < 2:$son = '<font color = red>Вы засыпаете на ходу.</font>'
         */
    }
}
