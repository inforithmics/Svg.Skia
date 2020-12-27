﻿using System.ComponentModel;
using SP = Svg.Picture;

namespace Avalonia.Svg
{
    /// <summary>
    /// Represents a Svg based image.
    /// </summary>
    [TypeConverter(typeof(SvgSourceTypeConverter))]
    public class SvgSource
    {
        public SP.Picture? Picture { get; set; }
    }
}