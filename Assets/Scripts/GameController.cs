using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Audio;

public class GameController : MonoBehaviour {


    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text levelDisplayText;
    public Text evaluationText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private string evalText = "";
    

    private bool isRoundActive;
    private float timeRemaining;
    private int totalTime;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    public GameObject reference;
    public GameObject lazer;
    public Transform SpawnPoint;
    spawnAsteroid spawner;
    public AudioSource audioSource;   
    
    // Use this for initialization
    void Start () 
    {
        dataController = FindObjectOfType<DataController> ();
        currentRoundData = dataController.GetCurrentRoundData ();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        totalTime = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();
        UpdateCurrentLevelDisplay();

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion ();
        isRoundActive = true;

        spawner = (spawnAsteroid) reference.GetComponent(typeof(spawnAsteroid));   
        spawner.Spawn();
    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons ();
        QuestionData questionData = questionPool [questionIndex];
    
        string tempText = questionData.questionText;
        tempText.Replace("<BR>", "\n");
        questionDisplayText.text = tempText;
        //questionDisplayText.text.Replace("<BR>", "\n");

        for (int i = 0; i < questionData.answers.Length; i++) 
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0) 
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect) 
        {
            Shoot();
            if (Mathf.Round (timeRemaining) > 20)
                playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            else if (Mathf.Round (timeRemaining) < 5)
                playerScore += 5;
            else
                playerScore += (int)Mathf.Round(currentRoundData.pointsAddedForCorrectAnswer - ((25 - Mathf.Round(timeRemaining))/5));
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        } else 
        {
            GameObject[] failed = GameObject.FindGameObjectsWithTag("asteroid");
            foreach(GameObject go in failed) Destroy(go);
            QuestionData questionData = questionPool [questionIndex]; //get current question
            evalText = evalText + questionData.evaluationText + "\n\n";
        }

        if (questionPool.Length > questionIndex + 1) {
            questionIndex++;
            //reset time per each question
            timeRemaining = totalTime;
            timeRemainingDisplayText.text = "Time: " + timeRemaining.ToString();
            ShowQuestion ();
            spawner.Spawn();
        } else 
        {
            EndRound();
        }

    }

    public void EndRound()
    {
        isRoundActive = false;
        questionDisplay.SetActive (false);
        evaluationText.text = evalText;
        PersistentData.Instance.SetScore(playerScore);
        roundEndDisplay.SetActive (true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene ("MenuScreen");
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round (timeRemaining).ToString ();
    }

    // Update is called once per frame
    void Update () 
    {
        if (isRoundActive) 
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }
        }
    }
    
    void UpdateCurrentLevelDisplay()
    {
        levelDisplayText.text = "Level: " + (dataController.getRoundIndex() + 1);
    }

    void Shoot()
    {
        Instantiate(lazer, SpawnPoint.position, transform.rotation);
        audioSource.Play();
    }
}