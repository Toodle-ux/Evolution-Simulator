using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionSimulator
{
    public class Global
    {
        public static BindableProperty<string> CurrentTool = new BindableProperty<string>(Constant.TOOL_NULL);

        public static BindableProperty<string> CurrentHead = new BindableProperty<string>(Constant.FEATURE_NULL);
        public static BindableProperty<string> CurrentEyes = new BindableProperty<string>(Constant.FEATURE_NULL);
        public static BindableProperty<string> CurrentBody = new BindableProperty<string>(Constant.BODY_ROUND);
        public static BindableProperty<string> CurrentLegs = new BindableProperty<string>(Constant.FEATURE_NULL);
    }

    public class Constant
    {
        public const string TOOL_NULL = "Null";
        public const string TERRAIN_GRASS = "Grass";
        public const string TERRAIN_SAND = "Sand";
        public const string TERRAIN_WATER = "Water";

        public const string FEATURE_NULL = "Null";
        public const string HEAD_ROUND = "RoundHead";
        public const string EYES_SMALL = "SmallEyes";
        public const string BODY_ROUND = "RoundBody";
        public const string LEGS_FOUR = "FourLegs";
        public const string LEGS_LIMBS = "LimbsLegs";
    }
}

