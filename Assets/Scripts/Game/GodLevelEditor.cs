using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

namespace EvolutionSimulator
{
	public partial class GodLevelEditor : ViewController
	{
		public Tilemap GodTerrain;
		public Tilemap CreatureTerrain;
		
		public TileBase GrassTile;
		
		void Start()
		{
			var gridDatas = FindObjectOfType<GridController>().GodTerrain;
			
			gridDatas.ForEach((x, y, _) =>
			{
				var godTilePos = new Vector3Int(x - 11, y - 6);
				GodTerrain.SetTile(godTilePos, GrassTile);

				var creatureTilePos = new Vector3Int(x + 1, y - 6);
				CreatureTerrain.SetTile(creatureTilePos, GrassTile);
			});
		}
	}
}
