using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class KillPlayer : MonoBehaviour
{

    public Transform spawnPoint;
    public Transform spawnPoint2;
    private void OnCollisionEnter2D(Collision2D other)
    {
        String first = other.gameObject.tag;
        if (first == "Enemies" || first == "Traps")
        {
            String second = this.gameObject.tag;
            GameObject scndPlayer;
            if (second == "Player")
            {
                this.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation); // respawn 
                scndPlayer = GameObject.FindGameObjectWithTag("Player2");
                scndPlayer.transform.SetPositionAndRotation(spawnPoint2.position, spawnPoint2.rotation); // respawn
            }
            else
            {
                this.transform.SetPositionAndRotation(spawnPoint2.position, spawnPoint2.rotation); // respawn 
                scndPlayer = GameObject.FindGameObjectWithTag("Player");
                scndPlayer.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation); // respawn 
            }
            float gravity_robot = this.GetComponent<Rigidbody2D>().gravityScale;
            float JumpForce_robot = this.GetComponent<PlatformerCharacter2D>().m_JumpForce;
            this.GetComponent<Rigidbody2D>().gravityScale = Math.Abs(gravity_robot); // remise de la gravité à la normale
            this.GetComponent<PlatformerCharacter2D>().m_JumpForce = Math.Abs(JumpForce_robot);
            if(first == "Enemies")
                other.gameObject.GetComponent<enemyAI>().ResetTarget();
        }
    }
}
