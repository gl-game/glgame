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
using GLCore.Locations;

namespace WEBQGame
{
    public partial class MainWindow : Window
    {

        String InternalMessage = "";
        private void helpBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            docHelp = (mshtml.HTMLDocument)HelpBrowser.Document;
            mshtml.HTMLDocumentEvents2_Event iEventHelp;
            iEventHelp = (mshtml.HTMLDocumentEvents2_Event)docHelp;
            iEventHelp.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(HelperClickEventHandler);
            iEventHelp.onmouseover += new mshtml.HTMLDocumentEvents2_onmouseoverEventHandler(HelpMouseOver);
        }

        private void HelpMouseOver(mshtml.IHTMLEventObj e)
        {
            docHelp.focus();
        }

        private bool HelperClickEventHandler(mshtml.IHTMLEventObj e)
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
                            if (SplitHref[0] == "close")
                            {                                
                                GLData game = gl.GetState();
                                LoadContent(game.CurrentScene);
                                MainBrowser.Visibility = Visibility.Visible;
                                HelpBrowser.Visibility = Visibility.Collapsed;
                                Actions.IsEnabled = true;
                                Actors.IsEnabled = true;
                                Destinations.IsEnabled = true;
                                MainBrowser.Focus();
                            } else if (SplitHref[0] == "callback")
                            {
                                ExecuteCallBackHelp(SplitHref[1]);
                            } else if (SplitHref[0] == "htmlcallback")
                            {
                                ExecuteCallBackHtml(SplitHref[1]);
                            }
                        }
                    }
                }
            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.ShowDialog();
                return false;
            }
            return false;            
        }

        private void SmallBagButtonClick(object sender, RoutedEventArgs e)
        {
            InternalButtonClick("SmallBag");
        }

        private void BagButtonClick(object sender, RoutedEventArgs e)
        {
            InternalButtonClick("Bag");
        }

        private void InternalButtonClick(String DataDraw)
        {
            GLData game = gl.GetState();
            String html = DrawDataGridHtml(DataDraw);
            MainBrowser.Visibility = Visibility.Collapsed;
            HelpBrowser.Visibility = Visibility.Visible;
            Actions.IsEnabled = false;
            Actors.IsEnabled = false;
            Destinations.IsEnabled = false;
            if (!String.IsNullOrEmpty(InternalMessage))
            {
                html = "<div class='alert alert-info'>" + InternalMessage + "</div>" + html;
                InternalMessage = "";
            }
            html = html.Replace("src='", "src='" + System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\'));
            html = html.Replace("src=\"", "src=\"" + System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\'));
            docHelp.getElementById("bodyId").innerHTML = html;
            UpdateleftPanel();
        }

        private void HtmlCallBack(CallbackDTO cb)
        {
            GLData game = gl.GetState();
            String html = cb.html();
            MainBrowser.Visibility = Visibility.Collapsed;
            HelpBrowser.Visibility = Visibility.Visible;
            Actions.IsEnabled = false;
            Actors.IsEnabled = false;
            Destinations.IsEnabled = false;
            if (!String.IsNullOrEmpty(InternalMessage))
            {
                html = "<div class='alert alert-info'>" + InternalMessage + "</div>" + html;
                InternalMessage = "";
            }
            html = html.Replace("src='", "src='" + System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\'));
            html = html.Replace("src=\"", "src=\"" + System.AppDomain.CurrentDomain.BaseDirectory.Trim('\\'));
            docHelp.getElementById("bodyId").innerHTML = html;
            UpdateleftPanel();
        }

        private String DrawDataGridHtml(String NextAction = "")
        {
            String html = "";
            using (GLScene game = gl.GetViewStatic())
            {
                if (NextAction == "SmallBag")
                {
                    html = game.DrawBagHtml(game.GetPlayer().SmallBag);
                }
                else if (NextAction == "Bag")
                {
                    html = game.DrawBagHtml(game.GetPlayer().Bag);
                }
                else if (NextAction == "Bag")
                {
                    html = game.DrawMirrorHtml();
                }
                else if (NextAction == "Dress")
                {
                    html = game.DrawWearHtml();
                }
                InternalCallbacks = game.sc.InternalCallbacks;
                InternalMessage = game.sc.InternalMesage;
                return html;
            }
        }

        private void DressButtonClick(object sender, RoutedEventArgs e)
        {
            InternalButtonClick("Dress");
        }

    }
}
