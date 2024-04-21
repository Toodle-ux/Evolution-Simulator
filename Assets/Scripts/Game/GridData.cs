using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EvolutionSimulator
{
    public class GridData
    {
        public TerrainStates TerrainState { get; set; } = TerrainStates.Water;

        public bool HasEnlightenment { get; set; } = false;

        public bool HasPlant { get; set; } = false;

        public bool HasFood { get; set; } = false;
    }
}

