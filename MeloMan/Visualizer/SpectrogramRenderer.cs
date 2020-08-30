/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 08/30/2020
 * Time: 13:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MeloMan.SpectrumAnalyzer;

namespace MeloMan.Visualizer
{
	/// <summary>
	/// Description of SpectrogramRenderer.
	/// </summary>
	public class SpectrogramRenderer
	{
		public static int COLOR_SIZE = 3;
		public static Color INTENSITY_COLOR = Colors.Blue;
		
		public Color IntensityColor {get; set;}

		private Spectrum spectrum;
		
		public SpectrogramRenderer(Spectrum spec) : this(spec, INTENSITY_COLOR) {}
		
		public SpectrogramRenderer(Spectrum spec, Color color)
		{
			IntensityColor = color;
			spectrum = spec;
		}
		
		public void DrawSpectrogram(Image img, int width, int height)
		{
			var pixels = GeneratePixels(width, height);
			var area = new Int32Rect(0, 0, width, height);
			var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);
			
			bitmap.WritePixels(area, pixels, 3 * width, 0);
			img.Source = bitmap;
		}
		
		
		private byte[] GeneratePixels(int width, int height)
		{
			var pixels = new byte[height * width * COLOR_SIZE];	
			var max = GetMaxMagn(spectrum);
			
			var colIdx = 0;
			
			for (var col = 0; col < width; col++)
			{
				if (col * (spectrum.Specs.Length - 1) > colIdx * (width - 1))
					colIdx++;
				
				var intens = GetIntensities(spectrum.Specs[colIdx], height, max);
				FillColumn(pixels, intens, col, width);
			}
			
			return pixels;
		}
		
		private double GetMaxMagn(Spectrum spec)
		{
			var max = 0.0d;
			
			foreach (var line in spec.Specs)
				foreach (var point in line.Spectrum)
					if (point.Coords.Magnitude > max)
						max = point.Coords.Magnitude;
						
			return max;
		}
		
		private double[] GetIntensities(SpectrumLine spec, int reqHeight, double max)
		{
			var intens = new double[reqHeight];
			var freqs = spec.Spectrum;
			
			var specIdx = 0;
			
			for (var i = 0; i < intens.Length; i++)
			{
				while (i * (freqs.Length - 1) > specIdx * (reqHeight - 1))
				{
					specIdx++;
				}
				
				intens[i] = freqs[specIdx].Coords.Magnitude / max;
			}
			
			return intens;
		}
		
		private void FillColumn(byte[] pixels, double[] intensities, int column, int rowWidth)
		{
			var B = IntensityColor.B;
			var G = IntensityColor.G;
			var R = IntensityColor.R;
			
			var idx = column * COLOR_SIZE;
			for (var i = 0; i < intensities.Length; i++)
			{
				var ints = intensities[i];
				pixels[idx] = (byte)(int)(B*ints);
				pixels[idx + 1] = (byte)(int)(G*ints);
				pixels[idx + 2] = (byte)(int)(R*ints);
				idx += rowWidth * COLOR_SIZE;
			}
		}
	}
}
