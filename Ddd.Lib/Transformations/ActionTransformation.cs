using System;
using Ddd.Lib.Objects;

namespace Ddd.Lib.Transformations
{
    public class ActionTransformation : ITransformation
    {
        private Func<Point, Point> func;

        public ActionTransformation(Action<Point> action)
        {
            func = p => { action(p); return null; };
        }

        public ActionTransformation(Func<Point, Point> func)
        {
            this.func = func;
        }

        public Point Project(Point point)
        {
            return func(point);
        }

        public void Transform(Point point)
        {
            func(point);
        }
    }
}
