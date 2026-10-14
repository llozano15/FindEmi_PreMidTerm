using UnityEngine;
using UnityEngine.SceneManagement;

public class FortExit : MonoBehaviour
{
    public Transform fortExit;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
