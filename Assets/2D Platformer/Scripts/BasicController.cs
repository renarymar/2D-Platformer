using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour {

    [SerializeField] private float Acceleration;				//character's speed
    //[SerializeField] private GameObject Bullet;			//bullet object
    //[SerializeField] private GameObject Bazooka;
    [SerializeField] private GameObject Bomb;
    [SerializeField] private GameObject StartBomb;
    
    [SerializeField] private float jumpForce;


    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;			// Whether or not the player is grounded.

    Rigidbody2D RB;
    bool jump = false;
    bool moving = false;

    [HideInInspector] public bool facingRight = true;			// For determining which way the player is currently facing.

    private	Vector3 Dir = new Vector3(0,0,0);					//character's moving direction

    void Start()
    {
	    RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        Dir.x = Input.GetAxis("Horizontal");
        if (Dir.x != 0)
            moving = true;

        if (Dir.x < 0)
        {
            if (facingRight)
                Flip();
        }

        else if (Dir.x > 0)
        {
            if (!facingRight)
                Flip();
        }

        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetButtonDown("Fire2"))
            Instantiate(Bomb, StartBomb.transform.position, transform.rotation); //then create a bomb

/*
        if (Input.GetButtonDown("Fire1") && facingRight)
            Instantiate(Bullet, Bazooka.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        else if (Input.GetButtonDown("Fire1") && !facingRight)
            Instantiate(Bullet, Bazooka.transform.position, Quaternion.Euler(new Vector3(0, 0, 180f)));

*/
    }

    // Update is called once per frame
    void FixedUpdate () 
	{
        if (moving)
        {
            moving = false;
            if (facingRight)
                RB.velocity = Vector2.right * Acceleration;
            else if(!facingRight)
                RB.velocity = Vector2.left * Acceleration;
        }

        if (jump)
        {
            jump = false;
            RB.AddForce(Vector3.up * jumpForce);
        }

    }

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
