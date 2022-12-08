using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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
            if (Mathf.Round (timeRemaining) > 20)
                playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            else if (Mathf.Round (timeRemaining) < 5)
                playerScore += 5;
            else
                playerScore += (int)Mathf.Round(currentRoundData.pointsAddedForCorrectAnswer - ((25 - Mathf.Round(timeRemaining))/5));
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        } else {
            QuestionData questionData = questionPool [questionIndex]; //get current question
            evalText = evalText + questionData.evaluationText + "\n\n";
        }

        if (questionPool.Length > questionIndex + 1) {
            questionIndex++;
            //reset time per each question
            timeRemaining = totalTime;
            timeRemainingDisplayText.text = "Time: " + timeRemaining.ToString();
            ShowQuestion ();
        } else 
        {
            //EndRound();
            Invoke("goToNextRound", 0.25f);
        }

    }

    public void EndRound()
    {
        isRoundActive = false;
        dataController.resetRound();

        questionDisplay.SetActive (false);
        evaluationText.text = evalText;
        PersistentData.Instance.SetScore(playerScore);
        roundEndDisplay.SetActive (true);
    }

    //go to the next round
    public void goToNextRound()
    {
        int index = dataController.incrementRound();
        Debug.Log(index);
        if(index == -1)
        {
            EndRound();
        }
        else
        {
            currentRoundData = dataController.GetCurrentRoundData ();
            questionPool = currentRoundData.questions;
            timeRemaining = currentRoundData.timeLimitInSeconds;
            totalTime = currentRoundData.timeLimitInSeconds;
            UpdateTimeRemainingDisplay(); 
            UpdateCurrentLevelDisplay();  
            ShowQuestion();
        }
        
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
}