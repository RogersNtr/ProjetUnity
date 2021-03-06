using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl2 : MonoBehaviour{
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private void Awake(){
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update(){
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetKey(KeyCode.Z);
            }
        }
        
        private void FixedUpdate(){
            float h = CrossPlatformInputManager.GetAxis("Horizontal2"); 
            bool crouch = Input.GetKey(KeyCode.S);
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
