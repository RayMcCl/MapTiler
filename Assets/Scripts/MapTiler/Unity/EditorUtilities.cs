using UnityEngine;
using UnityEditor;

namespace MapTiler.Unity
{
    public class EditorUtilities
    {
        /// <summary>
        /// Triggers a repaint on the Scene view.
        /// </summary>
        public static void RepaintSceneView ()
        {
            // Force sceneview to repaint
            EditorWindow view = EditorWindow.GetWindow<SceneView>();
            view.Repaint();
        }
    }
}
