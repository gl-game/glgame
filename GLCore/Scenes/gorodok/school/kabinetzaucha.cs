using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class kabinetzaucha : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"Кабинет зауча");
            if (game.actor.zauchshkoli.Get("may_enter") == 1 && GetPlayer().Drunk < 5)
            {
                AddDescription(game.actor.zauchshkoli.NN + " сидит за столом");
            }
            else
            {
                if (game.actor.zauchshkoli.Get("see_drunk") > 9 && GetPlayer().Drunk < 10)
                {
                    AddDescription(@"Я стою подвыпившая в кабинете зауча");
                    AddDescription(@" - Ты уже много раз приходишь в школу пьяная? У тебя все в проядке?");
                    AddDynamicScene(
                        new
                        {
                            Name = "Я прихожу потому что мне нравится чтобы вы меня привели к себе в кабинет",
                            c = (Action)(() =>
             {
                 AddDescription(@"Зачем приходить ко мне в кабинет?");
                 AddDynamicScene(new
                 {
                     Name = "Иногда мне хочется с кем-то поговорить",
                     c = (Action)(() =>
                        {
                            if (GetPlayer().Beauty > 10)
                            {
                                game.actor.zauchshkoli.Set("may_enter", 1);
                                AddDescription(@"Приходи ко мне в кабинет и говори со мной на любые темы в переменах");
                            }
                            else
                            {
                                AddDescription(@"Приведи себя в соответвующий вид. И не приходи в школу пьяная больше.");
                            }
                            AddDynamicAction(new
                            {
                                Name = "Я все поняла",
                                Scene = "gorodok/parentflat/koridor",
                                c = (Action)(() =>
                        {
                            game.actor.zauchshkoli.Add("see_drunk", 1);
                            Set("drunk_zauch", 0);
                            AddTime(30);
                        })
                            });
                        })
                 });
             })
                        }
                    );

                    AddDynamicScene(
                        new
                        {
                            Name = "Просто нравиться пить",
                            c = (Action)(() =>
             {
                 AddDescription(@"Хорошо иди домой но больше в пьяном виде в школу не приходи");
                 AddDynamicAction(new
                 {
                     Name = "Я все поняла",
                     Scene = "gorodok/parentflat/koridor",
                     c = (Action)(() =>
{
    game.actor.zauchshkoli.Add("see_drunk", 1);
    Set("drunk_zauch", 0);
    AddTime(30);
})
                 });
             })
                        }
                    );

                }
                else
                {
                    if (Get("drunk_zauch") == 1)
                    {
                        AddDescription(@"Как ты можешь являтся в пьяном виде в школу?");
                        AddDescription("Тебе всего " + GetPlayer().Age + " а ты уже пьёшь?");

                        AddDynamicScene(new
                        {
                            Name = "Я больше не буду пить. Отпустите пожалуйста меня домой (Говорю неразборчиво)",
                            c = (Action)(() =>
             {
                 AddDescription(@"Хорошо иди домой но больше в пьяном виде в школу не приходи");

                 AddDynamicAction(new
                 {
                     Name = "Я все поняла",
                     Scene = "gorodok/parentflat/koridor",
                     c = (Action)(() =>
{
    game.actor.zauchshkoli.Add("see_drunk", 1);
    Set("drunk_zauch", 0);
    AddTime(30);
})
                 });
             })
                        });
                    }
                    else
                    {
                        AddDirection(game.location.shkolamain, new { Name = "Выйти в коридор" });
                    }
                }
            }
        }
    }
}