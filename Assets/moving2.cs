using UnityEngine;

//This method is meant to get my character to move(controlled by the arrow keys)
public class moving2 : MonoBehaviour
{
    //Checks that the character is on the ground object
    private int groundContacts = 0;
    //This method checks if the collision is between my character and the ground

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If logic to check that the tag is ground(meaning its colliding w the ground)
        if (collision.gameObject.tag == "Ground")
        {
            //update groundContacts value
            groundContacts++;
        }
    }
    //This method updates the state of isOnGround after the character jumps away from the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        //If statement checks if the tag is ground
        if (collision.gameObject.tag == "Ground")
        {
            //If it is then update the groundContacts
            groundContacts--;
            if (groundContacts < 0) groundContacts = 0; // Safety check
        }
    }

    //Check if player is on the ground or a platform
    private bool IsOnGround()
    {
        return groundContacts > 0;
    }

    //animator should control the state of the character(changes from moving to still)
    private Animator animator;
    //flip should cause the character to face to the left or right depending on arrow keys
    private SpriteRenderer flip;
    //This is used for making the character jump without complications
    private Rigidbody2D rb;
    //Start runs initially, here we are just accessing the components!
    void Start()
    {
        //Allowing access to the animator component in my character object!
        animator = GetComponent<Animator>();
        //Allowing access to the spriterenderer component in my character object!
        flip = GetComponent<SpriteRenderer>();
        //Allowing access to the ridgebody2d component in my character object!
        rb = GetComponent<Rigidbody2D>();
    }

    //Here is where we update all the actions based on the arrow
    void Update()
    {
        //Control the boundries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -20f, 20f);
        transform.position = clampedPosition;
        //Check if the input is from the left key, if so keep the char facing left
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            flip.flipX = false;
        }
        //Check if the input is from the right key, if so switch so char faces right
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            flip.flipX = true;
        }
        //Leave else blank so that character stays facing whatever direction it was last going
        else
        {
        }
        //This vector is meant to set x value to the keyboard input(1,-1, or 0) depending on which arrow key was entered
        Vector2 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = 0;
        //This vel vector is meant to set the speed or "velcoity" of the character
        float faster = movement.x * 4f;
        rb.velocity = new Vector2(faster, rb.velocity.y);
        //Jumping!!!
        bool t = Input.GetKeyDown(KeyCode.UpArrow);
        if (t == true && IsOnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        //Make sure the split frames only switch while keys are being held/pressed
        if (animator != null)
        {
            //check that either of the arrow keys are being pressed and animate if they are
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            {
                animator.speed = 0.5f;
            }
            //if neither arrow key is being pressed then 
            else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= 0)
            {
                animator.speed = 0f;
            }
        }

    }
    //Set the values to vary for key functionality
    private bool hasKey = false;
    private GameObject carriedKey= null;
    //This part returns the bool value when the player has the key/
    public bool HasKey()
    {
        return hasKey;
    }
    //This method is meant to allow the player object to collect the key and carry it around
    public void CollectKey(GameObject key)
    {
        //This bool is updated to see if the character has the key or not
        hasKey = true;
        //referencing the key object to be used later!
        carriedKey = key;
        //Attach the key to the player object to they can interact(player can carry key)
        key.transform.SetParent(this.transform);
        //Place the key at this position in respect to the player object
        key.transform.localPosition = new Vector3(0f, 3.5f, 0);
        
        Rigidbody2D keyRb = key.GetComponent<Rigidbody2D>();
        if (keyRb != null)
        {
            keyRb.gravityScale = 0f;
            keyRb.velocity = Vector2.zero;
            keyRb.isKinematic = true;  // So it doesn’t react to physics
        }
    }
}
