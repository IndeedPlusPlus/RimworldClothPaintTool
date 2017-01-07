using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using HugsLib;

namespace ClothesPaintTool
{
    class ClothesPaintDesignator : Designator
    {
        public override int DraggableDimensions
        {
            get { return 2; }
        }

        public override bool DragDrawMeasurements
        {
            get { return true; }
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 loc)
        {
            return true;
        }
        public override void DesignateSingleCell(IntVec3 loc)
        {
            var things = Find.VisibleMap.thingGrid.ThingsListAtFast(loc);
            foreach (var thing in things)
            {
                CompColorable compColorable = thing.TryGetComp<CompColorable>();
                if (compColorable != null)
                {
                    thing.SetColor(ClothesPaintToolMod.color);
                }
            }
        }
        public override bool Visible
        {
            get { return true; }
        }
    }
}
