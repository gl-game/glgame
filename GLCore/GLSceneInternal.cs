using GLCore.Locations;
using GLCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore
{
    public partial class GLScene : IDisposable
    {
        public void DrawShopStuff(Shop s)
        {
            if (s.Things.Count > 0)
            {
                var ls = s.Things.GroupBy(x => new { x.Name, x.id, x.Price, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();//.GroupBy(n => n.); 
                String html = @"<table class=""tableview"" border='1' cellpadding='2' cellspacing='2'>
                    <tr>
                    <th>Название</th>
                    <th>Цена</th>
                    <th>Доступное Кол-во</th>
                    <th>Купить</th>
                 </tr>";

                foreach (var staff in ls)
                {
                    var stf = staff.FirstOrDefault();
                    String id = RegisterEvent(() =>
                    {
                        if (data.BuyThing(stf, s, 1, Convert.ToInt32(stf.Price)))
                        {
                            sc.Message = "Товар " + stf.Name + " куплен";
                        }
                        else
                        {
                            sc.Message = "Недостаточно места в сумке";
                        }
                    });
                    html += @"<tr>
                    <td>" + stf.Name + ((stf.UseCount > 0) ? "(" +stf.UseCount + " раз)" : "") + @"</td>
                    <td>" + stf.Price + @" руб.</td>
                    <td>" + staff.Count + @"</td>
                    <td><a href='callback:" + id + @"'>Купить</a></td>
                 </tr>";
                }

                html += "</table>";
                sc.Description += html + "<br/>";
            }
        }

        public void DrawBathRoomStaff(BathRoom bath)
        {
            if (bath.Bag == null && bath.SmallBag == null && bath.Things.Count == 0)
            {
                return;
            }
            else
            {
                if (bath.Bag != null)
                {
                    String html = "<b>" + bath.Bag.Name + "</b><br />";
                    var ls = bath.Bag.Things.GroupBy(x => new { x.Name, x.id, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();

                    html += "<table class=\"tableview\">";
                    foreach (var stfobj in ls)
                    {
                        String Methods = "";
                        var stf = stfobj.FirstOrDefault();
                        if (stf.GetType() == typeof(WashSoap))
                        {
                            String WashEv = RegisterEvent(() =>
                            {
                                if (!GetPlayer().WashMySelf((WashSoap)stf))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.Bag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);                          

                            Methods += "<a href='callback:" + WashEv + @"'>Мыться</a>";
                        }
                        if (stf.GetType() == typeof(Shaver))
                        {
                            String ShavePussyFull = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShavePussy((Shaver)stf, 0))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.Bag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShavePussyHalf = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShavePussy((Shaver)stf, 1))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.Bag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShaveLegs = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShaveLegs((Shaver)stf))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.Bag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShaveHands = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShaveHands((Shaver)stf))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.Bag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            Methods += "<a href='callback:" + ShavePussyFull + @"'>Брить кису налысо</a> |  
                                        <a href='callback:" + ShavePussyHalf + @"'>Оставить полоску</a> |  
                                        <a href='callback:" + ShaveLegs + @"'>Брить ноги</a> |   
                                        <a href='callback:" + ShaveHands + @"'>Брить подмышки</a>  ";
                        }
                        if (String.IsNullOrEmpty(Methods))
                        {
                            continue;
                        }
                        html += @"<tr>
                                <td>" + stf.Name + ((stf.UseCount > 0) ? " (" + stf.UseCount + " раз)" : "") + @"</td>
                                <td>" + stfobj.Count + @"</td>
                                <td>" + Methods + @"</td>
                            </tr>";
                    }
                    html += "</table>";
                    sc.Description += html + "<br/>";
                }

                if (bath.SmallBag != null)
                {
                    String html = "<b>" + bath.SmallBag.Name + "</b><br />";
                    var ls = bath.SmallBag.Things.GroupBy(x => new { x.Name, x.id, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();

                    html += "<table class=\"tableview\">";
                    foreach (var stfobj in ls)
                    {
                        String Methods = "";
                        var stf = stfobj.FirstOrDefault();
                        if (stf.GetType() == typeof(WashSoap))
                        {
                            String WashEv = RegisterEvent(() =>
                            {
                                if (!GetPlayer().WashMySelf((WashSoap)stf))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.SmallBag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);
                            Methods += "<a href='callback:" + WashEv + @"'>Мыться</a> ";
                        }
                        if (stf.GetType() == typeof(Shaver))
                        {
                            String ShavePussyFull = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShavePussy((Shaver)stf, 0))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.SmallBag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShavePussyHalf = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShavePussy((Shaver)stf, 1))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.SmallBag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShaveLegs = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShaveLegs((Shaver)stf))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.SmallBag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShaveHands = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShaveHands((Shaver)stf))
                                {
                                    GetPlayer().RemoveStaff(stf, bath.SmallBag);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            Methods += "<a href='callback:" + ShavePussyFull + @"'>Брить кису налысо</a> |  
                                        <a href='callback:" + ShavePussyHalf + @"'>Оставить полоску</a> |  
                                        <a href='callback:" + ShaveLegs + @"'>Брить ноги</a> |   
                                        <a href='callback:" + ShaveHands + @"'>Брить подмышки</a>  ";
                        }
                        if (String.IsNullOrEmpty(Methods))
                        {
                            continue;
                        }
                        html += @"<tr>
                                <td>" + stf.Name + ((stf.UseCount > 0) ? " (" + stf.UseCount + " раз)" : "") + @"</td>
                                <td>" + stfobj.Count + @"</td>
                                <td>" + Methods + @"</td>
                            </tr>";
                    }
                    html += "</table>";
                    sc.Description += html + "<br/>";
                }

                if (bath.Things != null)
                {
                    String html = "<b> Вещи в комнате " + bath.Name + "</b><br />";
                    var ls = bath.Things.GroupBy(x => new { x.Name, x.id, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();

                    html += "<table class=\"tableview\">";
                    foreach (var stfobj in ls)
                    {
                        String Methods = "";
                        var stf = stfobj.FirstOrDefault();
                        if (stf.GetType() == typeof(WashSoap))
                        {
                            String WashEv = RegisterEvent(() =>
                            {
                                if (!GetPlayer().WashMySelf((WashSoap)stf))
                                {
                                    bath.RemoveStaff(stf, 1);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);
                            Methods += "<a href='callback:" + WashEv + @"'>Мыться</a> ";
                        }
                        if (stf.GetType() == typeof(Shaver))
                        {
                            String ShavePussyFull = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShavePussy((Shaver)stf, 0))
                                {
                                    bath.RemoveStaff(stf, 1);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShavePussyHalf = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShavePussy((Shaver)stf, 1))
                                {
                                    bath.RemoveStaff(stf, 1);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShaveLegs = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShaveLegs((Shaver)stf))
                                {
                                    bath.RemoveStaff(stf, 1);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            String ShaveHands = RegisterEvent(() =>
                            {
                                if (!GetPlayer().ShaveHands((Shaver)stf))
                                {
                                    bath.RemoveStaff(stf, 1);
                                }
                                data.time.AddTime(15);

                            }, bath.Scene);

                            Methods += "<a href='callback:" + ShavePussyFull + @"'>Брить кису налысо</a> |  
                                        <a href='callback:" + ShavePussyHalf + @"'>Оставить полоску</a> | 
                                        <a href='callback:" + ShaveLegs + @"'>Брить ноги</a> | 
                                        <a href='callback:" + ShaveHands + @"'>Брить подмышки</a>  ";
                        }

                        if (String.IsNullOrEmpty(Methods))
                        {
                            continue;
                        }
                        html += @"<tr>
                                <td>" + stf.Name + ((stf.UseCount > 0) ? " (" + stf.UseCount + " раз)" : "") + @"</td>
                                <td>" + stfobj.Count + @"</td>
                                <td>" + Methods + @"</td>
                            </tr>";
                    }
                    html += "</table>";
                    sc.Description += html + "<br/>";
                }
            }
        }

        public String DrawMirrorHtml()
        {
            String addHtml = "<br /><br /><a class='btn btn-success' href='close:help'>Убрать зеркало</a>";
            return @"
<center><img src='/images/imgpreview/hcol.jpg' height='220'></center>" + GetPlayer().GetActorMirror() + @" " + addHtml;
        }

        public String DrawBagHtml(IBagObject bagObject)
        {
            String addHtml = "<br /><br /><a class='btn btn-success' href='close:help'>Закрыть сумку " + GetPlayer().Bag.Name + "</a>";
            String html = "<b>Содержимое сумки " + bagObject.Name + "</b><br />";
            if (bagObject.Things.Count == 0)
            {
                html += bagObject.Name + " Пуста" + addHtml;
                return html;
            }
            else
            {
                //var ls = stuff.GroupBy(x => new { x.Name, x.id, x.classname }).Select(grp => new { GroupID = grp.Key, Count = grp.ToList().Count }).ToList();
                var ls = bagObject.Things.GroupBy(x => new { x.Name, x.id, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();

                html += "<table class=\"tableview\">";
                foreach (var stfobj in ls)
                {
                    String Methods = "";
                    var stf = stfobj.FirstOrDefault();
                    String dropev = RegisterInternalEvent(() =>
                    {
                        GetPlayer().RemoveStaff(stf, bagObject);

                    }, bagObject.classname);
                    if (stf.GetType() == typeof(Alcohol))
                    {
                        String drinkev = RegisterInternalEvent(() =>
                        {
                            if (!GetPlayer().DrinkAlcohol((Alcohol)stf, 0))
                            {
                                sc.InternalMesage = "Я не состоянии больше пить";
                            }
                            else
                            {
                                GetPlayer().RemoveStaff(stf, bagObject);

                            }
                        }, bagObject.classname);
                        Methods += "<a href='callback:" + drinkev + @"'>Выпить</a> ";
                    }
                    if (stf.GetType() == typeof(Parfume))
                    {
                        String drinkev = RegisterInternalEvent(() =>
                        {
                            if (!GetPlayer().UseParfume((Parfume)stf))
                            {
                                GetPlayer().RemoveStaff(stf, bagObject);

                            }
                            data.time.AddTime(1);
                        }, bagObject.classname);
                        Methods += "<a href='callback:" + drinkev + @"'>Надушиться</a> ";
                    }
                    if (stf.GetType() == typeof(Pomade))
                    {
                        String drinkev = RegisterInternalEvent(() =>
                        {
                            if (!GetPlayer().UsePomade((Pomade)stf))
                            {
                                GetPlayer().RemoveStaff(stf, bagObject);

                            }
                            data.time.AddTime(2);
                        }, bagObject.classname);
                        Methods += "<a href='callback:" + drinkev + @"'>Накрасить губы</a> ";
                    }
                    if (stf.GetType() == typeof(EyeShadow))
                    {
                        String eyecolor = RegisterInternalEvent(() =>
                        {
                            if (!GetPlayer().UseEyeShadow((EyeShadow)stf))
                            {
                                GetPlayer().RemoveStaff(stf, bagObject);
                            }
                            data.time.AddTime(5);
                        }, bagObject.classname);
                        Methods += "<a href='callback:" + eyecolor + @"'>Накрасить глаза</a> ";
                    }
                    if (stf.GetType() == typeof(HairBrush))
                    {
                        String drinkev = RegisterInternalEvent(() =>
                        {
                            GetPlayer().UseHairBrush((HairBrush)stf);
                            data.time.AddTime(1);
                        }, bagObject.classname);
                        Methods += "<a href='callback:" + drinkev + @"'>Причесаться</a> ";
                    }
                    if (stf.GetType() == typeof(HandMirror))
                    {
                        String mirrorEvent = RegisterHtmlEvent(() =>
                        {
                            data.time.AddTime(1);
                            return DrawMirrorHtml();

                        }, bagObject.classname);
                        Methods += "<a href='htmlcallback:" + mirrorEvent + @"'>Посмотреться в зеркало</a> ";
                    }
                    html += @"<tr>
            <td>" + stf.Name + ((stf.UseCount > 0) ? " (" + stf.UseCount + " раз)" : "") + @"</td>
            <td>" + stfobj.Count + @"</td>
            <td>" + Methods + @"<a href='callback:" + dropev + @"' onclick=""ConfirmDelete(this)"">Выкинуть</a></td>
</tr>";
                }
                html += "</table>" + addHtml;
                return html;
            }
        }

        public String DrawWearHtml()
        {
            String addHtml = "<div style='vertical-align:top; display: inline-block'><a class='btn btn-success' href='close:help'>Закончить осмотр</a></div>";
            String html = "<b>На мне надето</b><br />";


            html += "<div style='width:310px; height:551px; display: inline-block'><img src='/Resources/Siluet.png' style='position:absolute'>";
            String Hat = "";
            if (GetPlayer().Hat != null)
            {
                String undressHat = RegisterInternalEvent(() =>
                {
                    GetPlayer().AddSmallBag(GetPlayer().Hat);
                    GetPlayer().Hat = null;

                }, "Dress");
                Hat = @"<a href='callback:" + undressHat + @"'><img src='" + GetPlayer().Hat.Image + "' title='" + GetPlayer().Hat.Name + "'></a>";
            }

            String TopDress = "";
            if (GetPlayer().TopDress != null)
            {
                TopDress = @"<img src='" + GetPlayer().TopDress.Image + "' title='" + GetPlayer().TopDress.Name + "'>";
            }

            String BottomDress = "";
            if (GetPlayer().BottomDress != null)
            {
                BottomDress = @"<img src='" + GetPlayer().BottomDress.Image + "' title='" + GetPlayer().BottomDress.Name + "'>";
            }

            String Shoes = "";
            if (GetPlayer().Shoes != null)
            {
                Shoes = @"<img src='" + GetPlayer().Shoes.Image + "' title='" + GetPlayer().Shoes.Name + "'>";
            }

            String Stockings = "";
            if (GetPlayer().Stockings != null)
            {
                Stockings = @"<img src='" + GetPlayer().Stockings.Image + "' title='" + GetPlayer().Stockings.Name + "'>";
            }

            String Coat = "";
            if (GetPlayer().Coat != null)
            {
                Coat = @"<img src='" + GetPlayer().Coat.Image + "' title='" + GetPlayer().Coat.Name + "'>";
            }

            String Bra = "";
            if (GetPlayer().Bra != null)
            {
                String undressBra = RegisterInternalEvent(() =>
                {
                    GetPlayer().AddSmallBag(GetPlayer().Bra);
                    GetPlayer().Bra = null;

                }, "Dress");
                Bra = @"<a href='callback:" + undressBra + @"'><img src='" + GetPlayer().Bra.Image + "' title='" + GetPlayer().Bra.Name + "'></a>";
            }

            String Panties = "";
            if (GetPlayer().Panties != null)
            {
                String undressPanties = RegisterInternalEvent(() =>
                {
                    GetPlayer().AddSmallBag(GetPlayer().Panties);
                    GetPlayer().Panties = null;

                }, "Dress");
                Panties = @"<a href='callback:" + undressPanties + @"'><img src='" + GetPlayer().Panties.Image + "' title='" + GetPlayer().Panties.Name + "'></a>";
            }

            String SmallBaga = "";
            if (GetPlayer().SmallBag != null)
            {
                SmallBaga = @"<img src='" + GetPlayer().SmallBag.Image + "' title='" + GetPlayer().SmallBag.Name + "'>";
            }

            String Baga = "";
            if (GetPlayer().Bag != null)
            {
                Baga = @"<img src='" + GetPlayer().Bag.Image + "' title='" + GetPlayer().Bag.Name + "'>";
            }

            html += @"
                <div class=""position Hat"">" + Hat + @"</div>
                <div class=""position TopDress"">" + TopDress + @"</div>
                <div class=""position BottomDress"">" + BottomDress + @"</div>
                <div class=""position Shoes"">" + Shoes + @"</div>
                <div class=""position Stockings"">" + Stockings + @"</div>
                <div class=""position Coat"">" + Coat + @"</div>
                <div class=""position Bra"">" + Bra + @"</div>
                <div class=""position Panties"">" + Panties + @"</div>
                <div class=""position SmallBag"">" + SmallBaga + @"</div>
                <div class=""position Bag"">" + Baga + @"</div>
            ";
            html += "</div>";

            return html + addHtml;

        }

        public void DrawBoxStuff(Box s)
        {
            List<List<IStuff>> ls = new List<List<IStuff>>();
            if (s.Things != null)
            {
                ls = s.Things.GroupBy(x => new { x.Name, x.id, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();//.GroupBy(n => n.); 
            }

            String html = @"
                <table width='100%' cellpadding='2' cellspacing='2'>
                    <tr>
                        <th>Сумочки</th>
                        <th>" + s.Name + @"</th>
                    </tr>
                    <tr>
                    <td width='50%' valign='top' style='padding-right: 2px'>";

            html += "<table class=\"tableview\" cellpadding='2' cellspacing='2'>";
            if (data.player.SmallBag != null)
            {
                var SmallBag = data.player.SmallBag.Things.GroupBy(x => new { x.Name, x.id, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();
                html += "<tr><td colspan='3'>" + data.player.SmallBag.Name + "</td></tr>";
                foreach (var stfobj in SmallBag)
                {
                    var stf = stfobj.FirstOrDefault();

                    String ev = RegisterEvent(() =>
                    {
                        data.DropThning(stf, s, 1, data.player.SmallBag);

                    });

                    html += @"<tr>  
                                        <td>" + stf.Name + ((stf.UseCount > 0) ? " (" + stf.UseCount + " раз)" : "") + @"</td>
                                        <td>" + stfobj.Count + @"</td>
                                        <td><a href='callback:" + ev + @"'><img src='/Resources/ToBox.png' width='24'></a></td>
                                   </tr>";
                }

            }

            if (data.player.Bag != null)
            {
                var Bag = data.player.Bag.Things.GroupBy(x => new { x.Name, x.id, x.UseCount }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();
                html += "<tr><td colspan='3'>" + data.player.Bag.Name + "</td></tr>";
                foreach (var stfobj in Bag)
                {
                    var stf = stfobj.FirstOrDefault();

                    String ev = RegisterEvent(() =>
                    {
                        data.DropThning(stf, s, 1, data.player.Bag);

                    });

                    html += @"<tr>  
                                        <td>" + stf.Name + ((stf.UseCount > 0) ? " (" + stf.UseCount + " раз)" : "") + @"</td>
                                        <td>" + stfobj.Count + @"</td>
                                        <td><a href='callback:" + ev + @"'><img src='/Resources/ToBox.png' width='24'></a></td>
                                   </tr>";
                }

            }

            html += "</table>";

            html += @"</td>
                    <td width='50%' valign='top' style='padding-left: 1px'>
                <table class=""tableview"" border='1' cellpadding='2' cellspacing='2'>
                    <tr>
                    <th>Название</th>
                    <th>Кол-во</th>
                    <th></th>
                 </tr>";

            foreach (var staff in ls)
            {
                var stf = staff.FirstOrDefault();

                String tobag = "";
                if (data.player.Bag != null)
                {
                    tobag = "<a href='callback:" + RegisterEvent(() =>
                    {
                        if (!data.GetThningToBag(stf, s, 1, data.player.Bag))
                        {
                            sc.Message = "Недостаточно места в сумке";
                        }
                    }) + "'><img width='24' title='В сумку' src='/Resources/Bag.png'></a>";
                }

                String tosmallbag = "";
                if (data.player.SmallBag != null)
                {
                    tosmallbag = "<a href='callback:" + RegisterEvent(() =>
                    {
                        if (!data.GetThningToBag(stf, s, 1, data.player.SmallBag))
                        {
                            sc.Message = "Недостаточно места в сумке";
                        }
                    }) + "'><img width='24' title='В маленькую сумку' src='/Resources/SmallBag.jpg'></a>";
                }

                String outof = RegisterEvent(() =>
                {
                    s.RemoveStaff(stf, 1);
                });
                html += @"<tr>
                    <td>" + stf.Name + ((stf.UseCount > 0) ? " (" + stf.UseCount + " раз)" : "") + @"</td>
                    <td>" + staff.Count + @"</td>
                    <td>" + tobag + @"" + tosmallbag + "<a href='callback:" + outof + @"' onclick=""ConfirmDelete(this)""><img width='24' title='Выкинуть' src='/Resources/DeleteRed.png'></a></td>
                 </tr>";
            }

            html += "</table></td></tr></table>";
            sc.Description += html + "<br/>";
        }

        public void DrawWadrobeStaff(Wardrobe s)
        {
            List<List<IWear>> ls = new List<List<IWear>>();
            if (s.Things != null)
            {
                ls = s.Things.Cast<IWear>().ToList().GroupBy(x => new { x.Name, x.id, x.Price, x.Durability }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();//.GroupBy(n => n.); 
            }

            String html = @"
                <table width='100%' cellpadding='2' cellspacing='2'>
                    <tr>
                        <th>Надето на мне</th>
                        <th>" + s.Name + @"</th>
                    </tr>
                    <tr>
                    <td width='50%' valign='top' style='padding-right: 2px'>

                ";
            html += "<div style='width:310px; height:551px'><img src='/Resources/Siluet.png' style='position:absolute'>";
            String Hat = "";
            if (GetPlayer().Hat != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.Hat, s);

                });
                Hat = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().Hat.Image + "' title='" + GetPlayer().Hat.Name + "'></a>";
            }

            String TopDress = "";
            if (GetPlayer().TopDress != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.TopDress, s);

                });
                TopDress = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().TopDress.Image + "' title='" + GetPlayer().TopDress.Name + "'></a>";
            }

            String BottomDress = "";
            if (GetPlayer().BottomDress != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.BottomDress, s);

                });
                BottomDress = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().BottomDress.Image + "' title='" + GetPlayer().BottomDress.Name + "'></a>";
            }

            String Shoes = "";
            if (GetPlayer().Shoes != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.Shoes, s);

                });
                Shoes = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().Shoes.Image + "' title='" + GetPlayer().Shoes.Name + "'></a>";
            }

            String Stockings = "";
            if (GetPlayer().Stockings != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.Stockings, s);

                });
                Stockings = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().Stockings.Image + "' title='" + GetPlayer().Stockings.Name + "'></a>";
            }

            String Coat = "";
            if (GetPlayer().Coat != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.Coat, s);

                });
                Coat = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().Coat.Image + "' title='" + GetPlayer().Coat.Name + "'></a>";
            }

            String Bra = "";
            if (GetPlayer().Bra != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.Bra, s);

                });
                Bra = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().Bra.Image + "' title='" + GetPlayer().Bra.Name + "'></a>";
            }

            String Panties = "";
            if (GetPlayer().Panties != null)
            {
                String ev = RegisterEvent(() =>
                {
                    data.Undress(data.player.Panties, s);

                });
                Panties = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().Panties.Image + "' title='" + GetPlayer().Panties.Name + "'></a>";
            }

            String SmallBaga = "";
            if (GetPlayer().SmallBag != null)
            {
                String ev = RegisterEvent(() =>
                {
                    if (!data.Undress(data.player.SmallBag, s))
                    {
                        sc.Message = "Выложите все из маленькой сумочки";
                    }

                });
                SmallBaga = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().SmallBag.Image + "' title='" + GetPlayer().SmallBag.Name + "'></a>";
            }

            String Baga = "";
            if (GetPlayer().Bag != null)
            {
                String ev = RegisterEvent(() =>
                {
                    if (!data.Undress(data.player.Bag, s))
                    {
                        sc.Message = "Выложите все из дополнительной сумки";
                    }

                });
                Baga = @"<a href='callback:" + ev + @"'><img src='" + GetPlayer().Bag.Image + "' title='" + GetPlayer().Bag.Name + "'></a>";
            }

            html += @"
                <div class=""position Hat"">" + Hat + @"</div>
                <div class=""position TopDress"">" + TopDress + @"</div>
                <div class=""position BottomDress"">" + BottomDress + @"</div>
                <div class=""position Shoes"">" + Shoes + @"</div>
                <div class=""position Stockings"">" + Stockings + @"</div>
                <div class=""position Coat"">" + Coat + @"</div>
                <div class=""position Bra"">" + Bra + @"</div>
                <div class=""position Panties"">" + Panties + @"</div>
                <div class=""position SmallBag"">" + SmallBaga + @"</div>
                <div class=""position Bag"">" + Baga + @"</div>
            ";
            html += "</div>";


            html += "<br/><b>У меня с собой</b>:<br /><table class=\"tableview\" cellpadding='2' cellspacing='2'>";
            if (data.player.SmallBag != null)
            {
                var SmallBag = data.player.SmallBag.Things.Where(z => z.classtype == "IWear").GroupBy(x => new { x.Name, x.id }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();
                html += "<tr><td colspan='3'>" + data.player.SmallBag.Name + "</td></tr>";
                foreach (var stfobj in SmallBag)
                {
                    var stf = stfobj.FirstOrDefault();

                    String ev = RegisterEvent(() =>
                    {
                        data.DropThning(stf, s, 1, data.player.SmallBag);

                    });

                    html += @"<tr>  
                                        <td>" + ((String.IsNullOrEmpty(stf.Image)) ? stf.Name : "<img title='" + stf.Name + "' src='" + stf.Image + "' width='70'>") + @"</td>
                                        <td>" + stfobj.Count + @"</td>
                                        <td><a href='callback:" + ev + @"'><img src='/Resources/ToBox.png' width='24'></a></td>
                                   </tr>";
                }

            }

            if (data.player.Bag != null)
            {
                var Bag = data.player.Bag.Things.GroupBy(x => new { x.Name, x.id }).OrderBy(o => o.Key.Name).Select(obj => obj.ToList()).ToList();
                html += "<tr><td colspan='3'>" + data.player.Bag.Name + "</td></tr>";
                foreach (var stfobj in Bag)
                {
                    var stf = stfobj.FirstOrDefault();

                    String ev = RegisterEvent(() =>
                    {
                        data.DropThning(stf, s, 1, data.player.Bag);

                    });

                    html += @"<tr>  
                                        <td>" + ((String.IsNullOrEmpty(stf.Image)) ? stf.Name : "<img title='" + stf.Name + "' src='" + stf.Image + "' width='70'>") + @"</td>
                                        <td>" + stfobj.Count + @"</td>
                                        <td><a href='callback:" + ev + @"'><img src='/Resources/ToBox.png' width='24'></a></td>
                                   </tr>";
                }

            }
            html += "</table>";

            html += @"</td>
                    <td width='50%' valign='top' style='padding-left: 1px'>
                <table class=""tableview"" border='1' cellpadding='2' cellspacing='2'>
                    <tr>
                    <th>Название</th>
                    <th><span title='Прочность'>Пр</span></th>
                    <th><span title='Количество'>Кл</span></th>
                    <th></th>
                 </tr>";

            foreach (var staff in ls)
            {
                var stf = (IWear)staff.FirstOrDefault();

                String tobag = "";
                if (data.player.Bag != null)
                {
                    tobag = "<a href='callback:" + RegisterEvent(() =>
                    {
                        if (!data.GetThningToBag(stf, s, 1, data.player.Bag))
                        {
                            sc.Message = "Недостаточно места в сумке";
                        }
                    }) + "'><img width='24' title='В сумку' src='/Resources/Bag.png'></a>";
                }

                String tosmallbag = "";
                if (data.player.SmallBag != null)
                {
                    tosmallbag = "<a href='callback:" + RegisterEvent(() =>
                    {
                        if (!data.GetThningToBag(stf, s, 1, data.player.SmallBag))
                        {
                            sc.Message = "Недостаточно места в сумке";
                        }
                    }) + "'><img width='24' title='В маленькую сумку' src='/Resources/SmallBag.jpg'></a>";
                }

                String DressCB = RegisterEvent(() =>
                {
                    if (!data.WearToMe(stf, s))
                    {
                        sc.Message = "Нельзя надеть одежду. Сначала снимите другую одежду";
                    }
                });

                String outof = RegisterEvent(() =>
                {
                    s.RemoveStaff(stf, 1);
                });
                html += @"<tr>
                    <td><a href='callback:" + DressCB + "'>" + ((String.IsNullOrEmpty(stf.Image)) ? stf.Name : "<img title='" + stf.Name + "' src='" + stf.Image + "' width='70'>") + @"</a></td>
                    <td>" + stf.Durability + @"</td>
                    <td>" + staff.Count + @"</td>
                    <td>" + tobag + @"" + tosmallbag + @"<a href='callback:" + outof + @"' class="""" onclick=""ConfirmDelete(this)""><img width='24' title='Выкинуть' src='/Resources/DeleteRed.png'></a></td>
                 </tr>";
            }

            html += "</table></td></tr></table>";
            sc.Description += html + "<br/>";
        }       
       
    }
}
