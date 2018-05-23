using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyEnemy : MonoBehaviour
{

[SerializeField] private int HP = 2;

	public void Hurt(int Damage)
		{
			HP --;
			if (HP <= 0)
				Death();
		}

	public void Death ()
		{
			Destroy(gameObject);
		}
}