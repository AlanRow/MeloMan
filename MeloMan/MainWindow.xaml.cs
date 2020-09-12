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
using System.Windows.Shapes;

namespace MeloMan
{	
	enum MenuID
	{
		MainMenu,
		FileAnalyzingMenu		
	}
	
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		static string DEBUG_LOG = "C:\\Users\\AlanRow\\Projects\\MeloMan\\Logging\\";
		
		//private Button selected = null;
		private Grid currentMenu;
		private AppController app;
		
		public MainWindow()
		{
			InitializeComponent();
			SwitchMenuPanel(MenuID.MainMenu);
			app = new AppController();
		}
		
		private void ExitClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
		
		private void SwitchMenuPanel(MenuID newMenuName)
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
			SwitchMenuPanel(MenuID.FileAnalyzingMenu);
			var panel = (Grid)FindName("WaveFormPanel");
			panel.Visibility = Visibility.Visible;
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
						DrawWaveform();
					}
					catch (Exception ex)
					{
						File.WriteAllText(DEBUG_LOG + "error_log.txt", String.Format("{0}: {1}", DateTime.Now.ToString(), ex.Message));
						File.WriteAllText(DEBUG_LOG + "error_log.txt", ex.StackTrace);
						MessageBox.Show(ex.Message, "File handling error");
					}
				}
				else
				{
					MessageBox.Show("Only WAV files is supported!", "Invalid file extension");
				}
				
			}
		}
		
		private void DrawWaveform() 
		{	
			var waveform = (System.Windows.Shapes.Path)FindName("WaveForm");
			app.RenderAudioWave(waveform);
			
			waveform.SizeChanged += (ev, sender) => {
				app.RenderAudioWave(waveform);
			};
		}
		
		private void TransformSettingsClick(object sender, RoutedEventArgs e)
		{
		}
		
		private void ViewSettingsClick(object sender, RoutedEventArgs e)
		{
			var form = new ViewSettingsForm(app.SpecRenderer);
			form.ShowDialog();
		}
		
		private void TransformClick(object sender, RoutedEventArgs e)
		{
			app.TransformFile();
			var img = (Image)FindName("SpectrogramImage");
			var cont = (Canvas)FindName("SpectrogramContainer");
			app.RenderSpectrogram(img, (int)cont.ActualWidth, (int)cont.ActualHeight);
		}
		
		private void MainMenuClick(object sender, RoutedEventArgs e)
		{
			SwitchMenuPanel(MenuID.MainMenu);
		}
	}
}