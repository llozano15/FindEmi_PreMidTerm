using Unity.Cinemachine;
using UnityEngine;
using Yarn.Unity;

public class NPCCamControl : MonoBehaviour
{
    public Transform npc_loc;
    public Transform pc_loc;
    public Transform pc_move_loc;
    public CinemachineCamera npc_cCam;
    public int pValue;

    //need additional transform variable for where we want the player character to move to

    [YarnCommand("cam_move")]
    public void cam_move(string focus)
    {
        npc_cCam.Priority = pValue;
        if (focus == "npc")
        {
            npc_cCam.gameObject.transform.position = npc_loc.position;
        }
        else if (focus == "pc")
        {
            npc_cCam.gameObject.transform.position = pc_loc.position;
        }
        else if (focus == "return")
        {
            npc_cCam.Priority = 0;
        }
    }

    public void movePlayer()
    {
        GameController.instance.moveForDialog(pc_move_loc);
    }
}
