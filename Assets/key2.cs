using UnityEngine;

public class KeyPickup2 : MonoBehaviour
{
    //Checks if the key is collected 
    private bool collected = false;
//Have the player collect the key when they collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check that the collision is with player
        if (collected) return;
        //Check that the collision is with player
        if (collision.CompareTag("Player"))
        {
            moving2 player = collision.GetComponent<moving2>();
            if (player != null)
            {
                //update bool to show key is collected
                collected = true;
                player.CollectKey(gameObject);
            }
        }
    }
}

