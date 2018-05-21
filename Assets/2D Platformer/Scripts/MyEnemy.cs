using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyEnemy : MonoBehaviour
{
	public void Hurt(int Damage)
		{
			print("Ouch: " + Damage);
		}
}