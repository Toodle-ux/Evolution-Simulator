using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionSimulator
{
    public class Global
    {
        public static BindableProperty<string> CurrentTool = new BindableProperty<string>(Constant.TERRAIN_GRASS);
    }

    public class Constant
    {
        public const string TERRAIN_GRASS = "Grass";
        public const string TERRAIN_SAND = "Sand";
        public const string TERRAIN_WATER = "Water";
    }
}

