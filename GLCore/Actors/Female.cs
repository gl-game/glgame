using GLCore.DTO;
using GLCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actors
{
    public class Female : Actor, IActor, IFemale
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

        public int HaveCosmetics
        {
            get
            {
                if (Parfume > 0 || Pomade > 0 || EyeShadow > 0 || CosmeticsBreak == 1)
                {
                    return 1;
                }
                return 0;
            }
        }
        public int Cosmetics
        {
            get
            {
                int csom = Parfume + Pomade + EyeShadow;
                if (CosmeticsBreak == 1)
                {
                    csom = -4;
                }
                return csom;
            }
        }
        public int Beauty
        {
            get
            {
                int ps = 0;
                if (PussyShave == 1 || PussyShave == 3) { ps = 2; }
                if (PussyShave == 5) { ps = 1; }
                if (PussyShave == 2 || PussyShave == 4) { ps = 4; }
                if (PussyShave == 6) { ps = 2; }

                int ls = 0;
                if (LegsShave == 1) { ls = 2; }
                if (LegsShave == 2) { ls = 4; }
                if (LegsShave == 3) { ls = 1; }
                if (LegsShave == 4) { ls = 2; }

                int hs = 0;
                if (HandsShave == 1) { hs = 2; }
                if (HandsShave == 2) { hs = 4; }
                if (HandsShave == 3) { hs = 1; }
                if (HandsShave == 4) { hs = 2; }

                int eb = 0;
                if (EyeBrows > 0 || EyeBrowsPermanent > 0) { eb = 1; }

                int ft = 0;
                if (Fat < 15) { ft = 2; }
                if (Fat >= 15 && Fat < 20) { ft = 1; }
                if (Fat >= 20 && Fat < 25) { ft = 0; }
                if (Fat >= 25 && Fat < 30) { ft = -1; }
                if (Fat >= 30 && Fat < 35) { ft = -2; }
                if (Fat >= 35 && Fat < 40) { ft = -4; }
                if (Fat >= 40 && Fat < 45) { ft = -6; }
                if (Fat >= 45 && Fat < 50) { ft = -9; }
                if (Fat >= 45 && Fat < 50) { ft = -12; }
                if (Fat >= 50) { ft = -16; }
                int totlabeauty = TitsSize + HairBrush + HairStyle + EyeSize + Cosmetics + LipSize + SkinTone + EyelashsSize + SkinStatus + ps + ls + ft + hs + eb;
                if (totlabeauty < 0)
                {
                    totlabeauty = 0;
                }
                return totlabeauty;
            }
        }

        public int DressType
        {
            get
            {
                int HatDressType = ((Hat != null) ? Hat.DressType : 0);
                int BraDressType = ((Bra != null) ? Bra.DressType : 0);
                int PantiesDressType = ((Panties != null) ? Panties.DressType : 0);
                int TopDressDressType = ((TopDress != null) ? TopDress.DressType : 0);
                int BottomDressDressType = ((BottomDress != null) ? BottomDress.DressType : 0);
                int StokingsDressType = ((Stockings != null) ? Stockings.DressType : 0);
                if (BottomDress != null && BottomDress.GetType() == typeof(Pants))
                {
                    StokingsDressType = 0;
                }
                int ShoesDressType = ((Shoes != null) ? Shoes.DressType : 0);
                int BagDressType = ((Bag != null) ? Bag.DressType : 0);
                int SmallBagDressType = ((SmallBag != null) ? SmallBag.DressType : 0);

                if (TopDressDressType == 4 && BottomDressDressType == 4 && ShoesDressType == 4 && Bag == null && SmallBag == null && Stockings == null)
                {
                    return 4;
                }

                if (TopDressDressType == 1 && (BottomDressDressType == 1 || TopDress.ConflictSlot == 3) && ShoesDressType == 1)
                {
                    return 1;
                }

                if (TopDressDressType == 5 && (BottomDressDressType == 5 || TopDress.ConflictSlot == 3) && ShoesDressType == 5 && (Bag == null || Bag.DressType == 5) &&
                    (SmallBagDressType == 5 || SmallBag == null) && Bag == null)
                {
                    if (BottomDress != null && Stockings != null && StokingsDressType == 5 && BottomDress.GetType() == typeof(Skirt))
                    {
                        return 5;
                    }
                    return 2;
                }

                if (TopDressDressType == 3 && (BottomDressDressType == 3 || TopDress.ConflictSlot == 3) && ShoesDressType == 3)
                {
                    return 3;
                }

                if ((TopDressDressType == 2 || TopDressDressType == 5) && (BottomDressDressType == 2 || BottomDressDressType == 5 || TopDress.ConflictSlot == 3) && (ShoesDressType == 2 || ShoesDressType == 5)
                    && (Bag == null || Bag.DressType == 2 || Bag.DressType == 5)
                    && (SmallBagDressType == 2 || SmallBagDressType == 5))
                {
                    if (BottomDress != null && Stockings != null && StokingsDressType != 2 && StokingsDressType != 5 && BottomDress.GetType() == typeof(Skirt))
                    {
                        return 0;
                    }
                    return 2;
                }

                return 0;
            }
        }

        public int DressedComplitely
        {
            get
            {
                if (NudeTop > 0 || NudePussy > 0)
                {
                    return 0;
                }
                if (Shoes != null && TopDress != null && TopDress.ConflictSlot == 3)
                {
                    return 1;
                }
                if (Shoes != null && TopDress != null && BottomDress != null)
                {
                    return 1;
                }
                return 0;
            }
        }

        public int WearPanties
        {
            get
            {
                if (Panties != null)
                {
                    return 1;
                }
                return 0;
            }
        }

        public int WearPantiesSkirt
        {
            get
            {
                if (Panties == null && BottomDress != null && BottomDress.GetType() == typeof(Skirt))
                {
                    return 0;
                }
                if (Panties == null && BottomDress == null && TopDress != null && TopDress.GetType() == typeof(Dress) && TopDress.ConflictSlot == 3)
                {
                    return 0;
                }
                return 1;
            }
        }

        public int NudeTop
        {
            get
            {
                if (TopDress == null && Bra == null && Coat == null)
                {
                    return 1;
                }
                if (TopDress == null && Bra != null && Coat == null)
                {
                    return 2;
                }
                return 0;
            }
        }

        public int NudePussy
        {
            get
            {
                if (TopDress != null && TopDress.ConflictSlot == 3)
                {
                    return 0;
                }
                if (BottomDress == null && Panties == null)
                {
                    return 1;
                }
                if (BottomDress == null && Panties != null)
                {
                    return 2;
                }
                return 0;
            }
        }

        public int WearBra
        {
            get
            {
                if (Bra != null)
                {
                    return 1;
                }
                return 0;
            }
        }

        public int FullNude
        {
            get
            {
                if (NudeTop == 1 && NudePussy == 1)
                {
                    return 1;
                }
                return 0;
            }
        }

        public int CompleteyNude
        {
            get
            { 
                if (Bag == null && SmallBag == null && Hat == null && TopDress == null && BottomDress == null && Shoes == null && Stockings == null && Coat == null && Bra == null && Panties == null )
                {
                    return 1;
                }
                return 0;
            }
        }

        public int CanBreakSkirt
        {
            get
            {
                if (TopDress == null)
                {
                    return 0;
                }
                if (TopDress.ConflictSlot == 3 || (BottomDress == null || BottomDress.GetType() == typeof(Skirt))) {
                    return 1;
                }
                return 0;
            }
        }

        public int DressBeauty
        {
            get
            {
                if (Shoes != null && TopDress != null && TopDress.ConflictSlot == 3)
                {
                    return Shoes.Beauty + TopDress.Beauty + ((Hat != null) ? Hat.Beauty : 0) + ((Bag != null) ? Bag.Beauty : 0) + ((SmallBag != null) ? SmallBag.Beauty : 0) + ((Stockings != null) ? Stockings.Beauty : 0);
                }
                else if (Shoes != null && TopDress != null && BottomDress != null)
                {
                    return Shoes.Beauty + TopDress.Beauty + BottomDress.Beauty + ((Hat != null) ? Hat.Beauty : 0) + ((Bag != null) ? Bag.Beauty : 0) + ((SmallBag != null) ? SmallBag.Beauty : 0) + ((Stockings != null && BottomDress.GetType() == typeof(Skirt)) ? Stockings.Beauty : 0);
                }
                else
                {
                    int HatBeauty = ((Hat != null) ? Hat.Beauty : 0);
                    int BraBeauty = ((Bra != null) ? Bra.Beauty : 0);
                    int PantiesBeauty = ((Panties != null) ? Panties.Beauty : 0);
                    int TopDressBeauty = ((TopDress != null) ? TopDress.Beauty : BraBeauty);
                    int BottomDressBeauty = ((BottomDress != null) ? BottomDress.Beauty : PantiesBeauty);
                    int StokingsBeauty = ((Stockings != null) ? Stockings.Beauty : 0);
                    if (BottomDress != null && BottomDress.GetType() == typeof(Pants))
                    {
                        StokingsBeauty = 0;
                    }
                    int ShoesBeauty = ((Shoes != null) ? Shoes.Beauty : 0);
                    int BagBeauty = ((Bag != null) ? Bag.Beauty : 0);
                    int SmallBagBeauty = ((SmallBag != null) ? SmallBag.Beauty : 0);
                    int CurrentBeayty = HatBeauty + BraBeauty + PantiesBeauty + TopDressBeauty + BottomDressBeauty + StokingsBeauty + ShoesBeauty + BagBeauty + SmallBagBeauty;

                    if (NudePussy == 1 || NudeTop == 1)
                    {
                        int b = Beauty;
                        if (b < 5) { b = 4; }
                        CurrentBeayty = CurrentBeayty + (b / 2);
                    }
                    if (FullNude == 1)
                    {
                        CurrentBeayty = Beauty;
                    }
                    return CurrentBeayty;
                }
            }
        }

        public void WashFace()
        {
            CosmeticsBreak = 0;
            Pomade = 0;
            Parfume = 0;
            EyeShadow = 0;
        }

        public Female()
            : base()
        {
            Gender = 2;
        }

        public int BreastSize
        {
            get
            {
                return Talia + 10 + Fat + Silicone;
            }
        }

        public int AssSize
        {
            get
            {
                return Talia + 15 + Fat + (Vmeat) / 2;
            }
        }

        public int Silicone { get; set; }
        public int Tits { get; set; }
        public int TitsSize
        {
            get
            {
                return Tits + Silicone;
            }
        }
        public int VaginaWidth { get; set; }
        public int VaginaLength { get; set; }
        public int AnusWidth { get; set; }
        public int AnusLength { get; set; }

        public int AnusPlug { get; set; }
        public int MouthSize { get; set; }

        public int VaginalSexCount { get; set; }
        public int AnalSexCount { get; set; }
        public int OralSexCount { get; set; }
        public int HandSexCount { get; set; }

        public int IsVirgin
        {
            get
            {
                if (VaginalSexCount == 0)
                {
                    return 1;
                }
                return 0;
            }
        }

        public int TotalSexCount
        {
            get
            {
                return VaginalSexCount + AnalSexCount + OralSexCount + HandSexCount;
            }
        }

        public static String GetFemaleSexProperties(Female actor)
        {
            String a = "";
            a += "Размер груди: " + actor.TitsSize + "<br>";
            a += "Размер глаз: " + actor.EyeSize + "<br>";
            a += "Вместимость рта: " + actor.MouthSize + "<br>";
            a += "Вметимость влагалища: " + actor.VaginaWidth + "<br>";
            a += "Глубина влагалища: " + actor.VaginaLength + "<br>";
            a += "Вметимость попы: " + actor.AnusWidth + "<br>";
            a += "Глубина попы: " + actor.AnusLength + "<br>";
            return a;
        }
        /*
        *  0 - Нет сережек
        *  1 - В ушах сережки
         */
        public int Earrings { get; set; }
        /*
        *  0 - Нет пирсинга в пупке
        *  1 - Пирсинг в пупке
         */
        public int BellyPiercing { get; set; }
        /*
        *  0 - Нет пирсинга в клиторе
        *  1 - Пирсинг в клиторе
         */
        public int VaginaPiercing { get; set; }

        /*
        *  0 - Мохнатка
        *  1 - Полностью Бритая бритвой
        *  2 - Полностью ваксация
        *  3 - Полоска бритвой
        *  4 - Полоска ваксация
        *  5 - Щетина
        *  6 - Щетина после ваксации
        */
        public int PussyShave { get; set; }
        /*
         *  0 - Бритва
         *  1 - Ваксация
         */
        public int PussyShaveStyle { get; set; }
        public int PussyShaveСount { get; set; }

        /*
         *  0 - Мохнатка
         *  1 - Полностью Бритая бритвой
         *  2 - Полностью ваксация
         *  3 - Щетина
         *  4 - Щетина после ваксации
         */
        public int LegsShave { get; set; }
        /*
         *  0 - Бритва
         *  1 - Ваксация
         */
        public int LegsShaveStyle { get; set; }
        public int LegsShaveСount { get; set; }

        public int HandsShave { get; set; }
        /*
         *  0 - Бритва
         *  1 - Ваксация
         */
        public int HandsShaveStyle { get; set; }
        public int HandsShaveСount { get; set; }

        public int CosmeticsBreak { get; set; }
        public int Pomade { get; set; }
        public DateTime PomadeExpire { get; set; }
        public int EyeShadow { get; set; }
        public DateTime EyeShadowExpire { get; set; }

        public new String GetActorExcite()
        {
            if (Excite == 0) return Name + " не возбуждена";
            if (Excite >= 0 && Excite < 20) return Name + " слабо возбуждена";
            if (Excite >= 20 && Excite < 40) return Name + " легко возбуждена";
            if (Excite >= 40 && Excite < 60) return Name + " хорошо возбуждена";
            if (Excite >= 60 && Excite < 80) return Name + " очень возбуждена";
            if (Excite >= 80) return Name + " сильно возбуждена";
            if (Excite == 100) return Name + " сейчас кончит";
            return "";
        }
    }
}
