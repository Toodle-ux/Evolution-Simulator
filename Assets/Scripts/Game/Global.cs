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
        public static BindableProperty<string> CurrentEyes = new BindableProperty<string>(Constant.EYES_SMALL);
        public static BindableProperty<string> CurrentBody = new BindableProperty<string>(Constant.BODY_ROUND);
        public static BindableProperty<string> CurrentLegsType = new BindableProperty<string>(Constant.FEATURE_NULL);
        public static BindableProperty<int> CurrentLegsCount = new BindableProperty<int>(0);

        public static List<string> SelectableFeatures = new List<string>();

        public static BindableProperty<int> EvolutionCount = new BindableProperty<int>(0);
        public static BindableProperty<int> FoodCount = new BindableProperty<int>(0);
        public static BindableProperty<int> TreeCount = new BindableProperty<int>(0);
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
        public const string EYES_MEDIUM = "MediumEyes";
        public const string EYES_BIG = "BigEyes";

        public const string BODY_ROUND = "RoundBody";
        
        public const int LEGS_FOUR = 4;
        public const string LEGS_LIMBS = "LimbsLegs";
        public const string LEGS_THIN = "ThinLegs";
    }
}

