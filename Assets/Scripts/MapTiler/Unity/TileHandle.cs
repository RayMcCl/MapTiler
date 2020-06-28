using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.MapTiler.Unity
{
    class TileHandle
    {
        public static void Draw (int id, Vector3 origin, int width, int height, Quaternion rotation)
        {
            Event evt = Event.current;

            Vector3[] verts = new Vector3[]
            {
                new Vector3(origin.x, origin.y, origin.z),
                new Vector3(origin.x + width, origin.y, origin.z),
                new Vector3(origin.x + width, origin.y + height, origin.z),
                new Vector3(origin.x, origin.y + height, origin.z)
            };


            switch (evt.GetTypeForControl(id))
            {
                case EventType.Layout:
                    //Handles.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(width, height, 1f));
                    Handles.RectangleHandleCap(id, origin, Quaternion.identity, 1f, EventType.Layout);

                    break;
                case EventType.MouseDown:
                    if ((HandleUtility.nearestControl == id && evt.button == 0) && GUIUtility.hotControl == 0)
                    {
                        GUIUtility.hotControl = id;
                        GUI.changed = true;
                        evt.Use();
                    }
                    break;
                case EventType.MouseUp:
                    if (GUIUtility.hotControl == id && (evt.button == 0))
                    {
                        GUIUtility.hotControl = 0;
                        evt.Use();
                    }
                    break;
                case EventType.MouseMove:
                    if (id == HandleUtility.nearestControl)
                    {
                        HandleUtility.Repaint();
                    }
                    break;
                case EventType.Repaint:
                    Color temp = Color.white;

                    Handles.color = Color.green;
                    Handles.RectangleHandleCap(id, origin, Quaternion.identity, 0.5f, EventType.Repaint);

                    Handles.color = Color.red;

                    if (id == GUIUtility.hotControl)
                    {
                        temp = Handles.color;

                        Handles.color = Handles.selectedColor * new Color(1f, 1f, 1f, 0.3f);

                    } else if ( id == HandleUtility.nearestControl && GUIUtility.hotControl == 0)
                    {
                        temp = Handles.color;
                        Handles.color = Handles.preselectionColor;
                    }


                    Handles.DrawSolidRectangleWithOutline(verts, Color.blue, Color.white);

                    Handles.color = temp;
                    break;
            }
        }
    }
}
