using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] float playerBGM;
    [SerializeField] float playerSFX;

    public static PersistentData Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
        playerBGM = 1;
        playerSFX = 1;
    }

    public void SetName(string name)
    {
        playerName = name;
    }
    public void SetScore (int score)
    {
        playerScore = score;
    }
    public void SetBGM(float value)
    {
        playerBGM = value;
    }
    public void SetSFX(float value)
    {
        playerSFX = value;
    }

    public string GetName()
    {
        return playerName;
    }
    public int GetScore()
    {
        return playerScore;
    }
    public float GetBGM()
    {
        return playerBGM;
    }
    public float GetSFX()
    {
        return playerSFX;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
