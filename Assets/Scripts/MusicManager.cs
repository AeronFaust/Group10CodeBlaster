using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour 
{
    private static MusicManager music;
 
    public static MusicManager instance
    {
        get
        {
            if(music == null)
            {
                music = GameObject.FindObjectOfType<MusicManager>();
 
                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(music.gameObject);
            }
 
            return music;
        }
    }
 
    void Awake() 
    {
        if(music == null)
        {
            //If I am the first instance, make me the Singleton
            music = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if(this != music)
                Destroy(this.gameObject);
        }
    }
 
    public void Play()
    {

    }
}

