using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DummyInstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            try
            {
                String[] steamGames = Directory.GetDirectories(@"C:\Program Files (x86)\Steam\steamapps\common");
                for (int i = 0; i < steamGames.Length; i++)
                {
                    SteamGamesListBox.Items.Add(new SteamGameItem(steamGames[i]));
                }
            }
            catch
            {
                SteamGamesListBox.Items.Add("No Steam Games Found");
            }
            SteamGamesListBox.Items.Add(new SteamGameItem());
            
        }

        private void SteamGamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SteamGameItem selectedItem = (SteamGameItem)e.AddedItems[0];
            string path = "";
            if (selectedItem.isDefault)
            {
                var dlg = new CommonOpenFileDialog();
                dlg.Title = "My Title";
                dlg.IsFolderPicker = true;
                

                dlg.AddToMostRecentlyUsedList = false;
                dlg.AllowNonFileSystemItems = false;
                
                dlg.EnsureFileExists = true;
                dlg.EnsurePathExists = true;
                dlg.EnsureReadOnly = false;
                dlg.EnsureValidNames = true;
                dlg.Multiselect = false;
                dlg.ShowPlacesList = true;

                if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    path = dlg.FileName;
                    // Do something with selected folder string
                }
            }
            else
            {
                path = selectedItem.gamePath;
            }
            FileLocationTextBox.Text = path;
            installButton.IsEnabled = true;
        }
    }
}
