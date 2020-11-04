using System;
#nullable enable

namespace GeometricObjectsSolution
{
    [Serializable()]
    class GraphicRectangle : Rectangle, IDraw
    {
        public GraphicRectangle() : base(0, 0, 0, 0) { }
        public GraphicRectangle(int length, int width) : base(length, width, 0, 0) { }
        public GraphicRectangle(int length, int width, double x, double y) : base(length, width, x, y) { }

        public virtual void Draw() => Console.WriteLine("Das Rechteck wird gezeichnet");
    }
}
