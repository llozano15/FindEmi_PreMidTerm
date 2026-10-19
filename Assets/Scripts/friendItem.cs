using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class friendItem : MonoBehaviour
{
    public NPC_Data npcData;
    public TextMeshProUGUI foundMessage;

    private bool playerNearby;
    private bool collected;

    private void Start()
    {
        if (foundMessage != null)
        {
            foundMessage.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }

    private void Update()
    {
        if (!playerNearby || collected)
            return;

        if (Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (npcData == null)
            {
                Debug.LogError("Data is not assigned");
                return;
            }

            if (npcData.currentPhase !=
                NPC_Data.dialogPhase.quest_taken)
            {
                Debug.Log("quest not accepted");
                return;
            }

            
            npcData.currentPhase =
                NPC_Data.dialogPhase.quest_complete;

          
            if (foundMessage != null)
            {
                foundMessage.gameObject.SetActive(true);
                foundMessage.text = "found me! >;3";
            }

            collected = true;

            Debug.Log("found me! >:3");

            gameObject.SetActive(false);
        }
    }
}
