using HugsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Verse;

namespace ClothesPaintTool
{

    public class ClothesPaintToolMod : ModBase
    {
        public static Color color = Color.white;
        public override string ModIdentifier
        {
            get
            {
                return "ClothPaintTool";
            }
        }
        public override void WorldLoaded()
        {
            var resolvedDesignatorsField = typeof(DesignationCategoryDef).GetField("resolvedDesignators", BindingFlags.NonPublic | BindingFlags.Instance);
            var resolvedDesignators = (List<Designator>)resolvedDesignatorsField.GetValue(DefDatabase<DesignationCategoryDef>.GetNamed("Orders"));
            Designator designator = new ClothesPaintDesignator();
            designator.defaultLabel = "Color Items";
            designator.defaultDesc = "Color selected items in the color you like, if can be colored.";
            resolvedDesignators.Add(designator);
            designator = new ColorChooserDesignator();
            designator.defaultLabel = "Choose Color";
            designator.defaultDesc = "Choose your color.";
            resolvedDesignators.Add(designator);
        }
    }
}

