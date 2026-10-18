using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnPointFinder : MonoBehaviour
{
    [SerializeField] private Transform player;

    private GameObject spawnPoint;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "CouchFort")
        {
            spawnPoint = GameObject.Find("Spawnpoint");

            if (spawnPoint == null)
            {
                Debug.LogError("Spawnpoint not found in CouchFort!");
                return;
            }

            if (player == null)
            {
                Debug.LogError("Player Transform is not assigned in the Inspector!");
                return;
            }

            CharacterController controller =
                player.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;
            }

            player.SetPositionAndRotation(
                spawnPoint.transform.position,
                spawnPoint.transform.rotation
            );

            if (controller != null)
            {
                controller.enabled = true;
            }

            Physics.SyncTransforms();

            Debug.Log("Player spawned successfully at Spawnpoint!");
        }
    }
}
