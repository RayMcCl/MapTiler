using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace MapTiler.Unity
{
    [CustomEditor(typeof(MapTiler))]
    public class MapTilerEditor : Editor
    {
        private VisualElement root;
        private VisualTreeAsset tree;
        private string fullAssetPath = (UnitySettings.assetPath + "/Unity/Editor/MapTilerEditor");

        public MapTiler mapTiler;
        public Tile activeTile;
        public Layer activeLayer;
        private int activeLayerIndex = 0;

        public void OnEnable()
        {
            // Each editor window contains a root VisualElement object
            root = new VisualElement();
        }

        public override VisualElement CreateInspectorGUI()
        {
            mapTiler = (MapTiler)target;
            root.Clear();

            if (mapTiler.map.layers.Count == 0)
            {
                mapTiler.map.layers.Add(new Layer());
            }

            activeLayer = mapTiler.map.layers[0];
            //// VisualElements objects can contain other VisualElement following a tree hierarchy.
            //root.Add(label);

            //// Import UXML
            //var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(fullAssetPath + ".uxml");
            //VisualElement labelFromUXML = visualTree.CloneTree();
            //root.Add(labelFromUXML);

            // A stylesheet can be added to a VisualElement.
            // The style will be applied to the VisualElement and all of its children.
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(fullAssetPath + ".uss");

            List<string> layerNames = GetLayerNames(mapTiler.map.layers);

            PopupField<string> popupField = new PopupField<string>("Active Layer", layerNames, activeLayerIndex);

            popupField.RegisterCallback<ChangeEvent<int>>(e =>
            {
                if (popupField.index != activeLayerIndex)
                {
                    activeLayerIndex = popupField.index;
                    activeLayer = mapTiler.map.layers[activeLayerIndex];
                }
            });

            root.Add(popupField);

            if (activeLayer != null)
            {
                VisualElement layerProperties = new LayerProperties(activeLayer);

                root.Add(layerProperties);
            }

            root.styleSheets.Add(styleSheet);

            return root;
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
        void DrawLayer(Vector3 offset, Layer layer)
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
        void DrawTile(Vector3 position, int width, int height, Tile tile)
        {
            int controlId = GUIUtility.GetControlID(FocusType.Passive);
            TileHandle handle = new TileHandle();

            handle.Draw(controlId, position, width, height, Quaternion.identity);
        }

        /// <summary>
        /// Builds an array of layer names.
        /// </summary>
        /// <param name="layers"></param>
        /// <returns></returns>
        private List<string> GetLayerNames(List<Layer> layers)
        {
            List<string> layerNames = new List<string>(layers.Count);
            int layerCounter = 1;

            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].name.Length == 0)
                {
                    layerNames.Add("Layer " + layerCounter);
                    layerCounter++;
                }
                else
                {
                    layerNames.Add(layers[i].name);
                }
            }

            return layerNames;
        }

        /// <summary>
        /// Returns the index of the active layer.
        /// </summary>
        /// <param name="activeLayer">The layer that is currently active.</param>
        /// <param name="layers">The layers in the map.</param>
        /// <returns>The index of the active layer.</returns>
        private int GetActiveLayerIndex(Layer activeLayer, List<Layer> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i] == activeLayer)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}