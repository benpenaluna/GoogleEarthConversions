﻿using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class LineStyle : ColorStyle, ILineStyle
    {
        public IDoubleKML Width { get; set; }
        public IColor OuterColor { get; set; }
        public IDoubleKML OuterWidth { get; set; }
        public IDoubleKML PhysicalWidth { get; set; }
        public IBooleanKML LabelVisibility { get; set; }

        public LineStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Color = new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(255,255,255,255), DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255, 255) };
            ColorMode = new ColorMode(ColorModeEnum.Normal);

            Width = new DoubleKML(nameof(Width).ConvertFirstCharacterToLowerCase()) { Value = 1.0, Default = 0.0 };
            OuterColor = new Color("gx:" + nameof(OuterColor).ConvertFirstCharacterToLowerCase()) { Value = System.Drawing.Color.White, DefaultColor = System.Drawing.Color.White };
            OuterWidth = new DoubleKML("gx:" + nameof(OuterWidth).ConvertFirstCharacterToLowerCase()) { Value = 0.0, Default = 0.0 };
            PhysicalWidth = new DoubleKML("gx:" + nameof(PhysicalWidth).ConvertFirstCharacterToLowerCase()) { Value = 0.0, Default = 0.0 };
            LabelVisibility = new BooleanKML("gx:" + nameof(LabelVisibility).ConvertFirstCharacterToLowerCase()) { Value = false, Default = false };
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LineStyle) && Equals((LineStyle)obj);
        }

        protected bool Equals(LineStyle other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Color, other.Color) &&
                   Equals(ColorMode, other.ColorMode) &&
                   Equals(Width, other.Width) &&
                   Equals(OuterColor, other.OuterColor) &&
                   Equals(OuterWidth, other.OuterWidth) &&
                   Equals(PhysicalWidth, other.PhysicalWidth) &&
                   Equals(LabelVisibility, other.LabelVisibility);
        }

        public static bool operator ==(LineStyle a, LineStyle b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LineStyle a, LineStyle b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(Color.ConvertObjectToKML());
            sw.Write(ColorMode.ConvertObjectToKML());
            sw.Write(Width.ConvertObjectToKML());
            sw.Write(OuterColor.ConvertObjectToKML());
            sw.Write(OuterWidth.ConvertObjectToKML());
            sw.Write(PhysicalWidth.ConvertObjectToKML());
            sw.Write(LabelVisibility.ConvertObjectToKML());
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
