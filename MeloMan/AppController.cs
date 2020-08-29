/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 26.08.2020
 * Time: 21:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Windows.Shapes;
using FileScaner;

namespace MeloMan
{
	/// <summary>
	/// Main handling class
	/// </summary>
	public class AppController
	{
		public ISignal fileSignal;
		
		public AppController()
		{
			fileSignal = null;
		}
		
		public void LoadFileSignal(string path) 
		{
			fileSignal = FileScanerAPI.ScanWAV(path);
		}
		
		public void RenderAudioWave(Path waveform)
		{
			if (fileSignal == null)
				throw new FormatException("Audio file hasn't loaded!");
			
			var waveDrawer = new Visualizer.WaveImageRenderer(fileSignal.GetValues().ToArray());
			waveDrawer.DrawWave(waveform);
		}
		
		public void SaveAudioWave(string path) 
		{
			if (fileSignal == null)
				throw new FormatException("Audio file hasn't loaded!");
			var waveDrawer = new Visualizer.WaveImageLoader(fileSignal.GetValues().ToArray());
			waveDrawer.SaveWaveBitmap(path);
		}
	}
}
