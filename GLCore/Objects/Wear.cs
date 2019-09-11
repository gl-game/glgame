using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore.Objects
{
    [Serializable]
    public class Wear : GameStuff, IWear
    {
        public int WearSlot { get; set; }
        public int Durability { get; set; }
        public int DurabilityMax
        {
            get
            {
                return 100;
            }
        }
        public int Heat { get; set; }
        public int Beauty { get; set; }
        /*
         * 0 - Повседневная одежда 
         * 1 - Школьная одежда
         * 2 - Клубная одежда
         * 3 - Офисная одежда
         * 4 - Спортивная одежда
         * 5 - Вызвающая одежда
         * 6 - Одежда проститутки
         */
        public int DressType { get; set; }
        public int ConflictSlot
        {
            get
            {
                return 0;
            }
        }
    }
}
