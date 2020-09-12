using UnityEngine;

namespace Complete
{
    public class CharMovement : MonoBehaviour
    {
        public float m_Speed = 12f;                 // How fast the tank moves forward and back.

        private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
        private Rigidbody m_Rigidbody;              // Reference used to move the tank.
        private float m_MovementInputValue;         // The current value of the movement input.

        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }


        private void OnEnable()
        {
            // When the tank is turned on, make sure it's not kinematic.
            m_Rigidbody.isKinematic = false;

            // Also reset the input values.
            m_MovementInputValue = 0f;

        }




        private void Start()
        {
            // The axes names are based on player number.
            m_MovementAxisName = "Vertical";

        }


        private void Update()
        {
            // Store the value of both input axes.
            m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        }

        private void FixedUpdate()
        {
            // Adjust the rigidbodies position and orientation in FixedUpdate.
            Move();
        }


        private void Move()
        {
            // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
            Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

            // Apply this movement to the rigidbody's position.
            m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        }
    }
}