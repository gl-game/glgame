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
    public partial class ErrorView : Window
    {
        public ErrorView()
        {
            InitializeComponent();
        }


        private void CloseErrorWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        } 
         
    }
}
