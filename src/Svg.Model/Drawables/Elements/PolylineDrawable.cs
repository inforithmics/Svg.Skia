﻿using Svg.Model.Primitives;

namespace Svg.Model.Drawables.Elements
{
    public sealed class PolylineDrawable : DrawablePath
    {
        private PolylineDrawable(IAssetLoader assetLoader)
            : base(assetLoader)
        {
        }

        public static PolylineDrawable Create(SvgPolyline svgPolyline, Rect skOwnerBounds, DrawableBase? parent, IAssetLoader assetLoader, Attributes ignoreAttributes = Attributes.None)
        {
            var drawable = new PolylineDrawable(assetLoader)
            {
                Element = svgPolyline,
                Parent = parent,
                IgnoreAttributes = ignoreAttributes
            };

            drawable.IsDrawable = drawable.CanDraw(svgPolyline, drawable.IgnoreAttributes) && drawable.HasFeatures(svgPolyline, drawable.IgnoreAttributes);

            if (!drawable.IsDrawable)
            {
                return drawable;
            }

            drawable.Path = svgPolyline.Points?.ToPath(svgPolyline.FillRule, false, skOwnerBounds);
            if (drawable.Path is null || drawable.Path.IsEmpty)
            {
                drawable.IsDrawable = false;
                return drawable;
            }

            drawable.IsAntialias = SvgModelExtensions.IsAntialias(svgPolyline);

            drawable.TransformedBounds = drawable.Path.Bounds;

            drawable.Transform = SvgModelExtensions.ToMatrix(svgPolyline.Transforms);

            var canDrawFill = true;
            var canDrawStroke = true;

            if (SvgModelExtensions.IsValidFill(svgPolyline))
            {
                drawable.Fill = SvgModelExtensions.GetFillPaint(svgPolyline, drawable.TransformedBounds, assetLoader, ignoreAttributes);
                if (drawable.Fill is null)
                {
                    canDrawFill = false;
                }
            }

            if (SvgModelExtensions.IsValidStroke(svgPolyline, drawable.TransformedBounds))
            {
                drawable.Stroke = SvgModelExtensions.GetStrokePaint(svgPolyline, drawable.TransformedBounds, assetLoader, ignoreAttributes);
                if (drawable.Stroke is null)
                {
                    canDrawStroke = false;
                }
            }

            if (canDrawFill && !canDrawStroke)
            {
                drawable.IsDrawable = false;
                return drawable;
            }

            SvgModelExtensions.CreateMarkers(svgPolyline, drawable.Path, skOwnerBounds, drawable, assetLoader);

            // TODO: Transform _skBounds using _skMatrix.
            drawable.TransformedBounds = drawable.Transform.MapRect(drawable.TransformedBounds);

            return drawable;
        }
    }
}
