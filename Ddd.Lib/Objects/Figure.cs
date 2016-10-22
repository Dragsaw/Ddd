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
            var points = Faces.SelectMany(f => f.Lines.SelectMany(l => l.Points)).Distinct();
            var transformationMatrix = transformation.TransformationMatrix;
            foreach (var point in points)
            {
                point.Multiply(transformationMatrix);
            }

            if(OnTransformationCompleted != null)
            {
                OnTransformationCompleted(this, new TransformationCompletedEventArgs(transformation));
            }
        }
    }
}
