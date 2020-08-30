/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 08/30/2020
 * Time: 10:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Numerics;

namespace MeloMan.SpectrumAnalyzer
{
	/// <summary>
	/// Description of FreqPoint.
	/// </summary>
	public class FreqPoint
	{
		public readonly Complex Coords;
		public readonly double Freq;
		
		public FreqPoint(Complex coords, double hzFreq)
		{
			Coords = coords;
			Freq = hzFreq;
		}
	}
}
