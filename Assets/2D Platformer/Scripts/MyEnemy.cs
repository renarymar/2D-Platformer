using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyEnemy : MonoBehaviour
{

public int HP = 2;

	public void Hurt(int Damage)
		{
			HP --;
			if (HP <= 0)
				Death();
			print("Ouch: " + Damage);
			print("HP: " + HP);
		}

	public void Death ()
		{
			Destroy(gameObject);
		}
}