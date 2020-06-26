using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace MapTiler
{
    class MapTilerWindow : EditorWindow
    {
        List<Plugin> supportedPlugins = new List<Plugin>();

        public MapTilerWindow ()
        {
            supportedPlugins.Add(new MapProperties());
        }

        [MenuItem("Window/Map Tiler")]
        public static void ShowWindow ()
        {
            EditorWindow.GetWindow(typeof(MapTilerWindow));
        }

        private void OnGUI()
        {
            foreach(Plugin plugin in supportedPlugins)
            {
                plugin.Draw();
            }
        }
    }
}
