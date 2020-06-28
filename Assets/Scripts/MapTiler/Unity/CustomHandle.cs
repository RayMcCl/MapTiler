using UnityEngine;
using UnityEditor;

namespace MapTiler.Unity
{
    public class CustomHandle
    {
        public Quaternion rotation = Quaternion.identity;
        public Vector3 scale = Vector3.one;
        public Vector3 position;
        public Matrix4x4 matrix = Matrix4x4.identity;
        public HandleStyleSheet styleSheet;
        protected static Event Evt => Event.current;

        public void SetTransform(Transform transform)
        {
            rotation = transform.rotation;
            position = transform.position;
            scale = transform.localScale;
            matrix = Matrix4x4.TRS(position, rotation, scale);
        }

        public void SetTransform(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            this.rotation = rotation;
            this.position = position;
            this.scale = scale;
            matrix = Matrix4x4.TRS(position, rotation, scale);
        }

        public void SetTransform(CustomHandle handle)
        {
            position = handle.matrix.GetColumn(3);
            rotation = Quaternion.LookRotation(
                handle.matrix.GetColumn(2),
                handle.matrix.GetColumn(1)
            );
            scale = new Vector3(
                handle.matrix.GetColumn(0).magnitude,
                handle.matrix.GetColumn(1).magnitude,
                handle.matrix.GetColumn(2).magnitude
            );
            matrix = Matrix4x4.TRS(position, rotation, scale);
        }
    }
}
