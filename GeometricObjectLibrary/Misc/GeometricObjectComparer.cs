using System;
using System.Collections;
using System.Collections.Generic;
#nullable enable

namespace GeometricObjectsSolution
{
    class GeometricObjectComparer : IComparer, IComparer<GeometricObject>
    {
        public int Compare(object x, object y)
        {
            if (x is GeometricObject && y is GeometricObject)
                return ((GeometricObject)x).CompareTo((GeometricObject)y);
            else
                throw new InvalidCastException();
        }
        public int Compare(GeometricObject x, GeometricObject y) => GeometricObject.Bigger(x, y);
    }
}
