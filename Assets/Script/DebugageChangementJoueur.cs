using Unity.Burst.Intrinsics;
using UnityEngine;

public class DebugageChangementJoueur : MonoBehaviour
{
    [SerializeField] private  GameObject var1;
    [SerializeField] private Object var2;
    [SerializeField] private CameraFollowingPlayer CameraU;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameUtils.Test(var1,var2,CameraU);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
