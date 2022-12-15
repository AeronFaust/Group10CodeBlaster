using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aersteroidBehavior : MonoBehaviour
{
    [SerializeField] GameObject objectToMove;
    [SerializeField] GameObject endPoint;
    [SerializeField] float seconds;

    
    void Update() 
    {
        StartCoroutine (MoveOverSeconds (objectToMove, endPoint, seconds));
        objectToMove = GameObject.FindGameObjectWithTag("asteroid");
    }

    public IEnumerator MoveOverSeconds (GameObject objectToMove, GameObject endPoint, float seconds)
    {
        Vector3 end = endPoint.transform.position;
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }
    
}
