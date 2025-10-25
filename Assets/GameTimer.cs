using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  

//This code should work to set the game timer to 60 seconds
public class GameTimer : MonoBehaviour
{
    //Setting the time to 1 minute(60 seconds)
    public float timeRemaining = 60f;
    //This is used to make the timer visible
    public TMP_Text timerText;
    //Set a bool to track the timer
    private bool timerRunning = false;
    //Used to keep the timer running constantly
    private static GameTimer instance;
    void Awake()
    {
        //If the game timer doesnt exist
        if (instance == null)
        {
            //Keep the timer from scene to scene
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy otherwise
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //If the timer is running then update it visually
        if (timerRunning)
        {
            UpdateTimerText();
        }
    }

    void Update()
    {
        //If the timer isnt running then return out of the method
        if (!timerRunning) return;
        //Update the time remaining on the timer and update it visually
        timeRemaining -= Time.deltaTime;
        UpdateTimerText();
        //If the clock hits 0 then set the boolean to false and return to the start scene
        if (timeRemaining <= 0)
        {
            timerRunning = false;
            ReturnToStartScene();
        }
    }

    //This starts the timer from the home scene
    public void StartTimer(float duration = 60f)
    {
        //Set the timer values such as time remaining and the bool running to update accordingly
        timeRemaining = duration;
        timerRunning = true;
        //Update it visually
        UpdateTimerText();
    }
    //Update visually!
    private void UpdateTimerText()
    {
        //Double check timer exists
        if (timerText != null)
        {
            //Change from float to int for visuals
            int seconds = Mathf.CeilToInt(timeRemaining);
            //Show each second
            timerText.text = seconds.ToString();
        }
    }
    //This returns to start when the timer ends
    private void ReturnToStartScene()
    {
        SceneManager.LoadScene("Home");
        //Reset the timer
        Destroy(gameObject);
    }

    //Enabling the game object when called
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    //Disable the game object when called
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Only run if timer ref doesnt exist yet
        if (timerText == null)
        {
            //Countdown display
            GameObject textObj = GameObject.Find("TimerText");
            //If its not null...
            if (textObj != null)
            {
                //Use TMP_Text for text
                timerText = textObj.GetComponent<TMP_Text>();
                //Allow transformations of the text
                RectTransform rt = timerText.GetComponent<RectTransform>();
                if (rt != null)
                {
                    //Set the anchor positions
                    rt.anchorMin = new Vector2(1, 1);
                    rt.anchorMax = new Vector2(1, 1);
                    //Move the text inwards
                    rt.anchoredPosition = new Vector2(-10f, -10f);
                }
            }
        }
    }
}
