using UnityEngine;
using UnityEngine.SceneManagement;
//This is the start button-when pressed load samplescene(level1)
public class StartButton : MonoBehaviour
{
    //This should be called when user clicks on button
    public void OnStartButtonClicked()
    {
        //Start the timer
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            timer.StartTimer();
        }
        //Load the upcoming scene
        SceneManager.LoadScene("SampleScene");
    }
}

