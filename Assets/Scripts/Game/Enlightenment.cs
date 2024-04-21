using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{
	public partial class Enlightenment : ViewController
	{
        private EasyGrid<GridData> gridDatas;
        void Start()
		{
            gridDatas = FindObjectOfType<GridController>().GodTerrain;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            GameObject evolutionEditor = FindObjectOfType<EvolutionEditor>(true).gameObject;
			evolutionEditor.SetActive(true);

			Vector3Int gridPos = new Vector3Int((int)(transform.position.x-0.5) - 1, (int)(transform.position.y-0.5) + 6);
            gridDatas[gridPos.x, gridPos.y].HasEnlightenment = false;

            Debug.Log(gridPos);

            Global.EvolutionCount.Value++;
			
			//Destroy(this.gameObject);
        }
    }
}
