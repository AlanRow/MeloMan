/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 26.08.2020
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;

namespace MeloMan.Visualizer
{
	/// <summary>
	/// Description of FWaveGraph.
	/// </summary>
	public class WaveImageLoader : WaveImage
	{
		public static Color DefaultWaveColor = Color.Blue;
		public static Color DefaultBackgroudColor = Color.White;
		public static Size ImageSize = new Size(800, 640);
		
		public Color WaveColor {get; set;}
		public Color BackgroundColor {get; set;}
		
		public WaveImageLoader(double[] signal) : this(signal, DefaultWaveColor, DefaultBackgroudColor) {}
		
		public WaveImageLoader(double[] signal, Color waveColor, Color backgroundColor) : base(signal)
		{
			WaveColor = waveColor;
			BackgroundColor = backgroundColor;
		}
		
		public void SaveWaveBitmap(string path)
		{
			var bitmap = GetFullBitmap(ImageSize);
			bitmap.Save(path, ImageFormat.Jpeg);
		}
		
		
		private Bitmap GetFullBitmap(Size res) {
			var bitmap = new Bitmap(res.Width, res.Height);
			var columns = GetColumns(res.Width, res.Height);
			
			/*var step = ((float)wave.Length - 1)/width;
			var factor = wave.Max() / height * 2;*/
			var mid = res.Height / 2;
			
			for (var i = 0; i < bitmap.Width; i++)
			{
				var waveLimit = columns[i];
				var topLimit = mid + waveLimit;
				var botLimit = mid - waveLimit;
				
				for (var j = 0; j < bitmap.Height; j++)
				{
					if (j < topLimit && j > botLimit)
						bitmap.SetPixel(i, j, WaveColor);
					else
						bitmap.SetPixel(i, j, BackgroundColor);
				}
			}
			
			return bitmap;
		}
		
		/*public void RenderWaveImage(DrawingVisual form, double[] wave)
		{
			using (DrawingContext ctx = form.RenderOpen())
			{
				var rect = new System.Windows.Rect(0, 0, 100, 100);
				ctx.DrawRectangle(Brushes.Red, new Pen(Brushes.Black, 3), rect);
			}
		}*/
	}
}
