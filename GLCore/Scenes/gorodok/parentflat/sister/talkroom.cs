using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat.sister
{
    public class talkroom : BaseScene
    {
        public override void GetView()
        {
            var otojti = new
            {
                Name = "Отойти",
                Scene = "gorodok/parentflat/myroom"
            };
            AddDynamicAction(otojti);
            AddDirection(game.location.koridor);
            AddDescription(@"
<center><img src='/images/qwest/alter/sister.jpg'></center>
Ваша сестра Аня немного старше вас. Она закончила школу, но не сумела поступить в университет и теперь работает в магазине продавщицей.");
            AddDescription(GetActorGeneralProperties(game.actor.sistervera));
            AddDescription("<br>");
            AddDescription(GetFemaleSexProperties(game.actor.sistervera));
        }
    }
}