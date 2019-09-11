using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.vokzal
{
    public class magazinalkogolja : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Алкогольный магазин");
            DrawShopStaff(GetShop());
            AddDirection(game.location.rinokgorodok);


            AddDynamicAction(new
            {
                Name = "Выйти на рынок",
                Scene = "gorodok/vokzal/rinokgorodok"
            });
        }
    }
}

