using System;
#nullable enable

namespace GeometricObjectsSolution
{
    [Serializable]
    public class InvalidMeasureException : Exception
    {
        public InvalidMeasureException() { }
        public InvalidMeasureException(string message) : base(message) { }
        public InvalidMeasureException(string message, Exception inner) : base(message, inner) { }
        protected InvalidMeasureException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
