using GLCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mshtml;
using GLCore.DTO;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using GLCore.Objects;
using GLCore.Extensions;
using GLCore.SupportObjects;

namespace WEBQGame
{

    public partial class MainWindow : Window
    {
        mshtml.HTMLDocument doc;
        mshtml.HTMLDocument docHelp;
        private String StartLocation = "setup/gamestart";
        public class OptionList
        {
            public String Name { get; set; }
            public String Action { get; set; }
            public String Description { get; set; }
        }
        public Dictionary<String, CallbackDTO> Callbacks { get; set; }
        public Dictionary<String, CallbackDTO> InternalCallbacks { get; set; }
        private GLGame gl;
        private String ErrorMessage;
        private String InfoMessage;
        TextBox time;
        TextBox money;
        TextBox health;
        TextBox willpower;
        TextBox mana;

        TextBox WeatherStatus;
        TextBox DressStatus;
        TextBlock ImportantNotes;
        TextBox DrunkStatus;

        TextBox exciteBarIndicator;
        TextBox healthBarIndicator;
        TextBox mindBarIndicator;
        TextBox manaBarIndicator;
        TextBox energyBarIndicator;
        TextBox drinkBarIndicator;
        TextBox sleepBarIndicator;
        ProgressBar exciteBar;
        ProgressBar healthBar;
        ProgressBar mindBar;
        ProgressBar manaBar;
        ProgressBar energyBar;
        ProgressBar drinkBar;
        ProgressBar sleepBar;
        ErrorView window;
        GameMode gm;
        private WebBrowserHostUIHandler _wbHandler;
        private WebBrowserHostUIHandler _helpHandler;
        private bool isWindowSet;
        private String Version;
        public bool newGameStarted = true;

