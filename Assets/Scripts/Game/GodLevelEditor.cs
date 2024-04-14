using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

namespace EvolutionSimulator
{
	public partial class GodLevelEditor : ViewController
	{
		public Grid grid;
		
		public Tilemap GodTerrain;
		public Tilemap CreatureTerrain;
		
		public TileBase GrassTile;
		public TileBase SandTile;

		public EasyGrid<GridData> gridDatas;

		public int GodXOffset = -11;
		public int GodYOffset = -6;

		public int CreatureXOffset = 1;
		public int CreatureYOffset = -6;

        public void Awake()
        {
            gridDatas = FindObjectOfType<GridController>().GodTerrain;
        }

        void Start()
		{
			
			// initate the grid data and the tilemaps
			gridDatas.ForEach((x, y, _) =>
			{
				gridDatas[x, y] = new GridData();
				
				var godTilePos = new Vector3Int(x + GodXOffset, y + GodYOffset);
				GodTerrain.SetTile(godTilePos, GrassTile);

				var creatureTilePos = new Vector3Int(x + CreatureXOffset, y + CreatureYOffset);
				CreatureTerrain.SetTile(creatureTilePos, GrassTile);
			});
		}

        private void Update()
        {
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
			Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);

            Vector3Int gridDataPos = new Vector3Int(cellPosition.x - GodXOffset, cellPosition.y - GodYOffset);
			Vector3Int creatureCellPosition = new Vector3Int(cellPosition.x - GodXOffset + CreatureXOffset, cellPosition.y - GodYOffset + CreatureYOffset);

			// change the terrain to sand
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (cellPosition.x < -1 && cellPosition.x >= -11 && cellPosition.y < 6 && cellPosition.y >= -6) 
				{
					GodTerrain.SetTile(cellPosition, SandTile);
					gridDatas[gridDataPos.x, gridDataPos.y].TerrainState = TerrainStates.Sand;

					CreatureTerrain.SetTile(creatureCellPosition, SandTile);
				}
			}
        }
    }
}
