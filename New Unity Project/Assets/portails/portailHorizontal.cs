using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    public class portailHorizontal : MonoBehaviour {
        Vector3 pos_portail = new Vector3();
        Vector3 repspawnPostionDown = new Vector3();
        Quaternion repspawnRotationDown = new Quaternion(0f, 0f, 180, 0f);
        Vector3 repspawnPostionUp = new Vector3();
        Quaternion repspawnRotationUp = new Quaternion(0f, 0f, 0f, 0f);
        void Start()
        {
            pos_portail = gameObject.transform.position;
            repspawnPostionDown.x = pos_portail.x;
            repspawnPostionDown.y = pos_portail.y-3;
            repspawnPostionUp.x = pos_portail.x;
            repspawnPostionUp.y = pos_portail.y+3;
        }
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            GameObject robot = collision.gameObject;
            float gravity_robot = robot.GetComponent<Rigidbody2D>().gravityScale;
            float JumpForce_robot = robot.GetComponent<PlatformerCharacter2D>().m_JumpForce;
            if (gravity_robot > 0) // si on est au dessus
            {
                robot.GetComponent<Rigidbody2D>().gravityScale = gravity_robot * (-1); // inverse la gravité
                robot.transform.SetPositionAndRotation(repspawnPostionDown, repspawnRotationDown); // respawn 
                robot.GetComponent<PlatformerCharacter2D>().m_JumpForce = JumpForce_robot * (-1);
            }
            else // si on est en dessous
            {
                robot.GetComponent<Rigidbody2D>().gravityScale = gravity_robot * (-1); // inverse la gravité
                robot.transform.SetPositionAndRotation(repspawnPostionUp, repspawnRotationUp); // respawn 
                robot.GetComponent<PlatformerCharacter2D>().m_JumpForce = JumpForce_robot * (-1);
            }
        }
    }
}