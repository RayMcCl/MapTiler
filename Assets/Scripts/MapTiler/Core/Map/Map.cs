using System;
using System.Collections.Generic;

namespace MapTiler
{
    [Serializable]
    public class Map
    {
        public int maxLayers = 10;
        public List<Layer> layers = new List<Layer>();
        public List<Tile> tiles;
        public Point origin = new Point(0, 0);

        public void AddLayer (Layer layer)
        {
            if (layers.Count < maxLayers)
            {
                layers.Add(layer);
            } else
            {
                throw new MaxLayerException();
            }
        }

        public void RemoveLayer (int layerIndex)
        {
            if (layers.Count > layerIndex)
            {
                layers.RemoveAt(layerIndex);
            } else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public List<Layer> GetLayers ()
        {
            return layers;
        }
    }
}
