using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.beautysaloon
{
    public class saloonsmallcity : BaseScene
    {
        public override void GetView()
        {
            AddDynamicAction(new
            {
                Name = "Сделать завивку волос (1000р)",
                Scene = "gorodok/beautysaloon/saloonsmallcity",
                c = (Action)(() =>
             {
                 int a = 1000;
                 ShowMessage(@"Вы сделали завивку волос.
		Потрачено " + a + @" рублей
		");
             })
            });
            AddDynamicAction(new
            {
                Name = "Сделать маникюр (от 1500р)",
                Scene = "gorodok/beautysaloon/manukur"
            });
            AddDynamicAction(new
            {
                Name = "Сделать педикюр (от 1500р)",
                Scene = "gorodok/beautysaloon/pedikur"
            });
            AddDynamicAction(new
            {
                Name = "Ваксация рук (700р)",
                Scene = "gorodok/beautysaloon/saloonsmallcity",
                c = (Action)(() =>
             {
                 int a = 700;
                 ShowMessage(@"Вы сделали ваксацаю рук.
		Потрачено " + a + @" рублей
		");
             })
            });
            AddDynamicAction(new
            {
                Name = "Ваксация ног (1000р)",
                Scene = "gorodok/beautysaloon/saloonsmallcity",
                c = (Action)(() =>
             {
                 int a = 1000;
                 ShowMessage(@"Вы сделали ваксацаю ног.
		Потрачено " + a + @" рублей
		");
             })
            });
            AddDynamicAction(new
            {
                Name = "Ваксация бикини (3000р)",
                Scene = "gorodok/beautysaloon/saloonsmallcity",
                c = (Action)(() =>
             {
                 int a = 3000;
                 ShowMessage(@"Вы сделали ваксацаю бикини.
		Потрачено " + a + @" рублей
		");
             })
            });
            AddDynamicAction(new
            {
                Name = "Полная ваксация бикини (5000р)",
                Scene = "gorodok/beautysaloon/saloonsmallcity",
                c = (Action)(() =>
             {
                 int a = 5000;
                 ShowMessage(@"Вы сделали полную ваксацаю бикини.
		Потрачено " + a + @" рублей
		");
             })
            });
            AddDirection(game.location.centrgorodka, new { t = 5, Name = "Выйти в город", Description = "5мин" });
            AddDescription(@"
Салон красоты
<center><img src='/images/qwest/alter/parikmaherskoy1.jpg'></center>");
        }
    }
}

