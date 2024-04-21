using UnityEngine;
using QFramework;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Unity.VisualScripting;

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

        private float speedSandMod = 0.2f;
        private float speedGrassMod = 1;
        private float speedWaterMod = 0.5f;

        private float mass = 1f;
        private float limbStrength = 1;


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
                UpdateFeature();
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.CurrentEyes.Register(onValueChanged =>
            {
                UpdateFeature();
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.CurrentBody.Register(onValueChanged =>
            {
                UpdateFeature();
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.CurrentLegsType.Register(onValueChanged =>
            {
                UpdateFeature();
            }).UnRegisterWhenGameObjectDestroyed(this);

            Global.CurrentLegsCount.Register(onValueChanged =>
            {
                UpdateFeature();
            }).UnRegisterWhenGameObjectDestroyed(this);
        }

        private void Update()
        {
            

            // calculate the speed
            Vector3Int cellPosition = grid.WorldToCell(transform.position);
            Vector3Int gridDataPos = new Vector3Int(cellPosition.x - 1, cellPosition.y + 6);

            var gridDatas = FindObjectOfType<GridController>().GodTerrain;
            speed = CalculateSpeed(gridDatas[gridDataPos.x, gridDataPos.y]);

            Move();

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
            speedSandMod = 0.2f;
            speedGrassMod = 1;
            speedWaterMod = 0.5f;

            mass = 1;
            limbStrength = 1;
            float deltaLimbStrength = 0;
            
            switch (Global.CurrentHead.Value)
            {
                case Constant.FEATURE_NULL: 
                    Head.sprite = null;
                    break;
            }

            string current_head_sprite_path = "Features/" + Global.CurrentHead.Value;
            Sprite currentHeadSprite = Resources.Load<Sprite>(current_head_sprite_path);
            if (currentHeadSprite != null)
            {
                Head.sprite = currentHeadSprite;
            }
            else
            {
                Head.sprite = null;
            }

            switch (Global.CurrentEyes.Value)
            {
                case Constant.FEATURE_NULL:
                    Eyes.sprite = null;
                    break;
            }

            string current_eyes_sprite_path = "Features/" + Global.CurrentEyes.Value;
            Sprite currentEyesSprite = Resources.Load<Sprite>(current_eyes_sprite_path);
            if (currentEyesSprite != null)
            {
                Eyes.sprite = currentEyesSprite;
            }
            else
            {
                Eyes.sprite = null;
            }

            switch (Global.CurrentLegsType.Value)
            {
                case Constant.FEATURE_NULL:
                    break;
                case Constant.LEGS_LIMBS:
                    deltaLimbStrength = 0.25f;
                    break;
            }

            limbStrength += deltaLimbStrength * Global.CurrentLegsCount.Value;

            string current_legs_sprite_path = "Features/" + Global.CurrentLegsCount.Value + Global.CurrentLegsType;
            Sprite currentLegsSprite = Resources.Load<Sprite>(current_legs_sprite_path);
            if (currentLegsSprite != null)
            {
                Legs.sprite = currentLegsSprite;
            }
            else
            {
                Legs.sprite = null;
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

            string current_body_sprite_path = "Features/" + Global.CurrentBody.Value;
            Sprite currentBodySprite = Resources.Load<Sprite>(current_body_sprite_path);
            if (currentBodySprite != null)
            {
                Body.sprite = currentBodySprite;
            }
            else
            {
                Body.sprite = null;
            }
        }

        float CalculateSpeed(GridData gridData)
        {
            float tempSpeed = limbStrength / mass;
            
            switch (gridData.TerrainState)
            {
                case TerrainStates.Water:
                    tempSpeed *= speedWaterMod;
                    break;
                case TerrainStates.Grass: 
                    tempSpeed *= speedGrassMod;
                    break;
                case TerrainStates.Sand: 
                    tempSpeed *= speedSandMod;
                    break;
            }
            
            return tempSpeed;
        }

        private void Move()
        {
            // move the creature
            float horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            float verticalInput = UnityEngine.Input.GetAxis("Vertical");

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
                    transform.Translate(verticalDir * speed * Time.deltaTime);
                }
            }
            else
            {
                if (transform.position.y > -5.5f)
                {
                    transform.Translate(verticalDir * speed * Time.deltaTime);
                }
            }
        }
    }
}
