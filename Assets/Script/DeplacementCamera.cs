using UnityEngine;

public class DeplacementCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 decalage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        decalage = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + decalage;
    }
}
