using Ddd.Lib.Transformations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ddd.Lib.Objects
{
    public class Figure : IEnumerable<Face>
    {
        public IEnumerable<Face> Faces { get; private set; }
        public event EventHandler<TransformationCompletedEventArgs> OnTransformationCompleted;

        public Figure(params Face[] faces)
        {
            Faces = faces;
        }

        public IEnumerator<Face> GetEnumerator()
        {
            return Faces.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ApplyTransformation(Transformation transformation)
        {
            var transformationMatrix = transformation.TransformationMatrix;
            ApplyTransformation(p => p.Multiply(transformationMatrix));
        }

        public void ApplyTransformation(Action<Point> transformationFunc)
        {
            var points = Faces.SelectMany(f => f.Lines.SelectMany(l => l.Points)).Distinct();
            foreach (var point in points)
            {
                transformationFunc(point);
            }

            if (OnTransformationCompleted != null)
            {
                OnTransformationCompleted(this, null);
            }
        }
    }
}
