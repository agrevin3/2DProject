using UnityEngine;
using System.Collections;
//Causes the platforms to rise vertically
public class RisingPlatform : MonoBehaviour
{
    //Some of this can be adjusted in the inspector
    //Set the platform speed
    public float speed = 2f;
    //Set max height
    public float maxY = 10f;
    //Set the resetValue
    public float resetY = -5f;
    //Set a delay from start time
    public float startDelay = 5f;

    void Start()
    {
        //begin rising
        StartCoroutine(RiseRoutine());
    }

    private IEnumerator RiseRoutine()
    {
        //Execute the delay initially
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            //Move the platform up
            transform.position += Vector3.up * speed * Time.deltaTime;
            //Reset position to reset location if max loc is exceeded
            if (transform.position.y > maxY)
            {
                Vector3 pos = transform.position;
                pos.y = resetY;
                transform.position = pos;
            }

            yield return null;
        }
    }
}

