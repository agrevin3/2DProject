using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Timer Settings")]
    public float levelTime = 60f;      // Total time per level
    private bool gameOver = false;     // Stops timer after game ends

    [Header("UI Settings")]
    public GameObject winPanel;        // Assign your "You Win" UI panel here

    void Start()
    {
        // Ensure win panel is hidden at start
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void Update()
    {
        if (!gameOver)
        {
            levelTime -= Time.deltaTime;

            if (levelTime <= 0f)
            {
                gameOver = true;
                SceneManager.LoadScene("StartScreen");  // Time ran out
            }
        }
    }

    // Call this method when the player completes the final level
    public void WinGame()
    {
        gameOver = true;  // Stop the timer
        if (winPanel != null)
            winPanel.SetActive(true);  // Show "You Win" panel

        StartCoroutine(WinDelay());  // Wait 3 seconds then return to start
    }

    private IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(3f);  // Wait for 3 seconds
        SceneManager.LoadScene("StartScreen"); // Go back to Start Screen
    }
}
