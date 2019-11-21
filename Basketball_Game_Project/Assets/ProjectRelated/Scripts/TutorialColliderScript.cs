using UnityEngine;

public class TutorialColliderScript : MonoBehaviour
{
    public static int score = 0;

	void Start ()
    {
        score = ScoreManager.scoreCount;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="BBall" && ScoreManager.scoreCount != score)
        {
            score = ScoreManager.scoreCount;
            transform.parent.parent.gameObject.SetActive(false);             
        }
    }
}