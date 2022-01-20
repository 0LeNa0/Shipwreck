using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Hero
{
    public class BoatController: MonoBehaviour
    {
        [SerializeField] VariableJoystick joystick;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private GameObject touchForPlay;
        
        private static float speed;

        void Awake()
        {
            speed = 20;
        }
        public static void SpeedUp(float boost)
        {
            speed += boost;
            Debug.Log(speed);
        }
        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if (touchForPlay)
                {
                    Destroy(touchForPlay,0.5f);
                }
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            }
        }
    }
}