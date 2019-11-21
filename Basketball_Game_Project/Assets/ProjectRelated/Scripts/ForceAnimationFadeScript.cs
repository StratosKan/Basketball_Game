using UnityEngine;

public class ForceAnimationFadeScript : MonoBehaviour
{
    //Simple animation

    public Animator animator;

	void LateUpdate ()
    {
        if (Input.GetMouseButtonDown(0) && SceneLoaderDetectorScript.loaded)
        {
            FadeToNextState();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            FadeToNextState();

        }
    }

    public void FadeToNextState()
    {
        animator.SetTrigger("FadeOut");
        
    }
}
