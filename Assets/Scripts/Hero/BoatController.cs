using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class BoatController: MonoBehaviour
    {
        [SerializeField] VariableJoystick joystick;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
    
        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}