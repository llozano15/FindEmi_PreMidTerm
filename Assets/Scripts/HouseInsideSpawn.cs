using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseInsideSpawn : MonoBehaviour
{
    [SerializeField] private string destinationScene;

    private void OnTriggerEnter(Collider other)
    {
        // Only teleport the player
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(destinationScene);
        }
    }
}
