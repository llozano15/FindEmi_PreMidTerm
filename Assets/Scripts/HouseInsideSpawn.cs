using UnityEngine;

public class HouseInsideSpawn : MonoBehaviour
{
    void Start()
    {
        GameController.instance.SpawnCharacter(this.transform.position, this.transform.rotation);
    }
}
