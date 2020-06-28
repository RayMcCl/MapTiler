using System;

namespace MapTiler
{
    [Serializable]
    public class Tile
    {
        public string name;
        Asset asset;
        public int width;
        public int height;
    }
}