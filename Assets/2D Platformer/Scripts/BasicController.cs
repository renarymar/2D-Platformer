using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour {

public float Acceleration;				//character's speed
public GameObject Bullet;			//bullet object
public GameObject StartBullet;	//start coordinates for a bullet

private	Vector3 Dir = new Vector3(0,0,0);					//character's moving direction

	
// Update is called once per frame
void FixedUpdate () 
{
		transform.rotation = Quaternion.identity;

		Dir.x = Input.GetAxis("Horizontal");							//check the controll sets
		if (Dir.x != 0)													//if the direction is not 0
			transform.position += Dir * Acceleration * Time.fixedDeltaTime;	// in that case we move the character based on the current direction vector and speed every fixed frame 

	
		if (Input.GetButtonDown("Fire1"))
		Instantiate(Bullet, StartBullet.transform.position, transform.rotation);
		 
	}	
}
