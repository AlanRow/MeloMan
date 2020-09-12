/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 08/30/2020
 * Time: 10:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace MeloMan.SpectrumAnalyzer
{
	/// <summary>
	/// Main class for transforming signal actions
	/// </summary>
	public class Analyzer
	{
		private FFTTransformer transformer;
		
		public Analyzer()
		{
			transformer = new FFTTransformer();
		}
		
		public Spectrum GetSpectrum(ISignal signal)
		{
			var specArr = transformer.Transform(signal.GetValues().ToArray());
			var len = (double)specArr.Length;
			var dur = signal.GetDurationInSeconds();
			
			
			var points = specArr
				.Select((val, idx) => new FreqPoint(val, len/idx * dur))
				.ToArray();
			
			return new Spectrum(new SpectrumLine[] { new SpectrumLine(points, 0) });
		}
	}
}
