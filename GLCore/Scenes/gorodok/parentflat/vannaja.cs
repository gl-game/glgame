using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.parentflat
{
    public class vannaja : BaseScene
    {
        public override void GetView()
        {
            if (Get("show_bath_staff") == 1)
            {
                DrawBoxStaff(GetBathRoom());
                AddDirection(game.location.vannaja, new
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
                    AddDescription("Ванная в квартире родителей");
                    AddDescription(@"<center><img src='/images/imgpreview/vanna.jpg' height='250'></center>
					Ванная тесная и очень простенькая.");
                    AddDirection(game.location.koridor, new { Name = "Выйти в коридор" }, true);

                    if (GetPlayer().HaveCosmetics == 1)
                    {
                        AddDynamicAction(new
                        {
                            Name = "Смыть косметику (5-10 мин.)",
                            c = (Action)(() =>
                            {
                                GetPlayer().ClearCosmetics();
                                int r = Random(5, 10);
                                AddTime(r);
                                if (GetPlayer().Sweat > 0)
                                {
                                    GetPlayer().Sweat = GetPlayer().Sweat - 1;
                                }
                                ShowMessage("Я смыла косметику, прошло " + r + " минут");
                            })
                        });
                    }
                    else
                    {
                        AddDynamicAction(new
                        {
                            Name = "Умыть лицо (5-10 мин.)",
                            c = (Action)(() =>
                            {
                                GetPlayer().ClearCosmetics();
                                int r = Random(5, 10);
                                AddTime(r);
                                if (GetPlayer().Sweat > 0)
                                {
                                    GetPlayer().Sweat = GetPlayer().Sweat - 1;
                                }
                                ShowMessage("Я умылась, прошло " + r + " минут");
                            })
                        });
                    }


                    AddDynamicAction(new
                    {
                        Name = "Раздеться полностью",
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
                    AddDescription(@"Я в душе в квартире родителей");
                    AddDescription("<img src='/images/me/dush.jpg' height='100'>");
                    DrawBathRoomStaff(GetBathRoom());

                    AddDirection(game.location.vannaja, new
                    {
                        Name = "Выйти из душа и одеться",
                        c = (Action)(() =>
                        {
                            GetBathRoom().Dress(GetPlayer());
                        })
                    }, true);

                    AddDynamicAction(new
                    {
                        Name = "Сполоснуться в ванной 15 минут",
                        c = (Action)(() =>
                        {
                            ShowMessage("Я сполоснулась в ванной 15 минут");
                            AddTime(15);
                            GetPlayer().Sweat = GetPlayer().Sweat / 2;
                        })
                    });


                    AddDynamicAction(new
                    {
                        Name = "Мыться в ванной 40 минут",
                        c = (Action)(() =>
                        {
                            ShowMessage("Я сполоснулась в ванной 15 минут");
                            AddTime(40);
                            GetPlayer().Wash();
                        })
                    });

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
