using GLCore.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportCases
{
    public class Import1
    {
        public Player GetPlayer()
        {
            return new Player();
        }
        public void AddDescription(String x)
        {
        }
        public void AddDynamicAction(Object x)
        {
        }
        public void AddDynamicScene(Object x)
        {
        }
        public int Random(int a, int b)
        {
            return 0;
        }
        public void Main()
        {
		
        int tmp_break = Random(1,10);

        if (tmp_break == 1)
        {
            AddDescription(@"<center><img src=""pictures/school/break_photo_1.jpg"" ></center>
        Гуляя по корридору, я замечаю девчонок из разных классов нашей параллели, которые собрались в одном из классов и, посмеиваясь, заговорщески перешептываются.");


            AddDescription(@" " + GetPlayer().Name + @", иди сюда! - зовет меня одна из них. - Мы тут решили сделать групповое фото для мальчишек. Давай с нами!");

            AddDescription(@"Сказав это, она и еще несколько девченок, заливаясь смехом, задирают свои юбки. Понятно, какое это будет фото...");


            //if kink + kink_add >= 200 and $clothes_panty ! 'null' or kink + kink_add >= 700:
            if (GetPlayer().WearPantiesSkirt == 0)
            {
                AddDescription(@"- Блин, девченки, а я трусы не надела...");
                AddDescription(@"-- Ну и что? Вон Машка тоже без них, сейчас голую письку на камеру засветит! Давай, фотка только круче будет!");
            }

            AddDynamicScene(new
            {
                Name = "Хорошо",
                c = (Action)(() => {
                    if (GetPlayer().WearPantiesSkirt == 0)
                    {
                        AddDescription(@"<center><img src=""pictures/school/break_photo_3.jpg"" ></center>
			        Я решаю сфоткаться, даже не смотря на осутствие трусов. По команде все девченки наклоняются вперед и задирают юбки.<br>					
			        - Внимание, сейчас вылетит птичка! И-и-и... готово!		<br>				
			        Все тут же бросаются разглядывать получившееся фото. Да уж, с моей голой задницей прямо по центру это фото точно станет бестселлером.");
                    }
                    else
                    {
                        AddDescription(@"<center><img src=""pictures/school/break_photo_2.jpg"" ></center>
			        Я решаю сфоткаться. По команде все девченки наклоняются вперед и задирают юбки.	<br>						
			        - Внимание, сейчас вылетит птичка! И-и-и... готово!<br>						
			        Все тут же бросаются разглядывать получившееся фото. Да уж, картинка что надо.<br>							
			        Но нас прерывает звонок, и все разбегаются по своим классам.");
                    }
                    AddDynamicScene(new
                    {
                        Name = "Подмигнуть девченкам",
                        c = (Action)(() => {
                            AddDescription(@"Я подмигиваю девченкам");
                            AddDynamicAction(new { Name = "Идти в коридор", Scene = "gorodok/school/shkolamain" });
                        })
                    });
                    AddDynamicAction(new { Name = "Идти в коридор", Scene = "gorodok/school/shkolamain" });
                })
            });

            AddDynamicScene(new
            {
                Name = "Нет",
                c = (Action)(() => {
                    AddDescription(@"<center><img src=""pictures/school/break_photo_2.jpg"" ></center>");
                    if (GetPlayer().WearPantiesSkirt == 0)
                    {
                        AddDescription(@"Вот, блин, а я трусики не надела... И светить свою киску на фото точно не буду!");
                    }
                    AddDescription(@"- Задрать юбку перед камерой?! Да ни за что!<br>				
	        - Ой, какие мы стеснительные! Ладно, тогда будешь фотографировать. Держи фотик<br>	
            По моей команде все девченки наклоняются вперед и задирают юбки.<br>	
	        - Так, замрите... Сейчас вылетит птичка! - руковожу процессом я. - Готово!<br>	
	        Все тут же бросаются разглядывать получившееся фото. Да уж, картинка что надо.");
                })
            });
        }
           
		
        if (tmp_break == 2) {
            AddDescription(@"<center><img src=""pictures/school/break_1.jpg"" ></center>
            Я прохожу мимо девочки, случано рассыпавшей свои пишущие принадлежности по полу. Интересно, почему никто из ее друзей не помогает ей подобрать их? Но пройдя мимо нее и, обернувшись, увидев ее сзади, я наконец поняла ""почему"". В итоге, я вместе с остальными простояла до конца перемены в ожидании, что она еще что-нибудь уронит.");
            AddDynamicAction(new { Name = "Идти в коридор", Scene = "gorodok/school/shkolamain" });				
        }
        
        if (tmp_break == 3) {
            AddDescription(@"<center><img src=""pictures/school/para.jpg"" ></center>
            Я гуляю по школьному коридору рассматривая одноклассников. Я замечаю целующуюся парочку школьников из параллельного класса. Приглядевшись, я вижу, что юбка у девушки задрана, а рука парня шарит у нее в трусиках.");
            
            if (GetPlayer().Lust < 200) AddDescription("Я отворачиваюсь, и краснея убегаю в другую сторону.");
            if (GetPlayer().Lust >= 200 && GetPlayer().Lust < 400) AddDescription("Я краснею, но продолжаю смотреть на них.");
            if (GetPlayer().Lust >= 400 && GetPlayer().Lust < 600) AddDescription("Как это романтично. Он, наверное, так ее хочет, что не в силах терпеть.");
            if (GetPlayer().Lust >= 600 && GetPlayer().Lust < 800) AddDescription("Парень лазает у моей одноклассницы в трусах, прямо не перемене! Как это возбуждает…");
            if (GetPlayer().Lust >= 800) AddDescription("Я тоже хочу чтобы мне кто ни будь залез в трусы, а лучше сразу вставил…");
            AddDynamicAction(new { Name = "Идти в коридор", Scene = "gorodok/school/shkolamain" });	
        }	
		
        if (tmp_break == 4) {
            AddDescription(@"<center><img src=""pictures/school/ups.jpg"" ></center>
            'Я гуляю по школьному коридору и замечаю стайку младшеклашек, которые странно играют одновременно пялясь куда то в сторону. Я провожаю их взгляд и нахожу причину и их интереса. Около окна на корточках сидит старшеклассница. Юбка у нее задралась, а полоска трусиков не прикрывает половые губы как полагается на провалилась между ними. Ее трусы стали похожи на дорогущий купальник который я как то видела в одном их бутиков города. Он тоже состоял из одних только ниточек которые совсем ни чего не срывали от постороннего взгляда. ");

            if (GetPlayer().Lust < 200) AddDescription("Я отворачиваюсь, и краснея убегаю в другую сторону.");
            if (GetPlayer().Lust >= 200 && GetPlayer().Lust < 600) AddDescription("Я краснею, но продолжаю смотреть на ее трусики.");
            if (GetPlayer().Lust >= 600) AddDescription("Я смотрю на  ее трусики и меня это  возбуждает…");
            
            AddDynamicAction(new { Name = "Идти в коридор", Scene = "gorodok/school/shkolamain" });	
						
        }		
            
        if (tmp_break > 4) {
            AddDescription(@"<center><img src=""pictures/dialog/kasia_1.jpg"" ></center>
                    Я стою у окна в школьном корридоре, как вдруг вижу проходящих мимио меня Ленку с подружками. Фуф... кажется они меня не заметили... Зато одна из них похоже решила пристать к Касе, которая смотрит на эту хулиганку испуганным взглядом и явно не знает, что делать. Но тут помощи приходит с совсем неожиданной стороны. К ним подходит Ленка, хватает свою подружку за руку и тащит подальше от Каси.<br />
                    - Ты что, совсем дура? - слышу я обрывок их разговора, когда они проходят мимо меня. - Это же дочь Робертовны! Да если она узнает, что ты к ее ненагляной доченьке докапываешься, она стебя шкуру спустит!<br />
                    Похоже даже местные хулиганки боятся Марию Робертовну! Интересно, смогу ли я как-нибудь использовать этот факт себе во благо?");           
				
                    
            AddDynamicAction(new { Name = "Идти в коридор", Scene = "gorodok/school/shkolamain" });			
        } else {
            AddDescription(@"Я решаю прогуляться по коридору, чтобы размять ноги. Ничего интересного вокруг не происходит.");
        }

        }
    }
}
