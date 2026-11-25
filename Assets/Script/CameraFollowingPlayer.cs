using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{
    public GameObject ActivePlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = ActivePlayer.transform.position + new Vector3 (0,0,-10) ;
    }
}
