using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeloMan;

namespace FileScaner
{
    // API for FileScanner modeles controlling
    public class FileScanerAPI
    {
        // only first channel yet
        public static ISignal ScanWAV(string path, int channel)
        {
            var wav = new WAVFile(path);

            if (wav.Channels < channel)
                throw new InvalidChannelNumberException();

            return new DigitalSignal(wav.GetChannel(channel), wav.GetDuration());
        }

        public static ISignal ScanWAV(string path)
        {
            return ScanWAV(path, 0);
        }
    }
}
