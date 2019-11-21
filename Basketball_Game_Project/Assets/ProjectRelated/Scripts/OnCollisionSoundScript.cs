using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollisionSoundScript : MonoBehaviour
{

    //CODE IS NOT PERFOMANT
    //IT IS MORE REALISTIC THO :D


    private GameObject SoundSource;
    public GameObject[] objects;
    int currentScene = 0;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 1)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_Tutorial"));
        } //tutorial
        else if (currentScene == 2)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S1"));
        } //wood
        else if (currentScene == 3)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S2"));
        } //tartan
        else if (currentScene == 4)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S3"));
        }//concrete
        else if (currentScene == 5)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S4"));
        }//wood_crowd
        else if (currentScene == 6)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S5"));
        }//tartan_crowd
        else if (currentScene == 7)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S6"));
        } //wood
        else if (currentScene == 8)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S7"));
        } //tartan
        else if (currentScene == 9)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S8"));
        }//concrete
        else if (currentScene == 10)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S9"));
        }//wood_crowd
        else if (currentScene == 11)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S10"));
        }//tartan_crowd
        else if (currentScene == 12)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S11"));
        } //wood
        else if (currentScene == 13)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S12"));
        } //tartan
        else if (currentScene == 14)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S13"));
        }//concrete
        else if (currentScene == 15)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S14"));
        }//wood_crowd
        else if (currentScene == 16)
        {
            SoundSource = (GameObject)(Resources.Load("Sound_BallHit_S15"));
        }//tartan_crowd
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.y <=10)
        {
            Instantiate(SoundSource, transform.position, transform.rotation);
            objects = GameObject.FindGameObjectsWithTag("SoundObject");
        }
    }

    void OnDestroy()
    {
        for (int i =0; i < objects.Length ; i++)
        {
            Destroy(objects[i]);
        }
    }
}