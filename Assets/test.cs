using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject reference;
    // Start is called before the first frame update
    void Start()
    {
        spawnAsteroid spawner = (spawnAsteroid) reference.GetComponent(typeof(spawnAsteroid));   
        spawner.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
