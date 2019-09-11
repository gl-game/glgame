using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok
{
    public class centrgorodka : BaseScene
    {
        public override void GetView()
        {
            AddDirection(game.location.localsaloon, new { t = 15 });
            AddDirection(game.location.rajondoma, new { t = 5, Name = "Иди к подъезду", Description = "Подезд вашего дома" });
            AddDirection(game.location.shkolnijdvor, new { t = 5, Name = "Иди к школе" });
            AddDirection(game.location.vokzalploshadj, new { t = 5, Name = "К вокзалу" });
            AddDirection(game.location.sportklubdvor, new { t = 5, Name = "К Дому культуры" });
            AddDescription("Центр районного городка");

            var saloon = RegisterEvent((Action)(() =>
             {
                 AddTime(15);
             }), "gorodok/beautysaloon/saloonsmallcity");

            var shkola = RegisterEvent((Action)(() =>
             {
                 AddTime(5);
             }), "gorodok/school/shkolnijdvor");

            var rajondoma = RegisterEvent((Action)(() =>
             {
                 AddTime(5);
             }), "gorodok/rajondoma");

            var vokzalploshadj = RegisterEvent((Action)(() =>
             {
                 AddTime(5);
             }), "gorodok/vokzal/vokzalploshadj");


            AddDescription(@"
<center><H4>Городок</H4></center>
<center><img src='/images/pic/gorodok.jpg'></center>
Тихий провинциальный городишко неотличимый от тысяч ему подобных городков. Отреставрированные купола церквей возвышаются над полуразвалившимися хибарами которые строили еще пленные немцы.<br>
В старенькой пяти этажке, в <a href='callback:" + rajondoma + @"'>подъезде №1</a> находится квартира ваших родителей. <br>
<a href='callback:" + vokzalploshadj + @"'>Привокзальная площадь</a><br>
Районная поликлиника, рядом с которой находиться аптека<br>
Районный дом культуры<br>
Местная <a href='callback:" + shkola + @"'>школа</a><br>
Профессиональный лицей.
Единственный крупный магазин в городишке супермаркет<br>
Местный <a href='callback:" + saloon + @"'>салон красоты.</a> Единственный и неповторимый<br>
Небольшой городской сквер, в котором отдыхают люди. В киоске рядом с ним продают сигареты.<br>
Небольшое озеро притаилось за Городком.<br>
Градообразующее предприятие Швейная фабрика имени Парижской коммуны<br>
");
        }
    }
}
