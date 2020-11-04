using System;
#nullable enable

namespace GeometricObjectsSolution
{
    [Serializable()]
    class GraphicCircle : Circle, IDraw
    {
        public GraphicCircle() : base(0, 0, 0) { }
        public GraphicCircle(int radius) : base(radius, 0, 0) { }
        public GraphicCircle(int radius, double x, double y) : base(radius, x, y) { }

        public virtual void Draw() => Console.WriteLine("Der Kreis wird gezeichnet");
    }
}
