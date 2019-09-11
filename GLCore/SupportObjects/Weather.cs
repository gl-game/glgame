using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore.SupportObjects
{
    public class Weather : IWeather
    {
        public int Temperature { get; set; }
        public int Condition { get; set; }
        public int MonthId { get; set; }

        public String GetWeather()
        {
            String r = "";
            String conTx = "";
            switch (MonthId)
            {
                case 1:
                    if (Temperature < 0)
                    {
                        if (Condition == 0)
                            conTx = "Ясно.";
                        else
                            conTx = "Идет пушистый снег.";
                    }
                    else
                    {
                        if (Condition == 0)
                            conTx = "Ясно, снег кое где начинает подтаивать образуя слякоть.";
                        else
                            conTx = "Падает мокрый снег, который тут же тает образуя слякоть.";
                    }
                    r = "На улице лежит снег, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 2:
                    if (Temperature < 0)
                    {
                        if (Condition == 0)
                            conTx = "Ясно и ветрено.";
                        else
                            conTx = "Идет снег.";
                    }
                    else
                    {
                        if (Condition == 0)
                            conTx = "Ясно, снег кое где начинает подтаивать образуя слякоть.";
                        else
                            conTx = "Падает мокрый снег, который тут же тает образуя слякоть.";
                    }
                    r = "На улице лежит снег, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 3:
                    if (Temperature < 0)
                    {
                        if (Condition == 0)
                            conTx = "Ясно и безоблачно.";
                        else
                            conTx = "Идет снег.";
                    }
                    else
                    {
                        if (Condition == 0)
                            conTx = "Ясно, снег кое где начинает подтаивать образуя слякоть.";
                        else
                            conTx = "Падает мокрый снег, который тут же тает образуя слякоть.";
                    }
                    r = "На улице лежит снег, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 4:
                        if (Condition == 0)
                            conTx = "Ясно.";
                        else
                            conTx = "Идет дождь.";

                        r = "На улице тает снег, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 5:
                    if (Condition == 0)
                        conTx = "Ясно.";
                    else
                        conTx = "Идет дождь.";
                    r = "На улице лужи от растаявшего снега, кругом грязь и мусор показавшийся после зимы, кое где новая травка радует глаз своей зеленью, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 6:
                    if (Condition == 0)
                        conTx = "Ясно.";
                    else
                        conTx = "Идет дождь.";
                    r = "На улице зеленеет трава, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 7:
                    if (Condition == 0)
                        conTx = "Ясно.";
                    else
                        conTx = "Идет теплый дождь.";
                    r = "На улице зеленая трава, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 8:
                    if (Condition == 0)
                        conTx = "Ясно.";
                    else
                        conTx = "Идет теплый дождь.";
                    r = "На улице зеленая трава, кое где уже видны желтеющие листья, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 9:
                    if (Condition == 0)
                        conTx = "Ясно.";
                    else
                        conTx = "Идет дождь.";
                    r = "На улице жухнет трава, видны желтые листья, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 10:
                    if (Condition == 0)
                        conTx = "Ясно.";
                    else
                        conTx = "Идет холодный дождь.";
                    r = "На улице пожухла трава, опадают желтые листья, вокруг грязь и лужи, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                case 11:
                    if (Temperature < 0)
                    {
                        if (Condition == 0)
                            conTx = "Ясно, снег кое где начинает подтаивать образуя слякоть.";
                        else
                            conTx = "Идет снег.";
                    }
                    else
                    {
                        if (Condition == 0)
                            conTx = "Ясно, снег кое где начинает подтаивать образуя слякоть.";
                        else
                            conTx = "Холодный дождь.";
                    }
                    r = "На улице лежит тонкий и грязный покров снега, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
                default:
                    if (Temperature < 0)
                    {
                        if (Condition == 0)
                            conTx = "Ясно.";
                        else
                            conTx = "Идет пушистый снег.";
                    }
                    else
                    {
                        if (Condition == 0)
                            conTx = "Ясно, снег кое где начинает подтаивать образуя слякоть.";
                        else
                            conTx = "Падает мокрый снег, который тут же тает образуя слякоть.";
                    }
                    r = "На улице лежит снег, температура " + Temperature + " градусов по цельсию. " + conTx;
                    break;
            }

            return r;
        }
    }
}
