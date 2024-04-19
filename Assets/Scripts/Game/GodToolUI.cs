using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{
	public partial class GodToolUI : ViewController
	{
		void Start()
		{
			BtnTerrain.onClick.AddListener(() =>
			{
				TerrainToolBar.gameObject.SetActive(true);
			});

			BtnExit1.onClick.AddListener(() =>
			{
				TerrainToolBar.gameObject.SetActive(false);
			});

			BtnGrass.onClick.AddListener(() =>
			{
				ChangeTool(Constant.TERRAIN_GRASS);
			});

            BtnSand.onClick.AddListener(() =>
            {
                ChangeTool(Constant.TERRAIN_SAND);
            });

            BtnWater.onClick.AddListener(() =>
            {
                ChangeTool(Constant.TERRAIN_WATER);
            });
        }

        void ChangeTool(string tool)
        {
			Global.CurrentTool.Value = tool;
        }
    }
}
