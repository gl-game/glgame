using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class zal : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.koridor);
            var otojti = new
            {
                Name = "Выйти в коридор",
                Scene = "gorodok/parentflat/koridor"
            };
            AddDynamicAction(otojti);
            AddDescription(@"
<center><img src='/images/imgpreview/sitrPar.jpg'></center>
У окна стоит телевизор. Напротив телевизора находится диван, на котором по ночам спит ваш брат. У стены стоит стенка с посудой и книгами.");

        }
    }
}