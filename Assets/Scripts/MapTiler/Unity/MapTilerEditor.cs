using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.MapTiler.Unity;

namespace MapTiler.Unity
{
    [CustomEditor(typeof(MapTiler))]
    class MapTilerEditor : Editor
    {
        Dictionary<int, Tile> tileButtons;
        Tile activeTile;

        private void OnEnable()
        {
            
        }

        //public override void OnInspectorGUI()
        //{
        //    serializedObject.Update();
        //    EditorGUILayout.HelpBox("Test", MessageType.Info);
        //    serializedObject.ApplyModifiedProperties();
        //}

        void OnSceneGUI()
        {
            Texture2D backgroundColor = new Texture2D(1, 1);
            backgroundColor.SetPixel(0, 0, Color.blue);
            GUI.skin.button.onHover.background = backgroundColor;
            Handles.color = Color.blue;
            Handles.color = Color.yellow;
            MapTiler mapTiler = (MapTiler)target;
            Map map = mapTiler.map;
            Vector3 mapOrigin = new Vector3(map.origin.x, map.origin.y, 0);

            foreach (Layer layer in map.layers)
            {
                DrawLayer(mapOrigin, layer);
            }
        }

        void HandleMouseEvent (Event m_Event)
        {

            if (m_Event.type == EventType.MouseDown)
            {
                Debug.Log("Mouse Down." + m_Event);
            }

            if (m_Event.type == EventType.MouseDrag)
            {
                Debug.Log("Mouse Dragged.");
            }

            if (m_Event.type == EventType.MouseUp)
            {
                Debug.Log("Mouse Up.");
            }
        }

        void DrawLayer (Vector3 offset, Layer layer)
        {
            Vector3 origin = new Vector3(layer.origin.x + offset.x, layer.origin.y + offset.y, 0);
            int tileWidth = 1;
            int tileHeight = 1;

            for (int x = 0; x < layer.width; x++)
            {
                for (int y = 0; y < layer.height; y++)
                {
                    DrawTile(new Vector3(origin.x + (x * tileWidth), origin.y + (y * tileHeight), 0), tileWidth, tileHeight, new Tile());
                }
            }
        }

        void DrawTile (Vector3 position, int width, int height, Tile tile)
        {
            int controlId = GUIUtility.GetControlID(FocusType.Passive);

            TileHandle.Draw(controlId, position, width, height, Quaternion.identity);
        }

        void DrawTileBrush ()
        {

        }
    }
}
