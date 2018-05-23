using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayBomb : MonoBehaviour {

[SerializeField] private GameObject BOOM; //prefab of the explosion
[SerializeField] private float bombForce = 100f;			// Force that enemies are thrown from the blast.
[SerializeField] private AudioClip boom;					// Audioclip of explosion.
[SerializeField] private GameObject explosion;			// Prefab of explosion effect.




	void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "Enemy") //if bomb colides with an object that tagged as Enemy
				{
					MyEnemy Enemy = collision.gameObject.GetComponent<MyEnemy>();
					if(Enemy != null) // if the link is valid
						{
				 			Enemy.Death(); //initiate the enemy's death
							Instantiate(BOOM, transform.position, transform.rotation); //show the explosion

							// Find a vector from the bomb to the enemy.
							Rigidbody2D rb = Enemy.GetComponent<Rigidbody2D>();
							Vector3 deltaPos = rb.transform.position - transform.position;

							// Apply a force in this direction with a magnitude of bombForce.
							Vector3 force = deltaPos.normalized * bombForce;
							rb.AddForce(force);

				// Instantiate the explosion prefab.
		Instantiate(explosion,transform.position, Quaternion.identity);

		// Play the explosion sound effect.
		AudioSource.PlayClipAtPoint(boom, transform.position);	

							Destroy(gameObject); //destroy the bomb
						}
				}
		}

	


}
