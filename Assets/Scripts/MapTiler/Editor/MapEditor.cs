using System.Collections.Generic;

namespace MapTiler
{
    public class MapEditor
    {
        Map map;
        List<Brush> brushList;
        List<Layer> activeLayers;
        Brush activeBrush;

        public MapEditor (Map map)
        {
            this.map = map;
        }

        public void SetActiveBrush (Brush brush)
        {
            activeBrush = brush;
        }

        public void AddLayer(Layer layer)
        {
            this.map.AddLayer(layer);
        }

        public void RemoveLayer (int layerIndex)
        {
            map.RemoveLayer(layerIndex);
        }

        public void ResizeLayers (int width, int height)
        {
            foreach (Layer activeLayer in activeLayers)
            {
                activeLayer.Resize(width, height);
            }
        }

        public void Select (Point start, Point end)
        {

        }
    }
}
