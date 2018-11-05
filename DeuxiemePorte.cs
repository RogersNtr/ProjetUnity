using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeuxiemePorte : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collison");
        if (collision.gameObject.name == "Dirt2")
        {
            
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
