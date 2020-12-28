﻿using Svg.Model.Picture;

namespace Svg.Model
{
    internal interface IPictureSource
    {
        void OnDraw(Canvas canvas, Attributes ignoreAttributes, DrawableBase? until);
        void Draw(Canvas canvas, Attributes ignoreAttributes, DrawableBase? until);
    }
}