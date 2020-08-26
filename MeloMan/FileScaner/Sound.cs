using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScaner
{
    class Channel
    {
        private int[,] sound;
        private int channel;

        public Channel(int[,] soundMatrix, int channelNumber)
        {
            sound = soundMatrix;
            channel = channelNumber;
        }

        public int GetValueAt(int n)
        {
            return sound[channel, n];
        }

        // from start to end; [start, end)
        public IEnumerable<int> GetValues(int start, int end)
        {
            for (var i = start; i < end; i++)
            {
                yield return sound[channel, i];
            }
        }

        public IEnumerable<int> GetValues(int start)
        {
            return GetValues(start, sound.GetLength(1));
        }

        public IEnumerable<int> GetValues()
        {
            return GetValues(0);
        }

        public int GetSize()
        {
            return sound.GetLength(1);
        }
    }
}
