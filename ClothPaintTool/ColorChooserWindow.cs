using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace ClothesPaintTool
{


    class ColorChooserWindow : Window
    {
        public static Color? FromHex(string hex)
        {
            if (hex.StartsWith("#"))
            {
                hex = hex.Substring(1);
            }
            if (hex.Length != 6 && hex.Length != 8)
            {
                return null;
            }
            int r = int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            int g = int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            int b = int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
            int a = 255;
            if (hex.Length == 8)
            {
                a = int.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
            }
            return GenColor.FromBytes(r, g, b, a);
        }
        public static string ColorFloatToString(float f)
        {
           return ((int)(f * 255f)).ToString("X2");
        }
        public static string ToHex(Color color)
        {
            string res = "#";
            res += ColorFloatToString(color.r);
            res += ColorFloatToString(color.g);
            res += ColorFloatToString(color.b);
            string aVal = ColorFloatToString(color.a);
            if (!aVal.Equals("FF"))
                res += aVal;
            return res;
        }
        private Color color;
        private string text;
        public ColorChooserWindow()
        {
            this.color = ClothesPaintToolMod.color;
            this.text = ToHex(color);
        }
        public override void DoWindowContents(Rect inRect)
        {
           
            text = Widgets.TextArea(new Rect(0, 0, 100, 20), text);
            try
            {
                var color = FromHex(text);
                if (color.HasValue)
                    this.color = color.Value;
            }
            catch (Exception)
            {

            }

            Widgets.DrawBoxSolid(new Rect(120, 2, 10, 10), color);
        }
        public override void PreClose()
        {
            base.PreClose();
            ClothesPaintToolMod.color = this.color;
        }
    }
}
