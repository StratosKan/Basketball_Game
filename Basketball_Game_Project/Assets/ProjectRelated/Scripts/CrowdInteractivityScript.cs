using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdInteractivityScript : MonoBehaviour
{
    //THIS IS NESTED INSIDE THE PERSON PREFAB, LOCATED IN RESOURCES, TO MAKE IT BOB UP AND DOWN

    public float speed = 5f;     //adjust this to change speed
    public float height = 0.5f;     //adjust this to change how high it goes

    float randSpeed;
    bool inside = false;
    float newY;
    int score = 0;

    void Start ()
    {
        score = ScoreManager.scoreCount;
        randSpeed = Random.Range(1f, 5f);
	}
	
	void FixedUpdate ()
    {
        CrowdInteraction();
        if (score != ScoreManager.scoreCount)
        {
            StartCoroutine(TimeToPass());
            score = ScoreManager.scoreCount;
        }
        else
        {
            //TODO : slow down crowd instead of making faster for ball miss
        }
    }

    void CrowdInteraction()
    {
        Vector3 pos = transform.localPosition;
        if (inside)
        {
            newY = Mathf.Sin(Time.time * randSpeed) *2.5f;
        }
        else
        {
            newY = Mathf.Sin(Time.time * randSpeed);
        }
        Mathf.Clamp01(newY);
        transform.localPosition = new Vector3(pos.x, newY + 8.5f, pos.z) * height;
    }

    public IEnumerator TimeToPass() //Starts a timer in seconds
    {
        inside = true;

        yield return new WaitForSeconds(1f); //Waits x seconds

        inside = false;
    }
}