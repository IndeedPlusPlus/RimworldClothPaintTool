using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace ClothesPaintTool
{
    class ColorChooserDesignator : Designator
    {
        public override void ProcessInput(Event ev)
        { 
            var window = new ColorChooserWindow();
            Find.WindowStack.Add(window);

        }
        public override AcceptanceReport CanDesignateCell(IntVec3 loc)
        {
            return false;
        }
    }
}
