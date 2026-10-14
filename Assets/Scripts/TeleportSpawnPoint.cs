using UnityEngine;

public class TeleportSpawnPoint : MonoBehaviour
{
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        if (!TeleportSpawnData.HasSpawnPoint)
            return;

        // Disable the controller while moving the player
        if (characterController != null)
            characterController.enabled = false;

        transform.SetPositionAndRotation(
            TeleportSpawnData.Position,
            TeleportSpawnData.Rotation
        );

        if (characterController != null)
            characterController.enabled = true;

        TeleportSpawnData.HasSpawnPoint = false;
    }
}
