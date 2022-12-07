using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour 
{
    public RoundData[] allRoundData;
    public QuestionData[] incorrectQuestions;

    private int roundIndex = 0;

    // Use this for initialization
    void Start ()  
    {
        DontDestroyOnLoad (gameObject);

        SceneManager.LoadScene ("MainMenu");
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData [0];
    }

    public int incrementRound()
    {
        if(roundIndex < allRoundData.Length)
        {
            roundIndex++;
            return roundIndex;
        }
        return -1; //we'll use this to tell that we are at the end
        
    }

    public void resetRound()
    {
        roundIndex = 0;
    }

    public int getRoundIndex()
    {
        return roundIndex;
    }

    // public QuestionData getIncorrectQuestions()
    // {
    //     return incorrectQuestions;
    // }

}
