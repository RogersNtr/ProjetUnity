using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    public class Portail2 : MonoBehaviour {
        Vector3 repspawnPostionUp = new Vector3(19f, 8f);
        Quaternion repspawnRotationUp = new Quaternion(0f, 0f, 0, 0f);
        Vector3 repspawnPostionDown = new Vector3(15f, 8f);
        Quaternion repspawnRotationDown = new Quaternion(0f, 0f, 180f, 0f);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject robot = collision.gameObject;
            if (robot.GetComponent<Rigidbody2D>().gravityScale > 0) // si on est au dessus
            {
                robot.GetComponent<Rigidbody2D>().gravityScale = robot.GetComponent<Rigidbody2D>().gravityScale * (-1); // inverse la gravité
                robot.transform.SetPositionAndRotation(repspawnPostionDown, repspawnRotationDown); // respawn 
                robot.GetComponent<PlatformerCharacter2D>().m_JumpForce = robot.GetComponent<PlatformerCharacter2D>().m_JumpForce * (-1);
            }
            else // si on est en dessous
            {
                robot.GetComponent<Rigidbody2D>().gravityScale = robot.GetComponent<Rigidbody2D>().gravityScale * (-1); // inverse la gravité
                robot.transform.SetPositionAndRotation(repspawnPostionUp, repspawnRotationUp); // respawn 
                robot.GetComponent<PlatformerCharacter2D>().m_JumpForce = robot.GetComponent<PlatformerCharacter2D>().m_JumpForce * (-1);
            }
        }
    }
}