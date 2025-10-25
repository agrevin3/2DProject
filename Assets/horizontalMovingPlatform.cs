using UnityEngine;
//When this is attached to a platform it makes it bounce back and forth horizontally
public class HorizontalMovingPlatform : MonoBehaviour
{
    //Alot of this can be adjusted in the inspector
    //The speed of the object(platform)
    public float speed = 2f;
    //The furthest left
    public float leftLimit = -4f;
    //furthest righ
    public float rightLimit = 4f;
    //small pause at the end is activated when true
    public bool pauseAtEnds = true; 
    //pause time duration is 1 second
    public float pauseTime = 1f; 
    //Use bool to track direction of movement
    private bool movingRight = true;
    //pause timer duration
    private float pauseTimer = 0f;

    void Update()
    {
        //If the platform is pausing...
        if (pauseAtEnds && pauseTimer > 0f)
        {
            //Then sub the change in time from the pause timer
            pauseTimer -= Time.deltaTime;
            return;
        }
        //Move in the correct direction based on the moving right boolean value
        float moveX = (movingRight ? speed : -speed) * Time.deltaTime;
        //Move it horizontally
        transform.position += new Vector3(moveX, 0f, 0f);
        //Check if the boundry was reached(right vs left)
        if (movingRight && transform.position.x >= rightLimit)
        {
            //Transform accordingly
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
            //Switch directions
            movingRight = false;
            //Pause at end maybe?
            if (pauseAtEnds) pauseTimer = pauseTime;
        }
        //else...
        else if (!movingRight && transform.position.x <= leftLimit)
        {
            //Do the same but opposite for the other direction
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
            movingRight = true;
            if (pauseAtEnds) pauseTimer = pauseTime;
        }
    }
}

