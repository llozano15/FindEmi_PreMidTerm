using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public Transform startingLoc;
    public Vector3 loadLoc;
    public Quaternion loadRot;
    public bool firstSceneloaded = false;
    public GameObject ThirdPersonRig;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);

            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("Loaded Scene: " + SceneManager.GetActiveScene());
        }

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            if (!firstSceneloaded)
            {
                Debug.Log("Spawned Character at starting Location");
                SpawnCharacter(startingLoc.position, startingLoc.rotation);
                firstSceneloaded = true;
            }
            else
            {
                Debug.Log("Spawned Character at new Location");
                SpawnCharacter(loadLoc, loadRot);
            }

            
        }
    }

    public void SpawnCharacter(Vector3 loc, Quaternion rot)
    {
        Debug.Log("SPAWNED THIRD PERSON");
        Instantiate(ThirdPersonRig, loc, rot);
    }

    public void setSpawnPoint(Vector3 loc, Quaternion rot)
    {
        loadLoc = loc;
        loadRot = rot;
    }
    public void setPlayerMovement(bool b)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ThirdPersonController tpc = player.GetComponent<ThirdPersonController>();

        if (b)
        {
            tpc.enabled = false;
        }
        else
        {
            tpc.enabled = true;
        }
    }
    public void moveForDialog(Transform movePos)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = movePos.position;
    }
}
