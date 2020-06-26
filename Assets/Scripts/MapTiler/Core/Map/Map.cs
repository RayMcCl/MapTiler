using System;
using System.Collections.Generic;

namespace MapTiler
{
    public class Map
    {
        static int maxLayers = 10;
        List<Layer> layers;

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
