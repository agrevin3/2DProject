using UnityEngine;

//This class is supposed to be used to open the door when the player with the key touches it(work in progress)
public class DoorTrigger : MonoBehaviour
{
    //Use the two different sprites from the door spritesheet
    public Sprite closedDoorSprite;
    public Sprite openDoorSprite;
    private SpriteRenderer spriteRenderer;
    //Create a bool to update state of door
    private bool isOpen = false;

    private void Start()
    {
        //Get the component and set it to the closed door sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoorSprite;
    }
    //This should be called when a collision with the door and the person holding the key occurs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Do nothing
        if (isOpen) return;
        //If the player is colliding with the door...
        if (collision.CompareTag("Player"))
        {
            //Then get the player script
            moving player = collision.GetComponent<moving>();
            //And open the door!
            if (player != null && player.HasKey())
            {
                OpenDoor();
            }
        }
    }
    //This method should be called to open the door(switch between sprites)
    void OpenDoor()
    {
        isOpen = true;
        spriteRenderer.sprite = openDoorSprite;
    }
}

