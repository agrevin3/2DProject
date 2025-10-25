using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    //Checks if the key is collected
    private bool collected = false;
    //Have the player collect the key when they collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the key is already collected exit
        if (collected) return;
        //Check that the collision is with player
        if (collision.CompareTag("Player"))
        {
            moving player = collision.GetComponent<moving>();
            if (player != null)
            {
                //update bool to show key is collected
                collected = true;
                player.CollectKey(gameObject);
            }
        }
    }
}

