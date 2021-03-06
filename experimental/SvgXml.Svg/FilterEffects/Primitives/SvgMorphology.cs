﻿using SvgXml.Svg.Attributes;
using SvgXml.Xml.Attributes;

namespace SvgXml.Svg.FilterEffects.Primitives
{
    [Element("feMorphology")]
    public class SvgMorphology : SvgFilterPrimitive,
        ISvgCommonAttributes,
        ISvgPresentationAttributes,
        ISvgStylableAttributes
    {
        [Attribute("in", SvgNamespace)]
        public string? Input
        {
            get => this.GetAttribute("in", false, null);
            set => this.SetAttribute("in", value);
        }

        [Attribute("operator", SvgNamespace)]
        public string? Operator
        {
            get => this.GetAttribute("operator", false, "erode");
            set => this.SetAttribute("operator", value);
        }

        [Attribute("radius", SvgNamespace)]
        public string? Radius
        {
            get => this.GetAttribute("radius", false, "0");
            set => this.SetAttribute("radius", value);
        }

        public override void SetPropertyValue(string key, string? value)
        {
            base.SetPropertyValue(key, value);
            switch (key)
            {
                case "in":
                    Input = value;
                    break;
                case "operator":
                    Operator = value;
                    break;
                case "radius":
                    Radius = value;
                    break;
            }
        }
    }
}
