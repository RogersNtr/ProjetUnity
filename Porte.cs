using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collison");
        if (collision.gameObject.name == "Dirt")
        {
            print("dede");
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
    }
}
