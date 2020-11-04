using System;
#nullable enable

namespace GeometricObjectsSolution
{
    [Serializable()]
    public class Circle : GeometricObject, IDisposable
    {
        #region +--- Destruktor ------------------------------------+
        private bool disposed;
        public void Dispose()
        {
            if (!disposed)
            {
                CountCircles--;
                CountGeometricObjects--;
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }
        ~Circle() => Dispose();
        #endregion

        #region +--- Konstruktoren ---------------------------------+
        public Circle() : this(0, 0, 0) { }
        public Circle(int radius) : this(radius, 0, 0) { }
        public Circle(int radius, double x, double y)
        {
            _Center.X = x;
            _Center.Y = y;
            Radius = radius;
            Circle.CountCircles++;
        }
        public Circle(int radius, Point center)
        {
            Radius = radius;
            _Center = center;
            Circle.CountCircles++;
        }
        #endregion

        #region +--- Eigenschaften ---------------------------------+
        protected int _Radius;
        public virtual int Radius
        {
            get => _Radius;
            set
            {
                if (value >= 0)
                {
                    _Radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
                else
                {
                    InvalidMeasureException ex = new InvalidMeasureException();
                    ex.Data.Add("Time", DateTime.Now);
                    OnInvalidMeasure(new InvalidMeasureEventArgs(value, nameof(Radius), ex));
                }
            }
        }
        #endregion

        #region +--- Methoden --------------------------------------+
        public override double GetArea() => Math.Pow(Radius, 2) * Math.PI;
        public override double GetPerimeter() => 2 * Radius * Math.PI;
        public int Bigger(Circle kreis)
        {
            if (Radius > kreis.Radius) return 1;
            if (Radius < kreis.Radius) return -1;
            return 0;
        }

        public virtual void Move(double dx, double dy, int dRadius)
        {
            MovingEventArgs e = new MovingEventArgs();
            OnMoving(e);
            if (e.Cancel) return;

            XCoordinate += dx;
            YCoordinate += dy;
            Radius += dRadius;

            OnMoved(new EventArgs());
        }

        public override string ToString() => "Circle, R=" + Radius + ", Fläche=" + GetArea();
        #endregion

        #region +--- Klasseneigenschaften --------------------------+
        public static int CountCircles { get; protected set; }
        #endregion

        #region +--- Klassenmethoden -------------------------------+
        public static double GetArea(int radius) => Math.PI * Math.Pow(radius, 2);
        public static double GetPerimeter(int radius) => 2 * Math.PI * radius;
        #endregion

        #region Beutzerdefinierte Typkonvertierung
        public static explicit operator Rectangle(Circle circle) => new Rectangle(
                2 * circle.Radius,
                2 * circle.Radius,
                circle.XCoordinate - circle.Radius,
                circle.YCoordinate - circle.Radius);
        #endregion

    }
}