using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.beautysaloon
{
    public class manukur : BaseScene
    {
        public override void GetView()
        {
            var e1 = RegisterEvent((Action)(() =>
 {
     int a = 1500;
     ShowMessage("Вам сделали первый манткюр. Потрачено " + a + " рублей.");
 }), "gorodok/beautysaloon/saloonsmallcity");
            var e2 = RegisterEvent((Action)(() =>
             {
                 int a = 2000;
                 ShowMessage("Вам сделали второй манткюр. Потрачено " + a + " рублей.");
             }), "gorodok/beautysaloon/saloonsmallcity");
            var e3 = RegisterEvent((Action)(() =>
             {
                 int a = 2500;
                 ShowMessage("Вам сделали третий манткюр. Потрачено " + a + " рублей.");
             }), "gorodok/beautysaloon/saloonsmallcity");
            var e4 = RegisterEvent((Action)(() =>
             {
                 int a = 4000;
                 ShowMessage("Вам сделали четвертый манткюр. Потрачено " + a + " рублей.");
             }), "gorodok/beautysaloon/saloonsmallcity");
            var e5 = RegisterEvent((Action)(() =>
             {
                 int a = 7000;
                 ShowMessage("Вам сделали пятый манткюр. Потрачено " + a + " рублей.");
             }), "gorodok/beautysaloon/saloonsmallcity");
            var e6 = RegisterEvent((Action)(() =>
             {
                 int a = 9000;
                 ShowMessage("Вам сделали шестой манткюр. Потрачено " + a + " рублей.");
             }), "gorodok/beautysaloon/saloonsmallcity");
            AddDescription(@"<table style=""width: 90%; margin: 20px"" border=""1"">
	<tr>
		<td align=""center""><a href=""callback:" + e1 + @""">Выбрать (1500р)</a></td>
		<td align=""center""><a href=""callback:" + e2 + @""">Выбрать (2000р)</a></td>
		<td align=""center""><a href=""callback:" + e3 + @""">Выбрать (2500р)</a></td>
	</tr>
	<tr>
		<td align=""center""><a href=""callback:" + e4 + @""">Выбрать (4000р)</a></td>
		<td align=""center""><a href=""callback:" + e5 + @""">Выбрать (7000р)</a></td>
		<td align=""center""><a href=""callback:" + e6 + @""">Выбрать (9000р)</a></td>
	</tr>
</table>");

            AddDynamicAction(new
            {
                Name = "Выбрать другое",
                Scene = "gorodok/beautysaloon/saloonsmallcity"
            });
        }
    }
}