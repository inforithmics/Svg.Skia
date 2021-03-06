﻿using System.ComponentModel;
using Svg.Model.Primitives;
using SP = Svg.Model;

namespace Avalonia.Svg
{
    /// <summary>
    /// Represents a Svg based image.
    /// </summary>
    [TypeConverter(typeof(SvgSourceTypeConverter))]
    public class SvgSource
    {
        public Picture? Picture { get; set; }
    }
}
