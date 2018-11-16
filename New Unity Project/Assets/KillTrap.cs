using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrap : MonoBehaviour {

    public GameObject trap;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            Destroy(trap);
            Destroy(gameObject);
        }
    }
}