        public MainWindow()
        {
            gm = GameMode.VisualStudio;
            Version = "Версия Preview";

            /////
            gl = new GLGame(gm);
            InitializeComponent();
            time = new TextBox();
            money = new TextBox();
            health = new TextBox();
            health.Padding = new System.Windows.Thickness(5, 5, 0, 0);
            willpower = new TextBox();
            mana = new TextBox();

            WeatherStatus = new TextBox();
            DressStatus = new TextBox();
            DrunkStatus = new TextBox();
            ImportantNotes = new TextBlock();
            ImportantNotes.FontWeight = FontWeights.Bold;
            ImportantNotes.Foreground = Brushes.Red;
            ImportantNotes.TextWrapping = TextWrapping.Wrap;
            ImportantNotes.TextAlignment = TextAlignment.Left;            

            time.FontWeight = FontWeights.Bold;
            time.FontSize = 16;

            exciteBar = new ProgressBar();
            healthBar = new ProgressBar();
            mindBar = new ProgressBar();
            manaBar = new ProgressBar();
            energyBar = new ProgressBar();
            drinkBar = new ProgressBar();
            sleepBar = new ProgressBar();

            exciteBarIndicator = new TextBox();
            healthBarIndicator = new TextBox();
            mindBarIndicator = new TextBox();
            manaBarIndicator = new TextBox();
            energyBarIndicator = new TextBox();
            drinkBarIndicator = new TextBox();
            sleepBarIndicator = new TextBox();
            window = new ErrorView();

            if (gm == GameMode.Game)
            {
                _wbHandler = new WebBrowserHostUIHandler(MainBrowser);
                _wbHandler.IsWebBrowserContextMenuEnabled = false;

                _helpHandler = new WebBrowserHostUIHandler(HelpBrowser);
                _helpHandler.IsWebBrowserContextMenuEnabled = false;
            }

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (gm == GameMode.Dev)
            {
                Title = "РЕЖИМ РАЗРАБОТЧИКА! По мотивам ЭТО:";// +gl.GetState().player.NN;
            }
            else if (gm == GameMode.VisualStudio)
            {
                Title = "РЕЖИМ ДЕВ! По мотивам ЭТО:";// +gl.GetState().player.NN;
            }
            else
            {
                DevPanel.IsEnabled = false;
                DevPanel.Height = new GridLength(0);
                Title = "По мотивам ЭТО:";// +gl.GetState().player.NN;
            }
            MainBrowser.LoadCompleted += new LoadCompletedEventHandler(webBrowser_LoadCompleted);
            HelpBrowser.LoadCompleted += new LoadCompletedEventHandler(helpBrowser_LoadCompleted);
            String injectJavascript = "<script>function ConfirmDelete(obja) { obja.className = ''; var r = confirm('Подтвердите?'); if (r == false) { obja.className = 'nodel'; } } </script>";
            MainBrowser.NavigateToString(
                "<!DOCTYPE html><html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,FF=3,chrome=1\">" + injectJavascript + "<link href='" + System.AppDomain.CurrentDomain.BaseDirectory + "Resources/bootstrap.css' rel='stylesheet'><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head><body style='padding: 10px' id='bodyId'></body></html>");
            HelpBrowser.NavigateToString(
                "<!DOCTYPE html><html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge,FF=3,chrome=1\">" + injectJavascript + "<link href='" + System.AppDomain.CurrentDomain.BaseDirectory + "Resources/bootstrap.css' rel='stylesheet'><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head><body style='padding: 10px' id='bodyId'></body></html>");

            try
            {
                gl.NewGame();
                InfoText.Children.Add(time);
                InfoText.Children.Add(money);
                InfoText.Children.Add(health);
                InfoText.Children.Add(willpower);
                InfoText.Children.Add(mana);

                DockPanel d0 = new DockPanel();
                d0.Children.Add(exciteBar);
                d0.Children.Add(exciteBarIndicator);
                InfoText.Children.Add(d0);

                DockPanel d1 = new DockPanel();
                d1.Children.Add(healthBar);
                d1.Children.Add(healthBarIndicator);
                InfoText.Children.Add(d1);

                DockPanel d2 = new DockPanel();
                d2.Children.Add(mindBar);
                d2.Children.Add(mindBarIndicator);
                InfoText.Children.Add(d2);

                DockPanel d3 = new DockPanel();
                d3.Children.Add(manaBar);
                d3.Children.Add(manaBarIndicator);
                InfoText.Children.Add(d3);

                DockPanel d4 = new DockPanel();
                d4.Children.Add(energyBar);
                d4.Children.Add(energyBarIndicator);
                InfoText.Children.Add(d4);

                DockPanel d5 = new DockPanel();
                d5.Children.Add(drinkBar);
                d5.Children.Add(drinkBarIndicator);
                InfoText.Children.Add(d5);

                DockPanel d6 = new DockPanel();
                d6.Children.Add(sleepBar);
                d6.Children.Add(sleepBarIndicator);
                InfoText.Children.Add(d6);

                InfoText.Children.Add(WeatherStatus);
                InfoText.Children.Add(DressStatus);
                InfoText.Children.Add(DrunkStatus);
                InfoText.Children.Add(ImportantNotes);
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
            }

            List<OptionList> ls = new List<OptionList>();
            ls.Add(new OptionList() { Name = "Персонаж" });
            ls.Add(new OptionList() { Name = "Навыки" });
            ls.Add(new OptionList() { Name = "Статистика" });
            ls.Add(new OptionList() { Name = "Лицо" });
            ls.Add(new OptionList() { Name = "Тело" });
            ls.Add(new OptionList() { Name = "Одежда" });
            ls.Add(new OptionList() { Name = "Татуировки" });
            ls.Add(new OptionList() { Name = "Пирсинг" });

        }

