using System;

namespace MapTiler
{
    public class Layer
    {
        string name;
        int width;
        int height;
        public Point origin;
        public Decimal opacity = Decimal.Zero;

        public void Resize (int width, int height)
        {
            this.width = width;
            this.height = height;
            // TODO: Cleanup tiles
        }
    }
}
