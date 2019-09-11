using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat.sister
{
    public class supermarket : BaseScene
    {
        public override void GetView()
        {
            var otojti = new
            {
                Name = "Отойти",
                Scene = "supermarket/head"
            };
            AddDynamicAction(otojti);
            AddDirection(game.location.koridor);
            AddDescription(@"
<center><img src='/images/qwest/alter/sister.jpg'></center>
Ваша сестра Аня немного старше вас. Она закончила школу, но не сумела поступить в университет и теперь работает в магазине продавщицей.");
            AddDescription(GetActorGeneralProperties(game.actor.sistervera));
            AddDescription("- Света, не мешай мне, не видишь, у меня покупатели.");
        }
    }
}