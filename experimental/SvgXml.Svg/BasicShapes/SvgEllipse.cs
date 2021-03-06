﻿using SvgXml.Svg.Attributes;
using SvgXml.Xml.Attributes;

namespace SvgXml.Svg.BasicShapes
{
    [Element("ellipse")]
    public class SvgEllipse : SvgStylableElement,
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

        // SvgEllipse

        [Attribute("cx", SvgNamespace)]
        public string? CenterX
        {
            get => this.GetAttribute("cx", false, "0");
            set => this.SetAttribute("cx", value);
        }

        [Attribute("cy", SvgNamespace)]
        public string? CenterY
        {
            get => this.GetAttribute("cy", false, "0");
            set => this.SetAttribute("cy", value);
        }

        [Attribute("rx", SvgNamespace)]
        public string? RadiusX
        {
            get => this.GetAttribute("rx", false, null);
            set => this.SetAttribute("rx", value);
        }

        [Attribute("ry", SvgNamespace)]
        public string? RadiusY
        {
            get => this.GetAttribute("ry", false, null);
            set => this.SetAttribute("ry", value);
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
                // SvgEllipse
                case "cx":
                    CenterX = value;
                    break;
                case "cy":
                    CenterY = value;
                    break;
                case "rx":
                    RadiusX = value;
                    break;
                case "ry":
                    RadiusY = value;
                    break;
            }
        }
    }
}
