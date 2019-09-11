using GLCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.Actors
{
    public interface IFemale : IActor
    {
        int Tits { get; set; }
        int Silicone { get; set; }
        int TitsSize { get; }

        int VaginaWidth { get; set; }
        int VaginaLength { get; set; }
        int AnusLength { get; set; }
        int AnusWidth { get; set; }

        int AnusPlug { get; set; }
        int MouthSize { get; set; }

        int VaginalSexCount { get; set; }
        int AnalSexCount { get; set; }
        int OralSexCount { get; set; }
        int HandSexCount { get; set; }

        int TotalSexCount { get; }

        int DressType { get; }
        int DressedComplitely { get; }
        int DressBeauty { get; }
        int WearPanties { get; }
        int WearPantiesSkirt { get; }
        int WearBra { get; }
        int NudeTop { get; }
        int NudePussy { get; }
        int FullNude { get; }
        int CompleteyNude { get; }
        int CanBreakSkirt { get; }

        int Earrings { get; set; }
        int BellyPiercing { get; set; }
        int VaginaPiercing { get; set; }

        /*
         *  0 - Мохнатка
         *  1 - Полностью Бритая бритвой
         *  2 - Полностью ваксация
         *  3 - Полоска бритвой
         *  4 - Полоска ваксация
         *  5 - Щетина
         *  6 - Щетина после ваксации
         */
        int PussyShave { get; set; }
        /*
         *  0 - Бритва
         *  1 - Ваксация
         */
        int PussyShaveStyle { get; set; }
        int PussyShaveСount { get; set; }

        /*
         *  0 - Мохнатка
         *  1 - Полностью Бритая бритвой
         *  2 - Полностью ваксация
         *  3 - Щетина
         *  4 - Щетина после ваксации
         */
        int LegsShave { get; set; }
        /*
         *  0 - Бритва
         *  1 - Ваксация
         */
        int LegsShaveStyle { get; set; }
        int LegsShaveСount { get; set; }

        /*
         *  0 - Мохнатка
         *  1 - Полностью Бритая бритвой
         *  2 - Полностью ваксация
         *  3 - Щетина
         *  4 - Щетина после ваксации
         */
        int HandsShave { get; set; }
        /*
         *  0 - Бритва
         *  1 - Ваксация
         */
        int HandsShaveStyle { get; set; }
        int HandsShaveСount { get; set; }

        int Beauty { get; }

        int HaveCosmetics { get; }
        int Cosmetics { get; }
        int CosmeticsBreak { get; set; }

        int Pomade { get; set; }
        DateTime PomadeExpire { get; set; }
        int EyeShadow { get; set; }
        DateTime EyeShadowExpire { get; set; }
        
    }
}
