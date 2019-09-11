using GLCore.Dynaimc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GLCore.Scenes.gorodok.school
{
    public class rasspisanije : BaseScene
    {
        public override void GetView()
        {
            AddDescription(@"
Рассписание уроков для 10б
<table border='1' cellpadding='2' cellspacing='2' width='90%'>
	<tr>
		<th>-</th>
		<th>Понедельник</th>
		<th>Вторник</th>
		<th>Среда</th>
		<th>Четверг</th>
		<th>Пятница</th>
	</tr>
	<tr>
		<td>8:00-8:40</td>
		<td>Математика</td>
		<td>География</td>
		<td>Информатика</td>
		<td>Физика</td>
		<td>Русский язык</td>
	</tr>
	<tr>
		<td>8:50-9:30</td>
		<td>Информатика</td>
		<td>Математика</td>
		<td>География</td>
		<td>Биология</td>
		<td>Математика</td>
	</tr>
	<tr>
		<td>9:40-10:20</td>
		<td>Русский язык</td>
		<td>Химия</td>
		<td>Физика</td>
		<td>История</td>
		<td>Химия</td>
	</tr>	
	<tr>
		<td>10:40-11:20</td>
		<td>История</td>
		<td>История</td>
		<td>Русский язык</td>
		<td>Математика</td>
		<td>Информатика</td>
	</tr>
	<tr>
		<td>11:30-12:10</td>
		<td>Физкультура</td>
		<td>Физкультура</td>
		<td>Физкультура</td>
		<td>Физкультура</td>
		<td>Физкультура</td>
	</tr>
</table><br><br>

Осенние каникулы - 4-тая неделя октября<br>
Зинмние каникулы - Последняя неделя дебкаря - первая неделя января<br>
Весенние каникулы - Вторая неделя марта<br>

");
            AddDirection(game.location.shkolamain, new { Name = "В коридор" }, true);
        }
    }
}