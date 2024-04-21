using UnityEngine;
using QFramework;
using System.Collections.Generic;
using UnityEngine.UI;

namespace EvolutionSimulator
{
	public partial class EvolutionEditor : ViewController
	{
        private List<string> selectedFeatures = new List<string>();
        public Image[] Images = { };
        public Text[] Texts= { };

		void Start()
		{
            selectedFeatures.Add(Constant.EYES_MEDIUM);
            selectedFeatures.Add(Constant.EYES_BIG);
            selectedFeatures.Add(Constant.LEGS_LIMBS);
            selectedFeatures.Add(Constant.LEGS_THIN);

            for (int i = 0; i < 4; i++)
            {
                int pressBtn = i + 1;

                if (selectedFeatures[i].Contains("Legs"))
                {
                    string current_feature_sprite_path = "Features/" + "4" + selectedFeatures[i];
                    Sprite currentFeatureSprite = Resources.Load<Sprite>(current_feature_sprite_path);
                    Images[i].sprite = currentFeatureSprite;
                    Texts[i].text = "Press" + pressBtn + "\n"+"4" + selectedFeatures[i];
                }
                else
                {
                    string current_feature_sprite_path = "Features/" + selectedFeatures[i];
                    Sprite currentFeatureSprite = Resources.Load<Sprite>(current_feature_sprite_path);
                    Images[i].sprite = currentFeatureSprite;
                    Texts[i].text = "Press" + pressBtn + "\n" + selectedFeatures[i];
                }
            }


            

            
            
		}

        private void Update()
        {
            // TODO: Change the creature
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (selectedFeatures[0].Contains("Eyes"))
                {
                    Global.CurrentEyes.Value = selectedFeatures[0];
                } 
                else if (selectedFeatures[0].Contains("Legs"))
                {
                    Global.CurrentLegsType.Value = selectedFeatures[0];
                    Global.CurrentLegsCount.Value = Constant.LEGS_FOUR;
                } 
                else if (selectedFeatures[0].Contains("Head"))
                {
                    Global.CurrentHead.Value = selectedFeatures[0];
                } 
                else if (selectedFeatures[0].Contains("Body"))
                {
                    Global.CurrentBody.Value = selectedFeatures[0];
                }

                gameObject.SetActive(false);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (selectedFeatures[1].Contains("Eyes"))
                {
                    Global.CurrentEyes.Value = selectedFeatures[1];
                }
                else if (selectedFeatures[1].Contains("Legs"))
                {
                    Global.CurrentLegsType.Value = selectedFeatures[1];
                    Global.CurrentLegsCount.Value = Constant.LEGS_FOUR;
                }
                else if (selectedFeatures[1].Contains("Head"))
                {
                    Global.CurrentHead.Value = selectedFeatures[1];
                }
                else if (selectedFeatures[1].Contains("Body"))
                {
                    Global.CurrentBody.Value = selectedFeatures[1];
                }

                gameObject.SetActive(false);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (selectedFeatures[2].Contains("Eyes"))
                {
                    Global.CurrentEyes.Value = selectedFeatures[2];
                }
                else if (selectedFeatures[2].Contains("Legs"))
                {
                    Global.CurrentLegsType.Value = selectedFeatures[2];
                    Global.CurrentLegsCount.Value = Constant.LEGS_FOUR;
                }
                else if (selectedFeatures[2].Contains("Head"))
                {
                    Global.CurrentHead.Value = selectedFeatures[2];
                }
                else if (selectedFeatures[2].Contains("Body"))
                {
                    Global.CurrentBody.Value = selectedFeatures[2];
                }
                gameObject.SetActive(false);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (selectedFeatures[3].Contains("Eyes"))
                {
                    Global.CurrentEyes.Value = selectedFeatures[3];
                }
                else if (selectedFeatures[3].Contains("Legs"))
                {
                    Global.CurrentLegsType.Value = selectedFeatures[3];
                    Global.CurrentLegsCount.Value = Constant.LEGS_FOUR;
                }
                else if (selectedFeatures[3].Contains("Head"))
                {
                    Global.CurrentHead.Value = selectedFeatures[3];
                }
                else if (selectedFeatures[3].Contains("Body"))
                {
                    Global.CurrentBody.Value = selectedFeatures[3];
                }
                gameObject.SetActive(false);
            }
        }
    }
}
