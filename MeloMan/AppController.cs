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
using System.Windows.Controls;

using FileScaner;
using MeloMan.SpectrumAnalyzer;
using MeloMan.Visualizer;

namespace MeloMan
{
	/// <summary>
	/// Main handling class
	/// </summary>
	public class AppController
	{
		private ISignal fileSignal;
		
		private Spectrum spectrum;
		private Analyzer analyzer;

		public SpectrogramRenderer SpecRenderer;
		
		public AppController()
		{
			analyzer = new Analyzer();
			SpecRenderer = new SpectrogramRenderer();
		}
		
		public void LoadFileSignal(string path) 
		{
			fileSignal = FileScanerAPI.ScanWAV(path);
		}
		
		public void TransformFile()
		{
			if (fileSignal == null)
				throw new FormatException("Audio file hasn't loaded!");
			
			spectrum = analyzer.GetSpectrum(fileSignal);
		}
		
		public void RenderSpectrogram(Image img, int width, int height)
		{
			if (spectrum == null)
				throw new FormatException("Spectrum hasn't transformed!");

			//var renderer = new Visualizer.SpectrogramRenderer(spectrum);
			SpecRenderer.Spectrum = spectrum;
			SpecRenderer.DrawSpectrogram(img, width, height);
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

			/*
			var test = new Spectrum(
				new SpectrumLine[] {
				new SpectrumLine(
					new FreqPoint[] {
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1),  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1),  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1),  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1),  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1),  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2)
					}
				, 0),
				new SpectrumLine(
					new FreqPoint[] {  
						new FreqPoint(Complex.One, 2),   
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),  
						new FreqPoint(Complex.One, 2),
						new FreqPoint(Complex.Zero, 1),
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1), 
						new FreqPoint(Complex.Zero, 1)
					}
				, 0)
				}
			);
			 */