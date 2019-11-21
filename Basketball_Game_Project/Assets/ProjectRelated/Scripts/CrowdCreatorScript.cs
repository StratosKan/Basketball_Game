using UnityEngine;

public class CrowdCreatorScript : MonoBehaviour
{
    //ASSIGN THIS SCRIPT TO THE PARENT OF OBJECT OF CHAIRS

    private GameObject CrowdPersonPrefab;
    GameObject Crowd;
    public float Rotation = 0f;
    public float Position = 0.2f;
    void Start()
    {
        CrowdCreator();
    }

    void CrowdCreator()
    {
        foreach (Transform child in transform)
        {         
            CrowdPersonPrefab = (GameObject)(Resources.Load("Person"));
            Crowd = Instantiate(CrowdPersonPrefab, child.transform.localPosition, CrowdPersonPrefab.transform.rotation);
            Crowd.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y + Position, child.transform.localPosition.z);
            Crowd.transform.localRotation = new Quaternion(0, Rotation, 0, 90f);
            Crowd.transform.SetParent(child.transform, worldPositionStays: true);
            Renderer Crowd_colour = Crowd.GetComponent<Renderer>();
            Crowd_colour.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
