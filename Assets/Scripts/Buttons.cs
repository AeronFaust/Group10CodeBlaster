using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Buttons : MonoBehaviour
{
    [SerializeField] InputField PlayerNameInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        string name = PlayerNameInput.text;
        PersistentData.Instance.SetName(name);
        SceneManager.LoadScene("Game");
        Destroy(GameObject.Find("BGM"));
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
