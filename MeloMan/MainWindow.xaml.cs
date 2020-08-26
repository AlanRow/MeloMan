/*
 * Project: MeloMan
 * Version: 0.1
 * Author: AlanRow(Alexey Rogatskin)
 * Date: 25.08.2020
 */
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace MeloMan
{	
	enum Menu
	{
		MainMenu,
		FileAnalyzingMenu		
	}
	
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//private Button selected = null;
		private Grid currentMenu;
		private AppController app;
		
		public MainWindow()
		{
			InitializeComponent();
			SwitchMenuPanel(Menu.MainMenu);
			app = new AppController();
		}
		
		private void ExitClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
		
		private void SwitchMenuPanel(Menu newMenuName)
		{
			var newMenu = (Grid)FindName(newMenuName.ToString());
			if (newMenu == null)
				throw new KeyNotFoundException(String.Format("<{0}> Grid not found", newMenuName));
			if (currentMenu != null)
				currentMenu.Visibility = Visibility.Collapsed;
			currentMenu = newMenu;
			currentMenu.Visibility = Visibility.Visible;
		}
		
		
		// Main menu functions
		private void FileAnalyzingClick(object sender, RoutedEventArgs e)
		{
			SwitchMenuPanel(Menu.FileAnalyzingMenu);
		}
		
		private void CustomSignalClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void AboutClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void ShowAddSignalForm(object sender, RoutedEventArgs e)
		{
			/*var form = new AddSignallForm();
			form.ShowDialog();*/
		}
		
		
		// File analyzing menu functions
		private void LoadFileClick(object sender, RoutedEventArgs e)
		{
			var dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == true)
			{
				var path = dialog.FileName;
				var name = path.Split('\\').Last();
				var ext = name.Split('.').Last().ToLower();
				
				if (ext == "wav")
				{
					try 
					{
						app.LoadFileSignal(path);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "File handling error");
					}
				}
				else
				{
					MessageBox.Show("Only WAV files is supported!", "Invalid file extension");
				}
				
			}
		}
		
		private void TransformSettingsClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void ViewSettingsClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void TransformClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void MainMenuClick(object sender, RoutedEventArgs e)
		{
			SwitchMenuPanel(Menu.MainMenu);
		}
	}
}