using System.Collections.Generic;

namespace MapTiler
{
    static class TilePainter
    {
        public static void Paint(List<TileLayer> layers, Point point)
        {
            foreach (TileLayer layer in layers)
            {
                PaintLayer(layer, point);
            }
        }

        public static void Fill(List<TileLayer> layers, Point point)
        {
            // TODO: Write Logic
        }

        public static void Line(List<TileLayer> layers, Point start, Point end)
        {

        }

        // TODO: Figure out?
        public static void Stamp(List<TileLayer> layers, Point point) {
            
        }

        public static void PaintLayer(TileLayer layer, Point point)
        {
            Point localPoint = point - layer.origin;

            if (point.x > 0 && point.y > 0)
            {
                // layer.tiles[point.x][point.y];
            }
            // TODO: Implement
        }
    }
}
