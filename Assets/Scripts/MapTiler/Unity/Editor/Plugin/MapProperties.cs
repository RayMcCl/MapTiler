using UnityEngine;
using UnityEditor;

namespace MapTiler
{
    public class MapProperties : Plugin
    {
        Map map;
        public void SetMap(Map map)
        {
            this.map = map;
        }
        public override void Draw ()
        {
            GUI.Button(new Rect(0, 0, 100, 50), "Test");
        }
    }
}