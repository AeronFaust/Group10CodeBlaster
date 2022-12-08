using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AnswerButton : MonoBehaviour {

    public Text answerText;
    //public AudioSource audioSource;
    //public AudioClip[] audioClipArray;
    
    private AnswerData answerData;
    private GameController gameController;

    // Use this for initialization
    void Start () 
    {
        gameController = FindObjectOfType<GameController> ();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }


    public void HandleClick()
    {
        //PlayAudio();
        gameController.AnswerButtonClicked (answerData.isCorrect);
    }
    /*
    public void PlayAudio()
    {
	    audioSource.PlayOneShot(RandomClip());
    }
	
    AudioClip RandomClip()
    {
	    return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }*/
}