using UnityEngine;
using QFramework;

namespace EvolutionSimulator
{
	public partial class PlayerController : ViewController
	{
		private float speed = 5.0f;
        private void Update()
        {
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
        }
    }
}
