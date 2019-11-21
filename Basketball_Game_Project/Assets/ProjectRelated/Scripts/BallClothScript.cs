using UnityEngine;

public class BallClothScript : MonoBehaviour
{
    //CODE IS NOT PERFORMANT BUT WORKS

    public GameObject[] bball;

    Cloth clothComponent;

    void Start ()
    {
        clothComponent = gameObject.GetComponent<Cloth>();
    }

    void Update ()
    {
        bball = GameObject.FindGameObjectsWithTag("BBall"); 

        foreach (GameObject bballs in bball)
        {
            var sphereColliderArray = new ClothSphereColliderPair[1];
            sphereColliderArray[0] = new ClothSphereColliderPair(bballs.GetComponent<SphereCollider>());
            clothComponent.sphereColliders = sphereColliderArray;
        }
	}
}