using MapTiler;
using UnityEngine;

namespace MapTiler.Unity
{
    public static class EngineUtilities
    {
        public static Point PointFromVector2 (Vector2 vec)
        {
            return new Point((int)vec.x, (int)vec.y);
        }

        public static Vector2 PointToVector2 (Point point)
        {
            return new Vector2(point.x, point.y);
        }
    }
}
