using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int HP = 2;
    [SerializeField] private int Health, AttackDamage;
    [SerializeField] private float MaxDistance, ReloadTime, Speed, Fireball_Speed;
    [SerializeField] private GameObject Target;

    [SerializeField] private Rigidbody2D Fireball;			//bullet object
    [SerializeField] private GameObject Bazooka;

    public bool Angry = false;
    bool IsForward = true, Cooldown = false;
    private Vector3 StartPos;
    Vector3 Dir = new Vector3(1, 0);
    [SerializeField] private LayerMask mask = 1 << 9;

    private void Start()
    {
        StartPos = transform.position;
    }

    void FixedUpdate()
    {

        RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right, 2, mask);
        RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector2.left, 2, mask);
        Debug.DrawRay(transform.position, Vector2.right * 2, Color.red);
        Debug.DrawRay(transform.position, Vector2.left * 2, Color.red);

        if (hit_right )
        {

            Debug.Log("Ой, справа");
            Target = hit_right.collider.gameObject;
            Angry = true;
            Engage(true, false);
        }
        else if (hit_left)
        {
            Debug.Log("Ой, слева");

            Target = hit_left.collider.gameObject;
            Angry = true;
            Engage(false, true);
        }
    }


    public void Hurt(int Damage)
		{
			HP --;
			if (HP <= 0)
				Death();
		}

	public void Death ()
	{
        Angry = false;
		Destroy(gameObject);
	}



    void Engage(bool right, bool left)
    {

        SetEnemyFacingDirection();


        if (right)
        {
            transform.position += Dir * Speed * Time.deltaTime;
        }
        else if (left)
        {
            transform.position -= -Dir * Speed * Time.deltaTime;
        }

        if (Vector2.Distance(transform.position, StartPos) > 2)
            BackToSpawn();

        if ((Vector2.Distance(transform.position, Target.transform.position) <= 1) && !Cooldown)
        {
            if (IsForward)
                Shoot(true);
            else Shoot(false);
            Cooldown = true;
            Invoke("Reload", ReloadTime);
        }
    }

    void SetEnemyFacingDirection()
    {
        float x = Target.transform.position.x - transform.position.x;

        if (x < 1 && IsForward)
            Flip();
        else if (x > 1 && !IsForward)
            Flip();
    }

    private void BackToSpawn()
    {
        Debug.Log("Идем домой");
        if (transform.position.x != StartPos.x)
        {
            Dir.x = (StartPos.x - transform.position.x);
            transform.Translate(Dir * Time.deltaTime * Speed);
        }
    }

    void Reload()
    {
        Cooldown = false;
    }

    void Shoot(bool right)
    {
        if (!right)
        {
            Rigidbody2D RB_fireball = Instantiate(Fireball, Bazooka.transform.position, Quaternion.Euler(new Vector3(0, 0, 180))) as Rigidbody2D;
            RB_fireball.velocity = new Vector2(-Fireball_Speed, 0);
        }

        if (right)
        {
            Rigidbody2D RB_fireball = Instantiate(Fireball, Bazooka.transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            RB_fireball.velocity = new Vector2(Fireball_Speed, 0);
        }
    }

    void Flip()
    {
        IsForward = !IsForward;
        Dir.x *= -1;
        Vector3 V = transform.localScale;
        V.x *= -1;
        transform.localScale = V;
    }
}