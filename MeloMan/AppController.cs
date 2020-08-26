/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 26.08.2020
 * Time: 21:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FileScaner;

namespace MeloMan
{
	/// <summary>
	/// Main handling class
	/// </summary>
	public class AppController
	{
		private ISignal fileSignal;
		
		public AppController()
		{
			fileSignal = null;
		}
		
		public void LoadFileSignal(string path) {
			fileSignal = FileScanerAPI.ScanWAV(path);
		}
	}
}
