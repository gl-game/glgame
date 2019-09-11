using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolasport : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Спортивный корпус");
            AddDescription(@"<img src='/images/school/sportkorpus.jpg' width='400' />");
            AddDescription(@"Из спортивного комплекса школы можно пройти в спортзал/женскую раздевалку/основное здание школы");
            AddDirection(game.location.shkolarazdevalkafemale, new { Name = "Идти в женскую раздевалку" });
            AddDirection(game.location.shkolazal, new
            {
                Name = "Идти в спортзал",
                c =
                (Action)(() =>
                 {
                     if (GetPlayer().DressType != 4)
                     {
                         GoTo("gorodok/school/shkolasport", "В зал нужно в спортивной форме");
                         return;
                     }
                 })
            });
            AddDirection(game.location.shkolamain, new
            {
                Name = "Выйти в кодидор",
                c =
                (Action)(() =>
                 {
                     if (GetPlayer().DressType != 1)
                     {
                         GoTo("gorodok/school/shkolasport", "В школу нужно идти в школьной форме");
                         return;
                     }
                 })
            });

            AddDynamicAction(new
            {
                Name = "Выйти в коридор",
                Scene = "gorodok/school/shkolamain",
                c =
            (Action)(() =>
             {
                 if (GetPlayer().DressType != 1)
                 {
                     GoTo("gorodok/school/shkolasport", "В школу нужно идти в школьной форме");
                     return;
                 }
             })
            });
        }
    }
}