using UnityEngine;
using UnityEngine.SceneManagement;

public class FortEnter : MonoBehaviour
{
    public Transform fortReturn;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameController.instance.setSpawnPoint(fortReturn.position, fortReturn.rotation);
            SceneManager.LoadScene(1);

            Debug.Log("touching collider");
        }

    }
}
