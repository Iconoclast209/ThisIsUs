using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float playerSpeed;
    public float jumpDistance;
    public GameObject wing;
    public Text speechTextBox;
    public Image gooseImage;
    public Image animalImage;
    public Sprite[] animalSpriteArray;
    public string[] interactionStringArray;
    public bool playerInputEnabled = true;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private SpriteRenderer srGoose;
    private SpriteRenderer srWing;
    private Animator animGoose;
    private Animator animWing;
    private bool ableToInteractWithSheep = true, ableToInteractWithCow = true, ableToInteractWithChicken = true;

    void Start ()
    {
        rb  = GetComponent<Rigidbody2D>();
        srGoose = GetComponent<SpriteRenderer>();
        animGoose = GetComponent<Animator>();
        animWing = wing.GetComponent<Animator>();
        srWing = wing.GetComponent<SpriteRenderer>();
        speechTextBox.text = "";
        gooseImage.enabled = false;
        animalImage.enabled = false;
    }
	
	
	void Update ()
    {
        rb.transform.rotation = Quaternion.identity;

        if (playerInputEnabled)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                MovePlayerHorizontally();
            }
            else
            {
                animGoose.SetBool("isWalking", false);
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
    }

    public void DisablePlayerInput()
    {
        playerInputEnabled = false;
        animGoose.SetBool("isWalking", false);
    }

    private void EnablePlayerInput()
    {
        playerInputEnabled = true;
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
        
    }

    private void Jump()
    {
        if(facingRight)
        {
            animWing.SetTrigger("triggerIsFlapping");
        }
        else
        {
            animWing.SetTrigger("triggerIsFlappingLeft");
        }    

        rb.transform.Translate(0, jumpDistance, 0);
    }

    private void TurnLeft()
    {
        facingRight = false;
        srGoose.flipX = true;
        animWing.SetBool("isFacingLeft", true);
    }

    private void TurnRight()
    {
        facingRight = true;
        srGoose.flipX = false;
        animWing.SetBool("isFacingLeft", false);
    }

    public void InteractWithCow()
    {
        if(ableToInteractWithCow)
        {
            DisablePlayerInput();
            gooseImage.enabled = true;
            speechTextBox.text = interactionStringArray[0];
            Invoke("CowRespondsToInteraction", 6.0f);
        }
        
    }

    private void CowRespondsToInteraction()
    {
        StopPlayerInteraction();
        //Show Picture
        animalImage.sprite = animalSpriteArray[0];
        animalImage.preserveAspect = true;
        animalImage.enabled = true;
        //Update Text
        speechTextBox.text = "Hey Anthony.  Afraid we haven't seen it.  You might want to check with the chickens, though.";
        Invoke("StopPlayerInteraction", 6.0f);
        ableToInteractWithCow = false;
    }

    public void InteractWithChicken()
    {
        if (ableToInteractWithChicken)
        {
            DisablePlayerInput();
            gooseImage.enabled = true;
            speechTextBox.text = interactionStringArray[1];
            Invoke("ChickenRespondsToInteraction", 5.0f);
        }
            
    }

    private void ChickenRespondsToInteraction()
    {
        StopPlayerInteraction();
        //Show Picture
        animalImage.sprite = animalSpriteArray[1];
        animalImage.preserveAspect = true;
        animalImage.enabled = true;
        //Update Sheep Text
        speechTextBox.text = "Oh, hi Anthony.  I haven't seen anything.  But my eyes aren't very good anymore!";
        Invoke("StopPlayerInteraction", 5.0f);
        ableToInteractWithChicken = false;
    }

    public void InteractWithSheep()
    {
        if (ableToInteractWithSheep)
        {
            DisablePlayerInput();
            gooseImage.enabled = true;
            speechTextBox.text = interactionStringArray[2];
            Invoke("SheepRespondsToInteraction", 5.0f);
        }
    }

    private void SheepRespondsToInteraction()
    {
        StopPlayerInteraction();
        //Show Sheep Picture
        animalImage.sprite = animalSpriteArray[2];
        animalImage.preserveAspect = true;
        animalImage.enabled = true;
        //Update Sheep Text
        speechTextBox.text = "Hi Anthony.  I saw the farmer take it inside his house.  Good luck!";
        Invoke("StopPlayerInteraction", 5.0f);
        ableToInteractWithSheep = false;
    }

    public void StopPlayerInteraction()
    {
        gooseImage.enabled = false;
        animalImage.enabled = false;
        speechTextBox.text = "";
        EnablePlayerInput();
    }
}
