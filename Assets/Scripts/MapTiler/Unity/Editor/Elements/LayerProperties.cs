using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace MapTiler.Unity
{
    public class LayerProperties : VisualElement
    {
        public new static readonly string ussClassName = "map-tiler-layer-properties";

        public LayerProperties(Layer layer) : base()
        {
            AddToClassList(ussClassName);
            Clear();

            TextField nameField = new TextField("Name") { value = layer.name };

            nameField.RegisterValueChangedCallback(e =>
            {
                layer.name = nameField.value;
            });

            IntegerField widthField = new IntegerField("Width") { value = layer.width };

            widthField.RegisterValueChangedCallback(e =>
            {
                layer.width = widthField.value;
            });

            IntegerField heightField = new IntegerField("Height") { value = layer.height };

            heightField.RegisterValueChangedCallback(e =>
            {
                layer.height = heightField.value;
            });

            Add(nameField);
            Add(widthField);
            Add(heightField);
        }

        public Layer layer { get; set; }
    }
}