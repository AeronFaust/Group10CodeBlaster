using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    private DataController dataController;

    void Start()
    {
        dataController = FindObjectOfType<DataController> ();
    }

    public void setLevel1()
    {
        dataController.levelOne();
        SceneManager.LoadScene ("Game");
    }

    public void setLevel2()
    {
        dataController.levelTwo();
        SceneManager.LoadScene ("Game");
    }
    public void setLevel3()
    {
        dataController.levelThree();
        SceneManager.LoadScene ("Game");
    }
}
