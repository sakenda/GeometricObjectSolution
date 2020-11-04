using System;

namespace GeometricObjectsSolution
{
    [Serializable()]
    public struct Point
    {
        private double _X;
        private double _Y;
        public double X
        {
            get => _X;
            set => _X = value;
        }
        public double Y
        {
            get => _Y;
            set => _Y = value;
        }
        public Point(double x, double y)
        {
            _X = x;
            _Y = y;
        }
    }
}
