using System.Collections;
using System.Collections.Generic;

namespace Ddd.Lib.Objects
{
    public class Face : IEnumerable<Line>
    {
        public Face(Line l1, Line l2, Line l3, params Line[] lines)
        {
            var list = new List<Line> { l1, l2, l3 };
            if (lines != null)
            {
                list.AddRange(lines);
            }

            Lines = list;
        }

        public IEnumerable<Line> Lines { get; private set; }

        public IEnumerator<Line> GetEnumerator()
        {
            return Lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
