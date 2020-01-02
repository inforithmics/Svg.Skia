﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//
// Parts of this source file are adapted from the https://github.com/vvvv/SVG
using System;
using System.Collections.Generic;
using SkiaSharp;

namespace Svg.Skia
{
    internal class PolylineDrawable : PathBaseDrawable
    {
        public PolylineDrawable(SvgPolyline svgPolyline, SKSize sKSize, bool ignoreDisplay)
        {
            _ignoreDisplay = ignoreDisplay;
            _canDraw = CanDraw(svgPolyline, _ignoreDisplay);

            if (!_canDraw)
            {
                return;
            }

            skPath = SkiaUtil.ToSKPath(svgPolyline.Points, svgPolyline.FillRule, false, _disposable);
            if (skPath == null || skPath.IsEmpty)
            {
                _canDraw = false;
                return;
            }

            _antialias = SkiaUtil.IsAntialias(svgPolyline);

            _skBounds = skPath.Bounds;

            _skMatrix = SkiaUtil.GetSKMatrix(svgPolyline.Transforms);
            _skPathClip = SkiaUtil.GetSvgVisualElementClipPath(svgPolyline, _skBounds, new HashSet<Uri>(), _disposable);
            _skPaintOpacity = SkiaUtil.GetOpacitySKPaint(svgPolyline, _disposable);
            _skPaintFilter = SkiaUtil.GetFilterSKPaint(svgPolyline, _disposable);

            if (SkiaUtil.IsValidFill(svgPolyline))
            {
                _skPaintFill = SkiaUtil.GetFillSKPaint(svgPolyline, sKSize, _skBounds, _disposable);
            }

            if (SkiaUtil.IsValidStroke(svgPolyline))
            {
                _skPaintStroke = SkiaUtil.GetStrokeSKPaint(svgPolyline, sKSize, _skBounds, _disposable);
            }
        }
    }
}
