using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Timer timer;
        
    public int currentNumber;
    
    private const string FILE_FASTEST_TIME = "/MyFastestTimeFile.txt";

    private float finishTime;
    public float FinishTime
    {
        get
        {
            return finishTime;
        }
        set
        {
            finishTime = value;
            finishTimeText.text = finishTime + "s";
            FastestTime = finishTime;
        }
    }
    
    private float fastestTime;
    public float FastestTime
    {
        get { return fastestTime; }
        set
        {
            if (value > fastestTime)
            {
                fastestTime = value;
                fastestTimeText.text = fastestTime + "s";
                
                File.WriteAllText(Application.dataPath + FILE_FASTEST_TIME, "FastestTime : " + fastestTime);
            }
        }
    }

    public GameObject endGamePanel;
    public Text finishTimeText;
    public Text fastestTimeText;
    public Text congratText;

    public GameObject startGamePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNumber > 50)
        {
            Time.timeScale = 0.0f;
            FinishTime = timer.currentTime;

            if (finishTime < fastestTime)
                congratText.text = "YOU CAN DO THIS!";
            else
            {
                congratText.text = "YEAYYY";
            }

            endGamePanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            InitializeGame();
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }

    void InitializeGame()
    {
        startGamePanel.SetActive(false);
        endGamePanel.SetActive(false);
        currentNumber = 1;
        
        if (!File.Exists(Application.dataPath + FILE_FASTEST_TIME))
            File.WriteAllText(Application.dataPath + FILE_FASTEST_TIME, "FastestTime : " + fastestTime);
        
        FinishTime = 0;
        string FastestTimeFileText = File.ReadAllText(Application.dataPath + FILE_FASTEST_TIME);
        string[] timeSplit = FastestTimeFileText.Split(' ');
        FastestTime = float.Parse(timeSplit[2]);
    }
}
