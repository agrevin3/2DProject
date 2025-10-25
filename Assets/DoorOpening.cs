using UnityEngine;
using UnityEngine.SceneManagement;
//This Code is used for a lot of the door interactions(specifically interactions with the key)
public class DoorController : MonoBehaviour
{
    //These were used to try to use the different doornsprites on the spritesheet(Work In Progress)
    public Sprite closedDoor;
    public Sprite openDoor;
    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;

    //This part can be changed in the inspector for each new scene to be loaded

    [Tooltip("Name of the scene to load after opening the door")]
    //This gets overridden by the inspector but works as a default otherwise
    public string nextSceneName = "Level2";
    void Start()
    {
        //Gather the component and set to closed door
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoor;
        //Create a case for if there isnt a next scene written in
        if (string.IsNullOrEmpty(nextSceneName))
        {
            Debug.LogWarning("Next scene name is not set on DoorController!");
        }
    }
    //This is called when something collides with the door trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Door triggered by: " + collision.gameObject.name + ", Tag: " + collision.gameObject.tag);

        //Check that the key is collected and the door is closed
        if (collision.CompareTag("key") && !isOpen)
        {
            Debug.Log("Key collided with door!");
            //Now open the door(Still doesnt work as intended yet)
            OpenDoor();
            //Destroy the key so it looks like it disappears through the door
            Destroy(collision.gameObject);
            //Destroy the player so it looks like it disappears through the door
            Destroy(collision.transform.parent.gameObject);

            //If there is a scene set then enter into that scene next!
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                //Here we load the next scene with a 1 second delay
                Invoke(nameof(LoadNextScene), 1f);
            }
            else
            {
                Debug.LogError("Cannot load next scene because nextSceneName is empty!");
            }
        }
    }

    //The Door opening function
    void OpenDoor()
    {
        //Update the bool value
        isOpen = true;
        spriteRenderer.sprite = openDoor;
    }
    //The scene loading function

    void LoadNextScene()
    {
        //Get the next scene info
        SceneManager.LoadScene(nextSceneName);
    }
}


