using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.vokzal
{
    public class rinokgorodok : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.vokzalploshadj);
            AddDirection(game.location.magazinalkogolja);
            AddDirection(game.location.larjokmelochej);

            AddDescription(@"<center><img src='/images/pic/Grinok.jpg'></center>
Маленький рынок расположен возле вокзала");

            AddDynamicAction(new
            {
                Name = "Выйти на привокзальную площадь",
                Scene = "gorodok/vokzal/rinokgorodok",
                t = 5
            });

            AddDynamicAction(new
            {
                Name = "Идти к дому",
                Scene = "gorodok/rajondoma",
                t = 15
            });
        }
    }
}

