using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeloMan;

namespace FileScaner
{
    class DigitalSignal : ISignal
    {
        private Channel channel;
        private double duration;

        public DigitalSignal(Channel sound, double duration_s)
        {
            channel = sound;
            duration = duration_s;
        }

        override public int GetLength()
        {
            return channel.GetSize();
        }

        override public IEnumerable<double> GetValues()
        {
            return channel.GetValues().Select(x => (double)x);
        }

        public override double GetValueAt(int time)
        {
            return channel.GetValueAt(time);
        }

        public override double GetDurationInSeconds()
        {
            return duration;
        }
    }
}
