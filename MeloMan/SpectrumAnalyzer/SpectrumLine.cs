/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 08/30/2020
 * Time: 10:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MeloMan.SpectrumAnalyzer
{
	/// <summary>
	/// Description of SpectrumLine.
	/// </summary>
	public class SpectrumLine
	{
		public readonly FreqPoint[] Spectrum;
		public readonly double Time;
		
		public SpectrumLine(FreqPoint[] spec, double time)
		{
			Spectrum = spec;
			Time = time;
		}
	}
}
