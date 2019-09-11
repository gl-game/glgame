using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class razdevalkaskaf : BaseScene
    {
        public override void GetView()
        {
            AddDescription("Мой шкафчик в школьной раздевалке");
            DrawWadrobeStaff(GetWardrobe());
            AddDirection(game.location.shkolarazdevalkafemale, new
            {
                Name = "Закрыть шкаф",
                Description = "",
                c =
                (Action)(() =>
                 {
                     if (GetPlayer().DressType != 4 && GetPlayer().DressType != 1)
                     {
                         GoTo("gorodok/school/razdevalkaskaf", "Надо бы одеться подобающе. Надо одель либо школьную либо спортивную форму");
                         return;
                     }
                 })
            });
            AddDynamicAction(new
            {
                Name = "Закрыть шкаф",
                Scene = "gorodok/school/shkolarazdevalkafemale",
                c =
                (Action)(() =>
                 {
                     if (GetPlayer().DressType != 4 && GetPlayer().DressType != 1)
                     {
                         GoTo("gorodok/school/razdevalkaskaf", "Надо бы одеться подобающе. Надо одель либо школьную либо спортивную форму");
                         return;
                     }
                 })
            });
        }
    }
}