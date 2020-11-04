using System;
using System.ComponentModel;
#nullable enable

namespace GeometricObjectsSolution
{
    [Serializable()]
    public abstract class GeometricObject : IComparable,
                                            IComparable<GeometricObject>,
                                            INotifyPropertyChanged
    {
        #region +--- Felder ----------------------------------------+

        protected Point _Center = new Point();

        #endregion
        #region +--- Ereignisse ------------------------------------+

        public event PropertyChangedEventHandler? PropertyChanged;
        public event InvalidMeasureEventHandler? InvalidMeasure;
        public event MovingEventHandler? Moving;
        public event MovedEventHandler? Moved;

        #endregion
        #region +--- Konstruktoren ---------------------------------+

        public GeometricObject() => CountGeometricObjects++;

        #endregion
        #region +--- Eigenschaften ---------------------------------+

        public virtual double XCoordinate
        {
            get => _Center.X;
            set
            {
                _Center.X = value;
                OnPropertyChanged(nameof(XCoordinate));
            }
        }
        public virtual double YCoordinate
        {
            get => _Center.Y;
            set
            {
                _Center.Y = value;
                OnPropertyChanged(nameof(YCoordinate));
            }
        }

        #endregion
        #region +--- Instanzmethoden -------------------------------+

        public int CompareTo(GeometricObject geo)
        {
            if (GetArea() > geo.GetArea()) return 1;
            if (GetArea() == geo.GetArea()) return 0;
            return -1;
        }
        public virtual int CompareTo(Object obj)
        {
            if (obj is GeometricObject)
            {
                GeometricObject geoObject = (GeometricObject)obj;
                if (GetArea() < geoObject.GetArea()) return -1;
                if (GetArea() == geoObject.GetArea()) return 0;
                return 1;
            }
            throw new ArgumentException("Es wird der Typ 'GeometricObject' erwartet.");
        }

        public virtual void Move(Point center)
        {
            MovingEventArgs e = new MovingEventArgs();
            OnMoving(e);
            if (e.Cancel) return;
            _Center = center;
            OnMoved(new EventArgs());
        }

        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected virtual void OnInvalidMeasure(InvalidMeasureEventArgs e)
        {
            if (InvalidMeasure != null)
            {
                InvalidMeasure(this, e);
            }
            else
            {
                throw e.Error;
            }
        }
        protected virtual void OnMoving(MovingEventArgs e) => Moving?.Invoke(this, e);
        protected virtual void OnMoved(EventArgs e) => Moved?.Invoke(this, e);

        #endregion
        #region +--- Klasseneigenschaften ---------------------------+

        public static int CountGeometricObjects { get; protected set; }

        #endregion
        #region +--- Klassenmethoden ----------------------------------+

        public abstract double GetArea();
        public abstract double GetPerimeter();
        public static int Bigger(GeometricObject geo1, GeometricObject geo2)
        {
            if (geo1.GetArea() > geo2.GetArea()) return 1;
            if (geo1.GetArea() < geo2.GetArea()) return -1;
            return 0;
        }

        #endregion
        #region Operatorenüberladung

        public static bool operator >(GeometricObject geo1, GeometricObject geo2) => geo1.GetArea() > geo2.GetArea() ? true : false;
        public static bool operator <(GeometricObject geo1, GeometricObject geo2) => geo1.GetArea() < geo2.GetArea() ? true : false;
        public static bool operator >=(GeometricObject geo1, GeometricObject geo2) => geo1.GetArea() >= geo2.GetArea() ? true : false;
        public static bool operator <=(GeometricObject geo1, GeometricObject geo2) => geo1.GetArea() <= geo2.GetArea() ? true : false;
        public static bool operator ==(GeometricObject geo1, GeometricObject geo2)
        {
            if (ReferenceEquals(geo1, geo2)) return true;
            if (ReferenceEquals(geo1, null)) return false;
            return geo1.Equals(geo2);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetArea() == ((GeometricObject)obj).GetArea()) return true;
            return false;
        }
        public static bool operator !=(GeometricObject geo1, GeometricObject geo2) => !(geo1 == geo2);
        public override int GetHashCode() => base.GetHashCode();

        #endregion
    }
}
