using System;

namespace MapTiler
{
    [Serializable]
    public class Layer
    {
        public string name;
        public int width;
        public int height;
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
