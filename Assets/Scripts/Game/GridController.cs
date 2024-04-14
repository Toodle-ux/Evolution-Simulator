using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{
	public enum TerrainStates
	{
		Grass,
		Sand,
		Water
	}
	public partial class GridController : ViewController
	{
		public EasyGrid<GridData> GodTerrain = new EasyGrid<GridData>(10, 12);

		void Start()
		{
			// Code Here
		}
	}
}
