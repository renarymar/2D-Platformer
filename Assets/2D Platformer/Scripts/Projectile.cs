using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

public GameObject BOOM;
public int Damage;
public float Speed, LifeTime;

Vector3 Dir = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () 
	{
		Dir.x = Speed;
		Destroy(gameObject,LifeTime);
	}


	void FixedUpdate () 
	{
		transform.position += Dir;
	}

	void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "Enemy")
				{
					MyEnemy Enemy = collision.gameObject.GetComponent<MyEnemy>();
					if(Enemy != null) // Если ссылка не пуста
						{
							//Enemy.Hurt(Damage); // Вызываем метод урона и указываем его размер
							Instantiate(BOOM, transform.position, transform.rotation);
							Destroy(gameObject);
						}
				}
		}
}
