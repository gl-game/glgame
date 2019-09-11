using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLCore
{
    public partial class GLGame
    {
        public String GetPlayerStatistics() {

            String skills = "";

            foreach (var skill in game.GetPlayer().Skills.Skill)
            {
                skills += skill.Name + ": " + skill.Value + "<br />";
            }

            var body = game.GetPlayer().GetBodyDescription();
            String html = @"
<script>
    function showStat(id) {
        document.getElementById('mainStats').style.display = 'none';
        document.getElementById('charStats').style.display = 'none';
        document.getElementById('charSkills').style.display = 'none';

        document.getElementById(id).style.display = 'block';
    }
</script>
<table class=""tableview tablesize"">
    <tr>
        <td valign=""top"">
            <div id=""mainStats"" style=""display: block"">
                Меня зовут " + game.GetPlayer().Name + @" " + game.GetPlayer().LastName + @".<br />
                Мне " + game.GetPlayer().Age + @" лет<br />
                Дата рождения " + game.GetPlayer().DateOfBirth.ToString("dd.mm.YYYY") + @"г.<br />
                Рост " + game.GetPlayer().Height + @" см, вес " + game.GetPlayer().Weight + @" кг.<br />
                " + game.GetPlayer().BreastSize + @" - " + game.GetPlayer().Talia + @" - " + game.GetPlayer().AssSize + @", размер груди " + game.GetPlayer().TitsSize + @", разница между бедрами и талией " + (game.GetPlayer().AssSize - game.GetPlayer().Talia) + @" см<br />
                " + game.GetPlayer().GetVisualView().Name + @"<br />
                " + game.GetPlayer().GetHairStyle().Name + @"<br />
                " + game.GetPlayer().GetLipsStyle().Name + @".<br />
                " + game.GetPlayer().GetEarningStyle().Name + @" " + game.GetPlayer().GetVaginaPiercingStyle().Name + @" " + game.GetPlayer().GetBellyPiercingStyle().Name + @"<br />
                " + game.GetPlayer().GetTanStyle().Name + @" " + game.GetPlayer().GetSkinStyle().Name + @"<br />
                " + game.GetPlayer().GetEyeStyle().Name + @"<br />
                " + game.GetPlayer().GetEyeBrowsStyle().Name + @"<br />
                " + game.GetPlayer().GetMakeupStyle().Name + @"<br />
                " + game.GetPlayer().GetLegsStyle().Name + @"<br />
                " + game.GetPlayer().GetPussyStyle().Name + @"<br />
                " + game.GetPlayer().GetVaginaStatusStyle().Name + @"<br />
                " + game.GetPlayer().GetAnusSize().Name + @"<br />
            </div>
            <div id=""charStats"" style=""display: none"">
                Привлекательность " + game.GetPlayer().Beauty + @"<br />
                Сила " + game.GetPlayer().Strength + @"<br />
                Скорость " + game.GetPlayer().Speed + @"<br />
                Ловкость " + game.GetPlayer().Agility + @"<br />
                Выносливость " + game.GetPlayer().Vitality + @"<br />
                Интеллект " + game.GetPlayer().Intellect + @"<br />
                Сила воли " + game.GetPlayer().WillPower + @"<br />
                Реакция " + game.GetPlayer().Reaction + @"<br />
                " + game.GetPlayer().GetBodyDescription().Name + @"<br />
                " +game.GetPlayer().GetSexualView().Name + @"
                <!-- В школе вы круглая отличница.-->
            </div>

            <div id=""charSkills"" style=""display: none"">"+ skills + @"</div>
        </td>
        <td valign=""top"">
            <div style=""padding: 5px""><a href=""javascript:showStat('mainStats')"" class=""btn btn-info"">Статистика персонажа</a></div>
            <div style=""padding: 5px""><a href=""javascript:showStat('charStats')"" class=""btn btn-info"">Параметры</a></div>
            <div style=""padding: 5px""><a href=""javascript:showStat('charSkills')"" class=""btn btn-info"">Навыки</a></div>
        </td>
    </tr>
</table>";
            return html;
        }
    }
}
