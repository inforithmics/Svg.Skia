﻿using SvgXml.Svg.Attributes;
using SvgXml.Xml.Attributes;

namespace SvgXml.Svg.Text
{
    [Element("font-face-name")]
    public class SvgFontFaceName : SvgElement,
        ISvgCommonAttributes
    {
        [Attribute("name", SvgNamespace)]
        public string? Name
        {
            get => this.GetAttribute("name", false, null); // TODO:
            set => this.SetAttribute("name", value);
        }

        public override void SetPropertyValue(string key, string? value)
        {
            base.SetPropertyValue(key, value);
            switch (key)
            {
                case "name":
                    Name = value;
                    break;
            }
        }
    }
}
