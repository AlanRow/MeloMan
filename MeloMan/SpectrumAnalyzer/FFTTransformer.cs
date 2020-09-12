/*
 * Created by SharpDevelop.
 * User: Kotya
 * Date: 08/30/2020
 * Time: 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Numerics;

namespace MeloMan.SpectrumAnalyzer
{
	/// <summary>
	/// Description of FFTTransformer.
	/// </summary>
	public class FFTTransformer
	{
		public Complex[] Transform(double[] signal)
        {
            var size = 1;
            while (size <= signal.Length)
                size *= 2;
            size /= 2;
			return FFTByTime(signal, size, 0);
        }

        // выделить в отдельный класс
        private Complex[] FFTByTime(double[] signal, int size, int start)
        {
            var layer = new Complex[size];
            // если size равен 1, то возвращаем массив из одного элемента
            if (size == 1)
            {
                layer[0] = signal[start];
            }
            // иначе вызываем функцию рекурсивно и формируем из ответов новый слой
            else
            {
                var half = size >> 1;
                var left = FFTByTime(signal, half, start);
                var right = FFTByTime(signal, half, start + signal.Length / size);

                for (var i = 0; i < half; i++)
                {
                    var w = Complex.FromPolarCoordinates(1, -i * 2 * Math.PI / size);
                    layer[i] = left[i] + w * right[i];
                    layer[half + i] = left[i] - w * right[i];
                }
            }

            return layer;
        }
	}
}
