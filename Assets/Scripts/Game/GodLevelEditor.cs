using UnityEngine;
using QFramework;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

namespace EvolutionSimulator
{
	public partial class GodLevelEditor : ViewController
	{
		public Grid grid;

		public Tilemap GodTerrainWater;
		public Tilemap GodTerrainGrass;
		public Tilemap GodTerrainSand;
		public Tilemap GodEnlightenment;

		public Tilemap CreatureTerrainWater;
		public Tilemap CreatureTerrainGrass;
		public Tilemap CreatureTerrainSand;
		public Tilemap CreatureEnlightenment;
		
		public TileBase WaterTile;
		public RuleTile GrassRuleTile;
		public RuleTile SandRuleTile;

		public RuleTile EnlightenmentRuleTile;

		public EasyGrid<GridData> gridDatas;

		public int GodXOffset = -11;
		public int GodYOffset = -6;

		public int CreatureXOffset = 1;
		public int CreatureYOffset = -6;

		public int EnlightenmentCount = 5;
		public GameObject EnlightenmentObj;

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

			});

            DrawTerrain();


			for (int i = 0; i < EnlightenmentCount; i++)
			{

				int x = Random.value > 0.5f ?
					Random.Range(1, 5):
					Random.Range(7,10);
				int y = Random.value > 0.5f ?
                    Random.Range(1, 6) :
                    Random.Range(8, 12);

				Debug.Log((x,y));

				if (gridDatas[x, y] != null)
				{
                    gridDatas[x, y].HasEnlightenment = true;
                }
			}

			InitiateEnlightenment();

			Global.EvolutionCount.Register(onValueChanged =>
			{
				InitiateEnlightenment();
			}).UnRegisterWhenGameObjectDestroyed(this);

        }

        private void Update()
        {
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
			Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);

            Vector3Int gridDataPos = new Vector3Int(cellPosition.x - GodXOffset, cellPosition.y - GodYOffset);
			Vector3Int creatureCellPosition = new Vector3Int(cellPosition.x - GodXOffset + CreatureXOffset, cellPosition.y - GodYOffset + CreatureYOffset);

            // change the terrain based on which tool you're using
            if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (cellPosition.x < -1 && cellPosition.x >= -11 && cellPosition.y < 6 && cellPosition.y >= -6) 
				{
					if (Global.CurrentTool.Value == "Sand")
					{
                        gridDatas[gridDataPos.x, gridDataPos.y].TerrainState = TerrainStates.Sand;
                    } 
					else if (Global.CurrentTool.Value == "Grass")
					{
                        gridDatas[gridDataPos.x, gridDataPos.y].TerrainState = TerrainStates.Grass;
                    } 
					else if (Global.CurrentTool.Value == "Water")
					{
                        gridDatas[gridDataPos.x, gridDataPos.y].TerrainState = TerrainStates.Water;
                    }

					DrawTerrain();
				}
			}
        }

        void DrawTerrain()
        {
            gridDatas.ForEach((x, y, _) =>
            {
				var godTilePos = new Vector3Int(x + GodXOffset, y + GodYOffset);
                var creatureTilePos = new Vector3Int(x + CreatureXOffset, y + CreatureYOffset);

                GodTerrainWater.SetTile(godTilePos, WaterTile);
                CreatureTerrainWater.SetTile(creatureTilePos, WaterTile);

                if (gridDatas[x, y].TerrainState == TerrainStates.Grass || gridDatas[x, y].TerrainState == TerrainStates.Sand)
				{
					GodTerrainGrass.SetTile(godTilePos, GrassRuleTile);
					CreatureTerrainGrass.SetTile(creatureTilePos, GrassRuleTile);
				} 
				else
				{
                    GodTerrainGrass.SetTile(godTilePos, null);
                    CreatureTerrainGrass.SetTile(creatureTilePos, null);
                }

				if (gridDatas[x, y].TerrainState == TerrainStates.Sand)
				{
					GodTerrainSand.SetTile(godTilePos, SandRuleTile);
					CreatureTerrainSand.SetTile(creatureTilePos, SandRuleTile);
				}
				else
				{
                    GodTerrainSand.SetTile(godTilePos, null);
                    CreatureTerrainSand.SetTile(creatureTilePos, null);
                }
            });
        }

        private void InitiateEnlightenment()
        {
            gridDatas.ForEach((x, y, _) =>
            {

                Vector3Int godPos = new Vector3Int(x + GodXOffset, y + GodYOffset);
                Vector3Int creaturePos = new Vector3Int(x + CreatureXOffset, y + CreatureYOffset);

                if (gridDatas[x,y].HasEnlightenment)
				{

                    

					GodEnlightenment.SetTile(godPos, EnlightenmentRuleTile);
					CreatureEnlightenment.SetTile(creaturePos, EnlightenmentRuleTile);

                    //Instantiate(EnlightenmentObj, godPos, Quaternion.identity);
                    //Instantiate(EnlightenmentObj, creaturePos, Quaternion.identity);
                }
				else
				{
                    GodEnlightenment.SetTile(godPos, null);
                    CreatureEnlightenment.SetTile(creaturePos, null);
                }

            });

			Debug.Log("Initiated");
        }
    }
}
