using Ddd.Lib.Objects;

namespace Ddd.Lib.Transformations
{
    public interface ITransformation
    {
        void Transform(Point point);
        Point Project(Point point);
    }
}
