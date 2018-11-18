using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour{
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private void Awake(){
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update(){
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump"); sauter avec le bouton espace
                m_Jump = Input.GetKey(KeyCode.UpArrow);
            }
        }
        
        private void FixedUpdate(){
            float h = CrossPlatformInputManager.GetAxis("Horizontal"); // bouger avec les flèches gauche et droite
            bool crouch = false;
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
