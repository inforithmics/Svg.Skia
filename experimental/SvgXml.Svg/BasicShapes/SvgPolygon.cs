﻿using SvgXml.Svg.Attributes;
using SvgXml.Xml.Attributes;

namespace SvgXml.Svg.BasicShapes
{
    [Element("polygon")]
    public class SvgPolygon : SvgStylableElement,
        ISvgCommonAttributes,
        ISvgPresentationAttributes,
        ISvgTestsAttributes,
        ISvgStylableAttributes,
        ISvgResourcesAttributes,
        ISvgTransformableAttributes
    {
        // ISvgTransformableAttributes

        [Attribute("transform", SvgNamespace)]
        public string? Transform
        {
            get => this.GetAttribute("transform", false, null);
            set => this.SetAttribute("transform", value);
        }

        // SvgPolygon

        [Attribute("points", SvgNamespace)]
        public string? Points
        {
            get => this.GetAttribute("points", false, null);
            set => this.SetAttribute("points", value);
        }

        public override void SetPropertyValue(string key, string? value)
        {
            base.SetPropertyValue(key, value);
            switch (key)
            {
                // ISvgTransformableAttributes
                case "transform":
                    Transform = value;
                    break;
                // SvgPolygon
                case "points":
                    Points = value;
                    break;
            }
        }
    }
}
