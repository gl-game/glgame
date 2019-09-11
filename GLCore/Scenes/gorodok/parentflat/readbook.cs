using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class readbook : BaseScene
    {
        public override void GetView()
        {
            var otojti = new
            {
                Name = "Закончить",
                Scene = "gorodok/parentflat/myroom",
                t = 1
            };
            AddDynamicAction(otojti);

            AddDescription(@"
<center><img src='/images/imgpreview/book.jpg'></center>
Вы почесали голову поглядев на уже прочитанные книги Эх, даже почитать нечего, прогуляться что ли на рынок за новой книгой?
");
        }
    }
}