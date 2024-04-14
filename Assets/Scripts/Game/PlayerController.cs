using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{
	public partial class PlayerController : ViewController
	{
		private float speed = 1.0f;
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
