/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 29.08.2020
 * Time: 22:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Linq;

namespace MeloMan.Visualizer
{
	/// <summary>
	/// Description of WaveImage.
	/// </summary>
	public class WaveImage
	{
		protected double[] wave;
		
		public WaveImage(double[] signal) 
		{
			wave = signal;
		}
		
		
		/*
		 * Returns array of wave columns heights for area size
		 */
		protected int[] GetColumns(int width, int height) {
			var heights = new int[width];
			
			var step = ((float)wave.Length - 1)/width;
			var factor = wave.Max() / height;
			
			for (var i = 0; i < width; i++)
			{
				var idx = (int)(i * step);
				heights[i] = (int)(wave[idx] / factor); 
			}
			
			return heights;
		}
	}
}
