using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    public class portailVertical : MonoBehaviour {
        Vector3 pos_portail = new Vector3();
        Vector3 repspawnPositionDown = new Vector3();
        Quaternion repspawnRotationDown = new Quaternion(0f, 0f, 180, 0f);
        Vector3 repspawnPostionUp = new Vector3();
        Quaternion repspawnRotationUp = new Quaternion(0f, 0f, 0f, 0f);
        void Start()
        {
            pos_portail = gameObject.transform.position;
            repspawnPositionDown.x = pos_portail.x+3;
            repspawnPositionDown.y = pos_portail.y;
            repspawnPostionUp.x = pos_portail.x-3;
            repspawnPostionUp.y = pos_portail.y;
        }
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            GameObject robot = collision.gameObject;
            GameObject var = GameObject.FindWithTag("Enemies");
            if (var != robot)
            {
                float gravity_robot = robot.GetComponent<Rigidbody2D>().gravityScale;
                float JumpForce_robot = robot.GetComponent<PlatformerCharacter2D>().m_JumpForce;
                if (gravity_robot > 0) // si on est au dessus
                {
                    robot.GetComponent<Rigidbody2D>().gravityScale = gravity_robot * (-1); // inverse la gravité
                    robot.transform.SetPositionAndRotation(repspawnPositionDown, repspawnRotationDown); // respawn 
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
}