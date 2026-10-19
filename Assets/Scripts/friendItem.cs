using UnityEngine;

public class friendItem : MonoBehaviour
{
    public NPC_Data npcData;

    private bool collected;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || collected)
            return;

        if (npcData == null)
        {
            Debug.LogError("NPC_Data is not assigned!");
            return;
        }

        // Only allow collection after accepting the quest.
        if (npcData.currentPhase != NPC_Data.dialogPhase.quest_taken)
            return;

        // Update the shared phase.
        npcData.currentPhase = NPC_Data.dialogPhase.quest_complete;

        collected = true;

        Debug.Log("Quest item collected! Current phase: "
            + npcData.currentPhase);

        
    }
}
