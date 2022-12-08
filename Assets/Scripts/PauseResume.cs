using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    [SerializeField] GameObject[] pauseModeObjects;
    [SerializeField] GameObject[] resumeModeObjects;

    // Start is called before the first frame update
    void Start()
    {
        pauseModeObjects = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        resumeModeObjects = GameObject.FindGameObjectsWithTag("ShowWhenResumed");

        foreach (GameObject g in pauseModeObjects)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;

        foreach(GameObject g in pauseModeObjects)
            g.SetActive(true);

        foreach(GameObject g in resumeModeObjects)
            g.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;

        foreach (GameObject g in pauseModeObjects)
            g.SetActive(false);

        foreach (GameObject g in resumeModeObjects)
            g.SetActive(true);
    }
}
