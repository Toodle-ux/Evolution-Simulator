using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;

namespace EvolutionSimulator
{
	public partial class PlayerController : ViewController
	{
        public Grid grid;

        public Sprite RoundBody;
        
        private float healthMax = 100;
        private float currentHealth = 100;

        private float hungerMax = 100;
        private float currentHunger = 100;
        private float deltaHunger = 1;

        
        private float speed = 5.0f;
        private float baseSpeed = 5.0f;
        private float speedTerrainMod = 1;

        private void OnGUI()
        {
            IMGUIHelper.SetDesignResolution(640, 360);
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Space(320);
            GUILayout.Label("Hunger:" + currentHunger + "/" + hungerMax);
            GUILayout.EndHorizontal();
        }

        private void Start()
        {
            UpdateFeature();
            
            Global.CurrentHead.Register(onValueChanged =>
            {

            }).UnRegisterWhenGameObjectDestroyed(this);
        }

        private void Update()
        {
            // TODO: Change the creature
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                
            }

            // calculate the speed
            Vector3Int cellPosition = grid.WorldToCell(transform.position);
            Vector3Int gridDataPos = new Vector3Int(cellPosition.x - 1, cellPosition.y + 6);

            var gridDatas = FindObjectOfType<GridController>().GodTerrain;

            if (gridDatas[gridDataPos.x, gridDataPos.y].TerrainState == TerrainStates.Sand)
            {
                speedTerrainMod = 0.1f;
            }
            else
            {
                speedTerrainMod= 1;
            }

            speed = baseSpeed * speedTerrainMod;

            // move the creature
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 verticalDir = new Vector3(0f, verticalInput, 0f);
            Vector3 horizontalDir = new Vector3(horizontalInput, 0f, 0f);

            if (horizontalInput > 0f)
            {
                if (transform.position.x < 10.5f)
                {
                    transform.Translate(horizontalDir * speed * Time.deltaTime);
                }
            }
            else
            {
                if (transform.position.x > 1.5f)
                {
                    transform.Translate(horizontalDir * speed * Time.deltaTime);
                }
            }

            if (verticalInput > 0f)
            {
                if (transform.position.y < 5.5f)
                {
                    transform.Translate(verticalDir* speed * Time.deltaTime);
                }
            }
            else
            {
                if (transform.position.y > -5.5f)
                {
                    transform.Translate(verticalDir * speed * Time.deltaTime);
                }
            }



            // Hunger calculation
            currentHunger = currentHunger - deltaHunger * Time.deltaTime;

            // End game
            if (currentHunger< 0f)
            {
                SceneManager.LoadScene("GodWins");
            }
        }

        void UpdateFeature()
        {
            switch (Global.CurrentHead.Value)
            {
                case Constant.FEATURE_NULL: 
                    Head.sprite = null;
                    break;
            }

            switch (Global.CurrentEyes.Value)
            {
                case Constant.FEATURE_NULL:
                    Eyes.sprite = null;
                    break;
            }

            switch (Global.CurrentLegs.Value)
            {
                case Constant.FEATURE_NULL:
                    Legs.sprite = null;
                    break;
            }

            switch (Global.CurrentBody.Value)
            {
                case Constant.FEATURE_NULL:
                    Body.sprite = null;
                    break;
                case Constant.BODY_ROUND:
                    Body.sprite = RoundBody;
                    break;
            }
        }
    }
}
