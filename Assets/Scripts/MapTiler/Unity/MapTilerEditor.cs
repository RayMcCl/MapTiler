using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using MapTiler.Unity.View;

namespace MapTiler.Unity
{
    [CustomEditor(typeof(MapTiler))]
    public class MapTilerEditor : Editor
    {
        public MapTiler mapTiler;
        Dictionary<int, Tile> tileButtons;
        public Tile activeTile;
        public Layer activeLayer;

        public override void OnInspectorGUI()
        {
            mapTiler = (MapTiler)target;
            MapPropertiesView mapProperties = new MapPropertiesView(this);
            mapProperties.Draw();
        }

        void OnSceneGUI()
        {
            mapTiler = (MapTiler)target;
            Map map = mapTiler.map;
            Vector3 mapOrigin = new Vector3(map.origin.x, map.origin.y, 0);

            if (activeLayer != null)
            {
                DrawLayer(mapOrigin, activeLayer);
            }
        }

        /// <summary>
        /// Draws the Layer to the Scene view.
        /// </summary>
        /// <param name="offset">The Map offset the layer should be drawn relative to.</param>
        /// <param name="layer">The Layer to draw.</param>
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

        /// <summary>
        /// Draws the Tile to the Scene view.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="tile"></param>
        void DrawTile (Vector3 position, int width, int height, Tile tile)
        {
            int controlId = GUIUtility.GetControlID(FocusType.Passive);
            TileHandle handle = new TileHandle();

            handle.Draw(controlId, position, width, height, Quaternion.identity);
        }

        void DrawTileBrush ()
        {

        }
    }
}
