using UnityEngine;
using UnityEditor;

namespace MapTiler.Unity
{
    public class TileHandle : CustomHandle
    {
        private Color currentFillColor;
        private Color currentOutlineColor;
        
        private Color fillColor = new Color(1, 1, 1, 0.3f);
        private Color outlineColor = new Color(1, 1, 1, 0.5f);

        private Color activeFillColor = new Color(0, 1, 0, 0.3f);
        private Color activeOutlineColor = new Color(0, 1, 0, 0.5f);
        
        private Color hoverFillColor = new Color(0, 0, 1, 0.3f);
        private Color hoverOutlineColor = new Color(0, 0, 1, 0.5f);

        public void Draw (int id, Vector3 origin, int width, int height, Quaternion rotation)
        {
            currentFillColor = fillColor;
            currentOutlineColor = outlineColor;

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
                    float distance = CustomHandleUtility.DistanceToRectangle(origin, Camera.current.transform.rotation, new Vector2(width, height));
                    HandleUtility.AddControl(id, distance);
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
                    Color temp = Handles.color;

                    if (id == GUIUtility.hotControl)
                    {
                        OnActive();
                    } else if ( id == HandleUtility.nearestControl && GUIUtility.hotControl == 0)
                    {
                        OnHover();
                    }

                    Handles.color = currentFillColor;
                    Handles.DrawSolidRectangleWithOutline(verts, currentFillColor, currentOutlineColor);
                    
                    // Reset the Handle color
                    Handles.color = temp;
                    break;
            }
        }

        private void OnHover ()
        {
            currentFillColor = hoverFillColor;
            currentOutlineColor = hoverOutlineColor;
        }

        private void OnActive ()
        {
            currentFillColor = activeFillColor;
            currentOutlineColor = activeOutlineColor;
        }

        private void OnMouseDown ()
        {

        }

        private void OnMouseUp ()
        {

        }
    }
}
