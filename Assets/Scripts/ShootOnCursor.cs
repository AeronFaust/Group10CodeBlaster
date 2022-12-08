using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnCursor : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayAudio();
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            explosion.layer = LayerMask.NameToLayer("UI");
            Instantiate(explosion, new Vector3(cursorPos.x, cursorPos.y, 50), Quaternion.identity);
        }
    }
    
    public void PlayAudio()
    {
	    audioSource.PlayOneShot(RandomClip());
    }
	
    AudioClip RandomClip()
    {
	    return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
}
