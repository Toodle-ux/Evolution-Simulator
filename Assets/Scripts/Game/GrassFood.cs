using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{
	public partial class GrassFood : ViewController
	{
		private PlayerController playerController;

		private EasyGrid<GridData> gridDatas;

		void Start()
		{
			playerController = FindObjectOfType<PlayerController>();

			gridDatas = FindObjectOfType<GridController>().GodTerrain;
		}

        private void OnTriggerEnter2D(Collider2D collision)
        {
			playerController.currentHunger = Mathf.Min(playerController.currentHunger + 5f, playerController.hungerMax);

            Vector3Int gridPos = new Vector3Int((int)(transform.position.x - 0.5) - 1, (int)(transform.position.y - 0.5) + 6);
            gridDatas[gridPos.x, gridPos.y].HasFood = false;

			Global.FoodCount.Value++;
        }
    }
}
