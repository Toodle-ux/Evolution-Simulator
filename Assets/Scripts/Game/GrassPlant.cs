using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{

	public partial class GrassPlant : ViewController
	{
        private EasyGrid<GridData> gridDatas;

        void Start()
		{
            gridDatas = FindObjectOfType<GridController>().GodTerrain;
            InvokeRepeating("SpawnFood", Random.Range(5f,10f), Random.Range(15f,25f));
        }

        void SpawnFood()
        {
            Vector3Int gridPos = new Vector3Int((int)(transform.position.x - 0.5) + 11, (int)(transform.position.y - 0.5) + 6);
            Vector3Int foodPos = new Vector3Int(gridPos.x + Random.Range(-1, 1), gridPos.y + Random.Range(-1, 1));
            Debug.Log(foodPos);

            if (gridDatas[foodPos.x, foodPos.y] != null)
            {
                gridDatas[foodPos.x,foodPos.y].HasFood = true;
                Global.FoodCount.Value++;
            }

        }
	}
}
