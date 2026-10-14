using UnityEngine;
using UnityEngine.SceneManagement;

public class teleporter : MonoBehaviour
{
    [Header("Destination Scene")]
    [SerializeField] private string destinationScene;

    [Header("Destination Position")]
    [SerializeField] private Transform destinationTransform;

    private bool isLoading;

    private void OnTriggerEnter(Collider other)
    {
        CharacterController player =
            other.GetComponentInParent<CharacterController>();

        if (player == null || !player.CompareTag("Player"))
            return;

        if (isLoading)
            return;

        if (string.IsNullOrWhiteSpace(destinationScene))
        {
            Debug.LogError("Destination Scene is empty!", this);
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(destinationScene))
        {
            Debug.LogError(
                "Scene not found in Build Profile: " + destinationScene,
                this
            );
            return;
        }

        if (destinationTransform == null)
        {
            Debug.LogError("Assign a Destination Transform!", this);
            return;
        }

        isLoading = true;

        // Save the spawn position and rotation before loading
        Vector3 spawnPosition = destinationTransform.position;
        Quaternion spawnRotation = destinationTransform.rotation;

        // Store the spawn point for the next scene
        TeleportSpawnData.Position = spawnPosition;
        TeleportSpawnData.Rotation = spawnRotation;
        TeleportSpawnData.HasSpawnPoint = true;

        SceneManager.LoadScene(destinationScene);
    }
}

public static class TeleportSpawnData
{
    public static Vector3 Position;
    public static Quaternion Rotation;
    public static bool HasSpawnPoint;
}

        



