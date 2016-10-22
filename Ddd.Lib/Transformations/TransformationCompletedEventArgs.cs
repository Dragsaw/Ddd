using System;

namespace Ddd.Lib.Transformations
{
    public class TransformationCompletedEventArgs : EventArgs
    {
        public Transformation Transformation { get; private set; }

        public TransformationCompletedEventArgs(Transformation transformation)
        {
            Transformation = transformation;
        }
    }
}
