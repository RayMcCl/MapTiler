using System.Collections.Generic;

namespace MapTiler
{
    public class Brush
    {
        Point origin;
        List<BrushItem> items;

        public Brush(Point origin, List<BrushItem> items)
        {
            this.origin = origin;
            this.items = items;
        }
    }
}