using UnityEngine;
using System.Collections;

//This code should, when attached to platforms make them disappear and re-appear
public class PeriodicPlatformVisibility : MonoBehaviour
//These can be adjusted in inspector
{
    [Tooltip("How long the platform stays visible")]
    public float visibleDuration = 2f;

    [Tooltip("How long the platform stays invisible")]
    public float invisibleDuration = 2f;

    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;
    //Starting statements/conditions
    void Start()
    {
        //Sprite rendering and colliding components
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        StartCoroutine(VisibilityLoop());
    }

    //Variable so that the platforms disappearing and reappearing run in a loop
    private IEnumerator VisibilityLoop()
    {
        while (true)
        {
            //This part makes it visable
            if (spriteRenderer != null) spriteRenderer.enabled = true;
            if (collider2D != null) collider2D.enabled = true;

            yield return new WaitForSeconds(visibleDuration);

            //This makes the platform invisible
            if (spriteRenderer != null) spriteRenderer.enabled = false;
            if (collider2D != null) collider2D.enabled = false;

            yield return new WaitForSeconds(invisibleDuration);
        }
    }
}
