using System;
using System.Collections.Generic;

namespace MapTiler
{
    [Serializable]
    public class Map
    {
        public int maxLayers = 10;
        public int width;
        public int height;
        public List<Layer> layers;
        public List<Tile> tiles;
        public Point origin;

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
