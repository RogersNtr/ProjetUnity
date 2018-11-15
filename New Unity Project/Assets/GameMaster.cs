using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;

    public Transform player1Prefab;
    public Transform player2Prefab;
    public Transform spawnPoint;
    public int spawnDelay = 0;
    void Start()
    {
        if (gm == null)
        {
            //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            gm = this;
        }
    }



    public IEnumerator RespawnPlayer()
    {
        Instantiate(player1Prefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(player2Prefab, spawnPoint.position, spawnPoint.rotation);
        print("yolo");
        if (GameObject.FindGameObjectWithTag("Player2") != null)
        {
            print("found the players");
        }
        else
            print("didnt found them...");
        yield return false;
    }


}