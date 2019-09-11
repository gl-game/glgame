using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat.sister
{
    public class talkroomwalking : BaseScene
    {
        public override void GetView()
        {
            var otojti = new
            {
                Name = "Отойти",
                Scene = "gorodok/parentflat/myroom"
            };
            AddDynamicAction(otojti);

            AddDynamicAction(new
            {
                Name = "Идти гулять",
                Scene = "club/territorywalk"
            });

            AddDirection(game.location.koridor);
            AddDescription(@"
<center><img src='/images/qwest/alter/sister.jpg'></center>
Эй сестренка пойдем погуляем?");
            AddDescription(GetActorGeneralProperties(game.actor.sistervera));
        }
    }
}