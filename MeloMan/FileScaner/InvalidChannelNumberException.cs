using System;
using System.Runtime.Serialization;

namespace FileScaner
{
    [Serializable]
    internal class InvalidChannelNumberException : Exception
    {
        public InvalidChannelNumberException()
        {
        }

        public InvalidChannelNumberException(string message) : base(message)
        {
        }

        public InvalidChannelNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidChannelNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}