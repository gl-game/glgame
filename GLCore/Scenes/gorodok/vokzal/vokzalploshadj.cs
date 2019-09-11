using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.vokzal
{
    public class vokzalploshadj : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.vokzalgorodok);
            AddDirection(game.location.rinokgorodok);
            AddDirection(game.location.kafevokzal);
            AddDirection(game.location.oteljvokzal);
            AddDirection(game.location.centrgorodka);
            AddDirection(game.location.rajondoma);
            AddDescription(@"
<center><img src='/images/pic/vokzal.jpg'></center>
Маленькая тихая станция. Около вокзала стоит кафешка.<br>
Так же возле вокзала находится маленький отель для приезжих, почтовое отделение и отдел милиции. На площади огорожен забором не большой рынок.<br>
На привокзальной площади размещен маленький рынок<br>
Не большой отель в котором живут командировочные.");
        }
    }
}