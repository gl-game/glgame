using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class shkoladushfemale : BaseScene
    {
        public override void GetView()
        {
            if (Get("show_bath_staff") == 1)
            {
                DrawBoxStaff(GetBathRoom());
                AddDirection(game.location.shkoladushfemale, new
                {
                    Name = "Закрыть шкафчик",
                    c = (Action)(() =>
                 {
                     Set("show_bath_staff", 0);
                 })
                }, true);

            }
            else
            {
                if (GetPlayer().CompleteyNude == 0)
                {
                    AddDescription("Душ в женской раздевалке");
                    AddDescription("<img src='/images/school/sport/femaledush.jpg' width='270'>");
                    AddDirection(game.location.shkolarazdevalkafemale, new { Name = "В женскую раздевалку" }, true);
                    AddDynamicAction(new
                    {
                        Name = "Раздеться полностью и зайти в душ",
                        c = (Action)(() =>
             {
                 GetBathRoom().Undress(GetPlayer());
             })
                    });

                    AddDynamicAction(new
                    {
                        Name = "Посмотреть что есть в душе",
                        c = (Action)(() =>
             {
                 Set("show_bath_staff", 1);
             })
                    });

                }
                else
                {
                    AddDescription(@"Я в душе");
                    AddDescription("<img src='/images/me/meshowerschool.jpg' height='100'>");
                    DrawBathRoomStaff(GetBathRoom());

                    AddDirection(game.location.shkoladushfemale, new
                    {
                        Name = "Выйти из душа и одеться",
                        c = (Action)(() =>
                 {
                     GetBathRoom().Dress(GetPlayer());
                 })
                    }, true);

                    AddDescription(@"
		<table width='100%'>
			<tr>
				<td width='33%'>" + GetPlayer().GetPussyStyle().Name + @"<br><img src='/images/me/pussystyle/Pussy" + GetPlayer().PussyShave + @".jpg' width='200'></td>
				<td width='33%'>" + GetPlayer().GetLegsStyle().Name + @"<br><img src='/images/me/legsstyle/Legs" + GetPlayer().LegsShave + @".jpg' width='200'></td>
				<td width='33%'>" + GetPlayer().GetHandsStyle().Name + @"<br><img src='/images/me/handsstyle/Hands" + GetPlayer().HandsShave + @".jpg' width='200'></td>
			</tr>
		</table>		
		");

                    //Hours 20 Fizruk

                }
            }
        }
    }
}
