using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class UpAndDown : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other)
    {
        string first = other.gameObject.tag;
        if (first != "Player" && first != "Player2")
        {
            float gravity_trap = this.GetComponent<Rigidbody2D>().gravityScale;
            this.GetComponent<Rigidbody2D>().gravityScale = gravity_trap * (-1); // inversion gravité
        }
    }
}
