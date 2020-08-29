/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 29.08.2020
 * Time: 22:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace MeloMan.Visualizer
{
	/// <summary>
	/// Description of WaveImageRenderer.
	/// </summary>
	public class WaveImageRenderer : WaveImage
	{	
		public WaveImageRenderer(double[] signal) : base(signal) {}
		
		public void DrawWave(Path form)
		{
			var w = (int)form.ActualWidth;
			var h = (int)form.ActualHeight;
			var columns = GetColumns(w, h);
			var group = new System.Windows.Media.GeometryGroup();
			
			var mid = h / 2;
			
			for (var i = 0; i < columns.Length; i++)
			{
				var start = new Point(i, mid - columns[i] / 2);
				var end = new Point(i, mid + columns[i] / 2);
				var line = new System.Windows.Media.LineGeometry(start, end);
				group.Children.Add(line);
			}
			
			form.Data = group;
		}
	}
}
