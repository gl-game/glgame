using GLCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WEBQGame
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class StatsView : Window
    {
        GLGame gl;
        public StatsView(GLGame _gl)
        {
            gl = _gl;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String html = gl.GetPlayerStatistics();
            StatsBrowser.NavigateToString("<html><head><link href='" + System.AppDomain.CurrentDomain.BaseDirectory + "Resources/bootstrap.css' rel='stylesheet'><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'></head><body style='padding: 10px' id='bodyId'>" + html + "</body></html>");
        } 

        private void CloseErrorWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
         
    }
}
