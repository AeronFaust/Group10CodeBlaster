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
        return allRoundData [roundIndex];
    }

    public void levelOne()
    {
        roundIndex = 0;
    }

    public void levelTwo()
    {
        roundIndex = 1;
    }

    public void levelThree()
    {
        roundIndex = 2;
    }

    public int getRoundIndex()
    {
        return roundIndex;
    }


}
