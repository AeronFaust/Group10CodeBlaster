using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D col) 
	{
		//Don't want to collide with the ship that's shooting this thing, nor another projectile.
		if (col.gameObject.tag == "Projectile")
        {
			Destroy(gameObject);
		}
	}
}
