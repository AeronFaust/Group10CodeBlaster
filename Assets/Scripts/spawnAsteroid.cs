using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroid; //reference in the Inspector the object you want to spawn
    [SerializeField] Transform Destination; //reference in the Inspector the Empty game object you use to choose position and rotation.
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Instantiate (asteroid, Destination.position, Destination.rotation);
    }
}
