using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkolarazdevalkafemale : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Раздевалка");
            AddDescription(@"<img src='/images/school/zenskrazdevalka.jpg' width='400' />");
            AddDirection(game.location.shkolasport, new { Name = "Выйти из раздевалки" });
            AddDirection(game.location.razdevalkaskaf, new { Name = "Переодеться у шкафчика" });

            if (Get("saw_girls") == 0)
            {
                AddDynamicScene(new
                {
                    Name = "Глазеть на девченок",
                    c = (Action)(() =>
             {
                 AddTime(2);
                 GetPlayer().Excite += Random(1, 7);
                 GetPlayer().SexualOrientation--;
                 AddDescription(@"Я наблюдаю как девченки переодеваются");
                 AddDynamicAction(new
                 {
                     Name = "Далее...",
                     c = (Action)(() =>
      {
          AddTime(2);
          SetTimeout("saw_girls", 1, 300);
      })
                 });
             })
                });
            }


            AddDynamicAction(new
            {
                Name = "Переодеться",
                Scene = "gorodok/school/razdevalkaskaf"
            });

            AddDynamicAction(new
            {
                Name = "Идти в душ",
                Scene = "gorodok/school/shkoladushfemale"
            });

            AddDynamicAction(new
            {
                Name = "Выйти из раздевалки",
                Scene = "gorodok/school/shkolasport"
            });
        }
    }
}