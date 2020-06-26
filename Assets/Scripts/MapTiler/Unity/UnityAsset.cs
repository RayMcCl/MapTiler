using UnityEngine;

namespace MapTiler
{
    public class UnityAsset : Asset<Texture2D>
    {
        public override int assetId { get; set; }
        public override Texture2D data { get; set; }
    }
}