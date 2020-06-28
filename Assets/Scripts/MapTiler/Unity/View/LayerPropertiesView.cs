using UnityEngine;
using UnityEditor;

namespace MapTiler.Unity.View
{
    class LayerPropertiesView : View
    {
        MapTilerEditor editor;
        public LayerPropertiesView(MapTilerEditor editor)
        {
            this.editor = editor;
        }

        public override void Draw ()
        {
            Layer activeLayer = editor.activeLayer;

            if (activeLayer != null)
            {
                activeLayer.name = EditorGUILayout.TextField("Layer", activeLayer.name);
                activeLayer.origin = EngineUtilities.PointFromVector2(EditorGUILayout.Vector2Field("Origin", EngineUtilities.PointToVector2(activeLayer.origin)));
                activeLayer.width = EditorGUILayout.IntField("Width", activeLayer.width);
                activeLayer.height = EditorGUILayout.IntField("Height", activeLayer.height);
            }
        }
    }
}
