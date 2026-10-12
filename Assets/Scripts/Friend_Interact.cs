using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class Friend_Interact : MonoBehaviour
{
    public bool canInteract;
    public TextMeshProUGUI interactText;
    public NPCInteract npcI;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setText("Press E");
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
                npcI.npcData.currentPhase = NPC_Data.dialogPhase.quest_complete;
                canInteract = false;
            }
        }
    }
}
