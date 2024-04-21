using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{
	public partial class Enlightenment : ViewController
	{
		void Start()
		{
            //evolutionEditor = GameObject.Find("EvolutionEditor");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            GameObject evolutionEditor = FindObjectOfType<EvolutionEditor>(true).gameObject;
			evolutionEditor.SetActive(true);

			//EvolutionEditor.SetActive(true);
			
			Destroy(this.gameObject);
        }
    }
}
