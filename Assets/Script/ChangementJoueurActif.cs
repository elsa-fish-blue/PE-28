using UnityEngine;

public static class GameUtils
{
    public static void Test(GameObject CurrentPlayer, Object NewPlayer, CameraFollowingPlayer ScriptCamera)
    {   Object.Destroy(CurrentPlayer);
        ScriptCamera.ActivePlayer = (GameObject)Object.Instantiate(NewPlayer);
        
            }
}