        private void webBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            doc = (mshtml.HTMLDocument)MainBrowser.Document;
            mshtml.HTMLDocumentEvents2_Event iEvent;
            iEvent = (mshtml.HTMLDocumentEvents2_Event)doc;
            iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);
            iEvent.onmouseover += new mshtml.HTMLDocumentEvents2_onmouseoverEventHandler(MainMouseOver);
            LoadContent(StartLocation);
        }

        private void LoadContent(dynamic folder)
        {

            using (GLScene game = (folder.GetType() == typeof(GLScene)) ? folder : gl.GetView((String)folder, newGameStarted))
            {
                if (newGameStarted)
                {
                    newGameStarted = false;
                }
                if (game.Exception != null)
                {
                    MessageBox.Show(game.Exception.Message);
                    return;
                }
                if (isWindowSet == false)
                {
                    Title = Title + " " + game.GetPlayer().Name + " " + game.GetPlayer().LastName + ". " + Version;
                    isWindowSet = true;
                }
                //GameData = gl.GetState();

                if (!String.IsNullOrEmpty(game.sc.Message))
                {
                    InfoMessage = game.sc.Message;
                }

                if (ErrorMessage != null)
                {
                    gl.LoadErrorMessage(ErrorMessage);
                    ErrorMessage = null;
                }

                if (InfoMessage != null)
                {
                    gl.LoadInfoMessage(InfoMessage);
                    InfoMessage = null;
                }


                String cont = game.sc.Description.Replace("src='", "src='" + System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\'));
                cont = cont.Replace("src=\"", "src=\"" + System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\'));
                doc.getElementById("bodyId").innerHTML = cont;

                Callbacks = game.sc.Callbacks;
                Destinations.ItemsSource = game.sc.Directions;
                Actions.ItemsSource = game.sc.Actions;
                Actors.ItemsSource = game.sc.Actors;

                time.Text = game.data.time.GetTime();
                money.Text = game.data.player.Money.ToString() + " рублей в кошельке";

                exciteBar.Value = game.data.player.Excite;
                exciteBar.Maximum = 100;
                exciteBar.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(game.data.player.IndicatorReverseColor(game.data.player.Excite, 100)));
                exciteBarIndicator.Text = game.data.player.Excite + " Возбуждение";


                healthBar.Value = game.data.player.Health;
                healthBar.Maximum = game.data.player.maxHealth;
                healthBar.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(game.data.player.IndicatorColor(game.data.player.Health, game.data.player.maxHealth)));
                healthBarIndicator.Text = game.data.player.Health + "/" + game.data.player.maxHealth + " здоровье";

                mindBar.Value = game.data.player.Mind;
                mindBar.Maximum = game.data.player.maxMind;
                mindBar.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(game.data.player.IndicatorColor(game.data.player.Mind, game.data.player.maxMind)));
                mindBarIndicator.Text = game.data.player.Mind + "/" + game.data.player.maxMind + " чистота разума";

                manaBar.Value = game.data.player.Mana;
                manaBar.Maximum = game.data.player.maxMana;
                manaBar.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(game.data.player.IndicatorColor(game.data.player.Mana, game.data.player.maxMana)));
                manaBarIndicator.Text = game.data.player.Mana + "/" + game.data.player.maxMana + " настроение";

                energyBar.Value = game.data.player.Energy;
                energyBar.Maximum = game.data.player.maxEnergy;
                energyBar.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(game.data.player.IndicatorColor(game.data.player.Energy, game.data.player.maxEnergy)));
                energyBarIndicator.Text = game.data.player.Energy + "/" + game.data.player.maxEnergy + " сытость";

                drinkBar.Value = game.data.player.Drink;
                drinkBar.Maximum = game.data.player.maxDrink;
                drinkBar.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(game.data.player.IndicatorColor(game.data.player.Drink, game.data.player.maxDrink)));
                drinkBarIndicator.Text = game.data.player.Drink + "/" + game.data.player.maxDrink + " жажда";

                sleepBar.Value = game.data.player.Sleep;
                sleepBar.Maximum = game.data.player.maxSleep;
                sleepBar.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(game.data.player.IndicatorColor(game.data.player.Sleep, game.data.player.maxSleep)));
                sleepBarIndicator.Text = game.data.player.Sleep + "/" + game.data.player.maxSleep + " бодрость";

                Weather dr = game.GetWeather();
                if (dr != null)
                {
                    WeatherStatus.Text = dr.GetWeather();
                }
                if (game.data.BlockActors == 1)
                {
                    Actors.IsEnabled = false;
                }
                else
                {
                    Actors.IsEnabled = true;
                }
                if (game.data.BlockBag == 1)
                {
                    BagButton.IsEnabled = false;
                    SmallBagButton.IsEnabled = false;
                }
                else
                {
                    BagButton.IsEnabled = true;
                    SmallBagButton.IsEnabled = true;
                }
                DressButton.IsEnabled = (game.data.BlockWear == 1) ? false : true;

                UpdateleftPanel();
            }
        }

        private void UpdateleftPanel()
        {
            GLData gameData = gl.GetState();
            var ph = gameData.player.GetHealth();
            var pp = gameData.player.GetWillPower();
            var pm = gameData.player.GetMana();
            health.FontSize = ph.Font;
            health.Text = ph.Name;
            health.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(ph.color));
            willpower.FontSize = pp.Font;
            willpower.Text = pp.Name;
            willpower.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(pp.color));
            mana.FontSize = pm.Font;
            mana.Text = pm.Name;
            mana.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(pm.color));

            var dr = gameData.player.GetDrunk();
            DrunkStatus.Text = dr.Name;
            DrunkStatus.FontSize = dr.Font;
            DrunkStatus.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(dr.color));

            if (gameData.player.GetPlayer().Bag != null)
            {
                BagButton.Visibility = Visibility.Visible;
                BagButton.ToolTip = gameData.player.GetPlayer().Bag.Name;
            }
            else
            {
                BagButton.Visibility = Visibility.Collapsed;
            }

            if (gameData.player.GetPlayer().SmallBag != null)
            {
                SmallBagButton.Visibility = Visibility.Visible;
                SmallBagButton.ToolTip = gameData.player.GetPlayer().SmallBag.Name;
            }
            else
            {
                SmallBagButton.Visibility = Visibility.Collapsed;
            }

            var DrType = gameData.player.GetDressType();
            var DrStatus = gameData.player.GetDressStatus();
            var BraStatus = gameData.player.GetBraStatus();
            var PanStatus = gameData.player.GetPantiesStatus();
            var DrView = gameData.player.GetVisualDressView();
            if (DrType != null)
            {
                if (!String.IsNullOrEmpty(DrType.Name)) DrType.Name += "\r\n";
                if (!String.IsNullOrEmpty(DrStatus.Name)) DrStatus.Name += "\r\n";
                if (!String.IsNullOrEmpty(BraStatus.Name)) BraStatus.Name += "\r\n";
                if (!String.IsNullOrEmpty(PanStatus.Name)) PanStatus.Name += "\r\n";
                if (!String.IsNullOrEmpty(DrView.Name)) DrView.Name += "\r\n";
                DressStatus.Text = DrType.Name + DrStatus.Name + BraStatus.Name + PanStatus.Name + DrView.Name;
                DressStatus.Text = DressStatus.Text.Trim();
            }
            ImportantNotes.Text = "";
            ImportantNotes.Text = String.Join("\r\n", gameData.Notifications.Select(x => x.Notification));
            if (ImportantNotes.Text == "")
            {
                ImportantNotes.Background = Brushes.Transparent;
            }
            else
            {
                ImportantNotes.Background = Brushes.LightPink;
            }

        }

        private void ExecuteCallBack(String id)
        {

            var cbs = (Dictionary<String, CallbackDTO>)Callbacks;
            var cb = cbs.FirstOrDefault(x => x.Key == id).Value;
            try
            {
                //gl.Load(GameData);
                if (cb.IsDynamicScene)
                {
                    using (GLScene game = gl.RunCallBack(cb))
                    {
                        if (cb.LoadLast != null)
                        {
                            using (GLScene lastGame = gl.RunCallBack(cb.LoadLast))
                            {
                                LoadContent(lastGame);
                            }
                        }
                        else
                        {
                            LoadContent(game);
                        }
                    }
                }
                else
                {
                    using (GLScene game = gl.RunCallBack(cb))
                    {                        
                        if (!String.IsNullOrEmpty(game.sc.Redirect))
                        {
                            if (!String.IsNullOrEmpty(game.sc.Error))
                            {
                                ErrorMessage = game.sc.Error;
                            }
                            LoadContent(game.sc.Redirect);
                            return;
                        }

                        if (!String.IsNullOrEmpty(game.sc.Message))
                        {
                            InfoMessage = game.sc.Message.Replace("\n", "<br />"); ;
                        }

                        LoadContent(cb.Scene);
                    }
                }
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
            }
            return;
        }


        private void ExecuteCallBackHelp(String id)
        {

            var cbs = (Dictionary<String, CallbackDTO>)InternalCallbacks;
            var cb = cbs.FirstOrDefault(x => x.Key == id).Value;
            try
            {
                //gl.Load(GameData);
                using (GLScene game = gl.RunCallBack(cb))
                {
                    InternalButtonClick(cb.Scene);
                }
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
            }
            return;
        }

        private void ExecuteCallBackHtml(String id)
        {

            var cbs = (Dictionary<String, CallbackDTO>)InternalCallbacks;
            var cb = cbs.FirstOrDefault(x => x.Key == id).Value;
            try
            {
                using (GLScene game = gl.RunCallBackTime(cb))
                {
                    HtmlCallBack(cb);
                }
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
            }
            return;
        }

        private void MainMouseOver(mshtml.IHTMLEventObj e)
        {
            doc.focus();
        }

        private bool ClickEventHandler(mshtml.IHTMLEventObj e)
        {
            try
            {
                var Src = e.srcElement;
                String TagName = e.srcElement.tagName;
                if (TagName.ToLower() == "img")
                {
                    TagName = e.srcElement.parentElement.tagName;
                    if (!String.IsNullOrEmpty(TagName) && TagName.ToLower() == "a")
                    {
                        Src = e.srcElement.parentElement;
                    }
                }
                String className = Src.getAttribute("className");
                if (!String.IsNullOrEmpty(className) && className == "nodel")
                {
                    return false;
                }
                if (!String.IsNullOrEmpty(TagName) && TagName.ToLower() == "a")
                {
                    String AttributeHref = Src.getAttribute("href");
                    if (!String.IsNullOrEmpty(AttributeHref))
                    {
                        String[] SplitHref = AttributeHref.Split(':');
                        if (SplitHref.Length == 2 && !String.IsNullOrEmpty(SplitHref[1]) && SplitHref[1] != "#")
                        {
                            if (SplitHref[0] == "callback")
                            {
                                ExecuteCallBack(SplitHref[1]);
                            }
                            else if (SplitHref[0] == "scene")
                            {
                                LoadContent(SplitHref[1]);
                            }
                        }
                    }
                }
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
                return false;
            }
            return false;
        }

        private void LocationSelected(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null)
                {
                    DirectionDTO direction = (DirectionDTO)item.Content;
                    if (String.IsNullOrEmpty(direction.Scene) || direction.Scene == "#")
                    {
                        return;
                    }
                    if (!String.IsNullOrEmpty(direction.id))
                    {
                        ExecuteCallBack(direction.id);
                        return;
                    }
                    LoadContent(direction.Scene);
                }
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
            }
        }

        private void ActionSelected(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null)
                {
                    ActionDTO action = (ActionDTO)item.Content;
                    if (String.IsNullOrEmpty(action.Scene) || action.Scene == "#")
                    {
                        return;
                    }
                    if (!String.IsNullOrEmpty(action.id))
                    {
                        ExecuteCallBack(action.id);
                        return;
                    }
                    LoadContent(action.Scene);

                }
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
            }
        }

        private void ActorSelected(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null)
                {
                    ActorsDTO actor = (ActorsDTO)item.Content;
                    if (String.IsNullOrEmpty(actor.Scene) || actor.Scene == "#")
                    {
                        return;
                    }
                    if (!String.IsNullOrEmpty(actor.id))
                    {
                        ExecuteCallBack(actor.id);
                        return;
                    }
                    LoadContent(actor.Scene);

                }

            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.Show();
            }
        }
    }
}
