using System.Collections.Generic;
using UnityEditor;

namespace MapTiler.Unity.View
{
    public class MapPropertiesView : View
    {
        MapTilerEditor editor;
        public MapPropertiesView (MapTilerEditor editor)
        {
            this.editor = editor;
        }

        public override void Draw ()
        {
            MapTiler mapTiler = editor.mapTiler;
            mapTiler.map.width = EditorGUILayout.IntField(mapTiler.map.width);
            mapTiler.map.height = EditorGUILayout.IntField(mapTiler.map.height);

            int selectedLayer = GetActiveLayerIndex(editor.activeLayer, mapTiler.map.layers);
            string[] layerNames = GetLayerNames(mapTiler.map.layers);

            selectedLayer = EditorGUILayout.Popup(selectedLayer, layerNames);

            if (mapTiler.map.layers[selectedLayer] != editor.activeLayer)
            {
                editor.activeLayer = mapTiler.map.layers[selectedLayer];
                EditorUtilities.RepaintSceneView();
            }
        }

        /// <summary>
        /// Builds an array of layer names.
        /// </summary>
        /// <param name="layers"></param>
        /// <returns></returns>
        private string[] GetLayerNames(List<Layer> layers)
        {
            string[] layerNames = new string[layers.Count];
            int layerCounter = 1;

            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].name.Length == 0)
                {
                    layerNames[i] = "Layer " + layerCounter;
                    layerCounter++;
                }
                else
                {
                    layerNames[i] = layers[i].name;
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
        private int GetActiveLayerIndex (Layer activeLayer, List<Layer> layers)
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
