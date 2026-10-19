using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NPCInteract : MonoBehaviour
{
    public TextMeshProUGUI interactText;
    public string interaction;
    public bool canInteract;
    public DialogueRunner dialogue;
    public NPCCamControl camController;
    public NPC_Data npcData;

    public void Start()
    {
        //this behavior is a bit `static` compared to previous system design techniques
        //BUT we are making this more `hard-coded` in an attempt to standardize our NPC_Cam_Rig system
        camController = transform.GetComponentInChildren<NPCCamControl>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setText(interaction);
            canInteract = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setText("");
            canInteract = false;
        }
    }

    //this is the setter method for our interact text
    public void setText(string txt)
    {
        interactText.text = txt;
    }

    public void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("You Talked to the NPC!");
                setText("");
                //camController.movePlayer();
                dialogue.StartDialogue(npcData.startingNode);
                canInteract = false;
            }
        }
    }

    //this is the `set` of the current phase of our YS dialog pulled from our npcData variable
    [YarnCommand("dialogPhaseSetter")]
    public void setYarnPhase()
    {
        InMemoryVariableStorage vData = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        vData.SetValue("$emiDialogPhase", npcData.currentPhase.ToString());
        vData.SetValue("$fridgeDialogPhase", npcData.currentPhase.ToString());
    }

    //this is the `get` of the current phase MADE in our YS dialog based on what options we've selected.
    [YarnCommand("dialogPhaseGetter")]
    public void getYarnPhase(string phase)
    {
        if (phase == "quest_taken")
        {
            npcData.currentPhase = NPC_Data.dialogPhase.quest_taken;
        }
        if (phase == "quest_complete_return")
        {
            npcData.currentPhase = NPC_Data.dialogPhase.quest_complete_return;
        }
       
    }

    public void OnApplicationQuit()
    {
        npcData.resetData();
    }
}
