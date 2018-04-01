using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float jumpDistance;
    public GameObject wing;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private SpriteRenderer srGoose;
    private SpriteRenderer srWing;
    private Animator animGoose;
    private Animator animWing;


    void Start ()
    {
        rb  = GetComponent<Rigidbody2D>();
        srGoose = GetComponent<SpriteRenderer>();
        animGoose = GetComponent<Animator>();
        animWing = wing.GetComponent<Animator>();
        srWing = wing.GetComponent<SpriteRenderer>();
	}
	
	
	void Update ()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            MovePlayerHorizontally();
        }
        else
        {
            animGoose.SetBool("isWalking", false);
        }
            
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
    }

    private void MovePlayerHorizontally()
    {
        animGoose.SetBool("isWalking", true);
        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        if(facingRight == true && horizontalMovement < 0)
        {
            TurnLeft();
        }
        else if(facingRight == false && horizontalMovement > 0)
        {
            TurnRight();
        }
        rb.transform.Translate(horizontalMovement, 0, 0);
        rb.transform.rotation = Quaternion.identity;
    }

    private void Jump()
    {
        animWing.SetTrigger("triggerIsFlapping");
        rb.transform.Translate(0, jumpDistance, 0);
    }

    private void TurnLeft()
    {
        facingRight = false;
        srGoose.flipX = true;
        srWing.flipX = true;
        Vector3 wingPos = new Vector3(0.8f, -1.7f, 0f);
        wing.transform.localPosition = wingPos;
        
        
    }

    private void TurnRight()
    {
        facingRight = true;
        srGoose.flipX = false;
        srWing.flipX = false;
        wing.transform.localPosition = new Vector3(-0.9f, -1.7f, 0f);
    }
}
