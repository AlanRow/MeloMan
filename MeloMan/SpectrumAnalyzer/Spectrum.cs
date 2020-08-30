/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 08/30/2020
 * Time: 10:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MeloMan.SpectrumAnalyzer
{
	/// <summary>
	/// Description of Spectrum.
	/// </summary>
	public class Spectrum
	{
		public SpectrumLine[] Specs {get; set;}

		
		public Spectrum(SpectrumLine spec) : this(new SpectrumLine[] { spec }) {}
		
		public Spectrum(SpectrumLine[] specs)
		{
			Specs = specs;
		}
	}
}
