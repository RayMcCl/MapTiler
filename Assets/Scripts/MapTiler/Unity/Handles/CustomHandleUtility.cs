using UnityEngine;
using UnityEditor;

namespace MapTiler.Unity
{
    class CustomHandleUtility
    {
        public static float DistanceToRectangle (Vector3 position, Quaternion rotation, Vector2 size)
        {
            Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(position.x, position.y, position.z), Quaternion.identity, new Vector3(size.x, size.y, 1));
            Vector3 pointWorldPos = matrix.MultiplyPoint3x4(Vector3.one);
            return HandleUtility.DistanceToRectangle(pointWorldPos, rotation, 1);
        }
    }
}
