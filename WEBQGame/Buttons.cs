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

namespace WEBQGame
{
    public partial class MainWindow : Window
    {
        private void ButtonNewGame(object sender, RoutedEventArgs e)
        {
            try
            {
                gl.NewGame();
                newGameStarted = true;
                LoadContent(StartLocation);
                MessageBox.Show("Новая игра загружена");

            }
            catch (GLScriptException ex)
            {
                window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                window.ShowDialog();
            }
        }

        private void ButtonLoadGame(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Game saves (*.)|*.glsave";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    gl.LoadGame(File.ReadAllText(openFileDialog.FileName));
                    LoadContent(gl.GetCurrentSceneId());
                }
                catch (GLScriptException ex)
                {
                    window.ErrorLog.Text = ex.Message + Environment.NewLine + "StackTrace :" + ex.StackTrace + "" + Environment.NewLine;
                    window.ShowDialog();
                }
            }
        }

        private void ButtonSaveGame(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Game saves (*.)|*.glsave";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, gl.SaveGame());
        }                
        
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }


        private void StatsButtonClick(object sender, RoutedEventArgs e)
        {
            StatsView StatsWindow = new StatsView(gl);
            StatsWindow.ShowDialog();
        }

    }
}
